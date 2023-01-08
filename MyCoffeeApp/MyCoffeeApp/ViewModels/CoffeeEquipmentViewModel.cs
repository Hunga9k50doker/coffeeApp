using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        CoffeeService coffeeService;

        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Coffee> FavoriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand<object> SelecteddetailCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public CoffeeEquipmentViewModel()
        {


            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            

            LoadMore(); 
            
            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            SelecteddetailCommand = new AsyncCommand<object>(Selecteddetail);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }

      
        async Task Favorite(Coffee coffee)
        {

            if (coffee == null)
                return;
            Console.WriteLine("123323212313213" + coffee.id + coffee.name);
            coffeeService = DependencyService.Get<CoffeeService>();
            //await coffeeService.AddCoffeeToFav(coffee);
            await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã thêm " + coffee.name + " vào mục yêu thích", "Đóng");

        }

        //Coffee previouslySelected;
        Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);
        }

        async Task Selected(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
                return;

            SelectedCoffee = null;


            await AppShell.Current.GoToAsync(nameof(AddMyCoffeePage));
            //await Application.Current.MainPage.DisplayAlert("Selected", coffee.name, "OK");

        }

        async Task Selecteddetail(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
                return;
            //var route = $"{nameof(MyCoffeedetailsPage)}?CoffeeId={4}";
            //await Shell.Current.GoToAsync(route);
            //await Application.Current.MainPage.Navigation.PushAsync(new MyCoffeeDetailsPage(coffee.id, coffee.name, coffee.price, coffee.detail, coffee.image));

        }
        async Task Refresh()
        {
             IsBusy = true;
            await Task.Delay(2000);

            Coffee.Clear();
            LoadMore();

            IsBusy = false;
        }

        void LoadMore()
        {
            if (Coffee.Count >= 20)
                return;
            Coffee.Add(new Coffee { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Americano", price = 12, image = "caffe_americano.jpg" });
            Coffee.Add(new Coffee { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Vanilla Latte", price = 11, image = "asset_vanilla_latte.jpg" });
            Coffee.Add(new Coffee { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Latte", price = 6, image = "caffee_latte.jpg" });
            Coffee.Add(new Coffee { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Mocha", price = 5, image = "caffee_mocha.jpg" });

            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("", Coffee.Where(c => true)));
        }

        void DelayLoadMore()
        {
            if (Coffee.Count <= 10)
                return;

            LoadMore();
         }


        void Clear()
        {
            Coffee.Clear();
            CoffeeGroups.Clear();
        }

    }
}

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
        public AsyncCommand<object> SelectedDetailCommand { get; }

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
            SelectedDetailCommand = new AsyncCommand<object>(SelectedDetail);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }

      
        async Task Favorite(Coffee coffee)
        {

            if (coffee == null)
                return;
            Console.WriteLine("123323212313213" + coffee.id + coffee.Name);
            coffeeService = DependencyService.Get<CoffeeService>();
            //await coffeeService.AddCoffeeToFav(coffee);
            await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã thêm " + coffee.Name + " vào mục yêu thích", "Đóng");

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
            //await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "OK");

        }

        async Task SelectedDetail(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
                return;
            //var route = $"{nameof(MyCoffeeDetailsPage)}?CoffeeId={4}";
            //await Shell.Current.GoToAsync(route);
            await Application.Current.MainPage.Navigation.PushAsync(new MyCoffeeDetailsPage(coffee.id, coffee.Name, coffee.Price, coffee.Detail, coffee.Image));

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
            Coffee.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Americano", Price = 12, Image = "caffe_americano.jpg" });
            Coffee.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Vanilla Latte", Price = 11, Image = "asset_vanilla_latte.jpg" });
            Coffee.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Latte", Price = 6, Image = "caffee_latte.jpg" });
            Coffee.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Mocha", Price = 5, Image = "caffee_mocha.jpg" });

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

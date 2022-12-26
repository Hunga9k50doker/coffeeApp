using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    public partial class CoffeeEquipmentPage : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();
        public List<Coffee> list;
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
           list = _cfDatabase.GetCoffee();
            clsCoffee.ItemsSource = list;
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            list = _cfDatabase.GetCoffee();
            clsCoffee.ItemsSource = list;
        }
        private void addCoffee_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMyCoffeePage());
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Coffee animalItem = (Coffee)e.;
            var cf = clsCoffee.SelectedItem as Coffee;
            Navigation.PushAsync(new MyCoffeeDetailsPage(cf.id,cf.Name, cf.Price, cf.Detail, cf.Image));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            list.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Americano", Price = 12, Image = "caffe_americano.jpg" });
            list.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Vanilla Latte", Price = 11, Image = "asset_vanilla_latte.jpg" });
            list.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Latte", Price = 6, Image = "caffee_latte.jpg" });
            list.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Mocha", Price = 5, Image = "caffee_mocha.jpg" });
            clsCoffee.ItemsSource = list;

        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Coffee;
            var cf = new Favorite
            {
                Name = ct.Name,
                Detail = ct.Detail,
                Image = ct.Image,
                Price = ct.Price,
            };
            if (App.CoffeeDb.AddCoffeeToFav(cf))
            {
                await DisplayAlert("Thông báo", $"Đã thêm {cf.Name} vào mục yêu thích.", "Đóng");
            }
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Coffee;
            var cf = new Cart
            {
                Name = ct.Name,
                Detail = ct.Detail,
                Image = ct.Image,
                Price = ct.Price,
                Count = 1,
            };
            if (App.CoffeeDb.AddCoffeeToCart(cf))
            {
                await DisplayAlert("Thông báo", $"Đã thêm {cf.Name} vào giỏ hàng.", "Đóng");
            }
        }

        private async void SwipeItem_Invoked_2(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Coffee;
            if (App.CoffeeDb.RemoveCoffee(ct))
            {
                await DisplayAlert("Thông báo", $"Đã xoas {ct.Name} thành công.", "Đóng");
            }
        }
    }
}
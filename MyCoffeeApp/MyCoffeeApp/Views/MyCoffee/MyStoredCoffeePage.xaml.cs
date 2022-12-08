using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyStoredCoffeePage : ContentPage
    {
      
        private readonly CoffeeService _cfDatabase = new CoffeeService();

        public MyStoredCoffeePage()
        {
            InitializeComponent();
            List<Favorite> list = _cfDatabase.GetFavorite();
            cvcFavorite.ItemsSource = list;

        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            List<Favorite> list = _cfDatabase.GetFavorite();
            cvcFavorite.ItemsSource = list;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Favorite cf = (Favorite)mi.CommandParameter;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa {cf.Name} không?", "Có", "Hủy bỏ");
            if (answer)
            {
                App.CoffeeDb.RemoveFav(cf);
                cvcFavorite.ItemsSource = App.CoffeeDb.GetFavorite();
            }
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Favorite ct = (Favorite)mi.CommandParameter;
            var cf = new Cart
            {
                Name = ct.Name,
                Detail = ct.Detail,
                Image = ct.Image,
                Price = ct.Price,
                Count=1,
            };
            if (App.CoffeeDb.AddCoffeeToCart(cf))
            {
                await DisplayAlert("Thông báo", $"Đã thêm {cf.Name} vào giỏ hàng?",  "Đóng");
            }

        }
    }
}
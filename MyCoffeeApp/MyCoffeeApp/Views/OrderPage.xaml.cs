using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    public partial class OrderPage : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();


        public OrderPage()
        {
            
            InitializeComponent();
            List<Cart> list = _cfDatabase.GetCartCoffee();
            cvcCart.ItemsSource = list;
            total.Text = list.Sum(x => Convert.ToInt32(x.Count)* Convert.ToInt32(x.Price)).ToString();
        }
        protected override  void OnAppearing()
        {
            base.OnAppearing();
            List<Cart> list = _cfDatabase.GetCartCoffee();
            cvcCart.ItemsSource = list;
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
        }

        private async void favorite_Invoked(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Cart;
            var cf = new Favorite
            {
                Name = ct.Name,
                Detail =ct.Detail,
                Image =ct.Image ,
                Price =ct.Price,
            };
            if (App.CoffeeDb.AddCoffeeToFav(cf))
            {
                await DisplayAlert("Thông báo", $"Đã thêm {cf.Name} vào mục yêu thích.", "Đóng");
            }
        }
        private  void Up_Clicked(object sender, EventArgs e)
        {
            var item = cvcCart.SelectedItem as Cart;
            item.Count++;
            var cart = new Cart {
                Name = item.Name,
                Price = item.Price,
                Detail = item.Detail,
                Image = item.Image,
                Count = item.Count
            };
            Console.WriteLine(item.Count);
            App.CoffeeDb.EditCart(cart);
            List<Cart> list = _cfDatabase.GetCartCoffee();
            cvcCart.ItemsSource = list;
            //total.Text = list.Sum(x => Convert.ToInt32(x.Count) * Convert.ToInt32(x.Price)).ToString();
            total.Text =( Convert.ToInt32(total.Text) + Convert.ToInt32(item.Price)).ToString();
        }

        private void Down_Clicked(object sender, EventArgs e)
        {
            var item = cvcCart.SelectedItem as Cart;
            if (item.Count > 1)
            {
               item.Count--;
                var cart = new Cart
                {
                    Name = item.Name,
                    Price = item.Price,
                    Detail = item.Detail,
                    Image = item.Image,
                    Count = item.Count
                };
                App.CoffeeDb.EditCart(cart);
                List<Cart> list = _cfDatabase.GetCartCoffee();
                cvcCart.ItemsSource = list;
                total.Text = (Convert.ToInt32(total.Text) - Convert.ToInt32(item.Price)).ToString();

            }

        }

        private async void delete_Invoked_1(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Cart;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa {ct.Name} không?", "Có", "Hủy bỏ");
            if (answer)
            {
                App.CoffeeDb.RemoveCart(ct);
                cvcCart.ItemsSource = App.CoffeeDb.GetCartCoffee();
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Payment(total.Text));
        }
    }
}
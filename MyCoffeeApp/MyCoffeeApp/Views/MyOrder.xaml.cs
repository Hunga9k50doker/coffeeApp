using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    public partial class MyOrder : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();

        public List<cartDetails> listInit;

        public MyOrder()
        {
            
            InitializeComponent();
            GetAllCf();
        }
        protected override  void OnAppearing()
        {
            base.OnAppearing();
            GetAllCf();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
        }

        private async void favorite_Invoked(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Cart;
            //var cf = new Favorite
            //{
            //    name = ct.name,
            //    detail =ct.detail,
            //    image =ct.image ,
            //    price =ct.price,
            //};
            //if (App.CoffeeDb.AddCoffeeToFav(cf))
            //{
            //    await DisplayAlert("Thông báo", $"Đã thêm {cf.name} vào mục yêu thích.", "Đóng");
            //}
        }
        private  void Up_Clicked(object sender, EventArgs e)
        {
            var item = cvcCart.SelectedItem as Cart;
            //item.count++;
            //var cart = new Cart {
            //    id = item.id,
            //    name = item.name,
            //    price = item.price,
            //    detail = item.detail,
            //    image = item.image,
            //    count = item.count
            //};
            //App.CoffeeDb.EditCart(cart);
            List<Cart> list = _cfDatabase.GetCartCoffee();
            cvcCart.ItemsSource = list;
            //total.Text = list.Sum(x => Convert.ToInt32(x.count) * Convert.ToInt32(x.price)).ToString();
            //total.Text =( Convert.ToInt32(total.Text) + Convert.ToInt32(item.price)).ToString();
        }

        private void Down_Clicked(object sender, EventArgs e)
        {
            var item = cvcCart.SelectedItem as Cart;
            //if (item.count > 1)
            //{
            //   item.count--;
            //    var cart = new Cart
            //    {
            //        id=item.id,
            //        name = item.name,
            //        price = item.price,
            //        detail = item.detail,
            //        image = item.image,
            //        count = item.count
            //    };
            //    App.CoffeeDb.EditCart(cart);
            //    List<Cart> list = _cfDatabase.GetCartCoffee();
            //    cvcCart.ItemsSource = list;
            //    //total.Text = (Convert.ToInt32(total.Text) - Convert.ToInt32(item.price)).ToString();

            //}

        }
        async void GetAllCf()
        {
            HttpClient httpClient = new HttpClient();

            var result = await httpClient.GetStringAsync("http://coffeeapi.somee.com/api/Cart/" + ((App)App.Current).cartId);
            var kqtv = JsonConvert.DeserializeObject<Cart>(result);
            listInit = kqtv.cartDetails;
            cvcCart.ItemsSource = listInit;
        }
        private async void delete_Invoked_1(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var cf = swItem.CommandParameter as Cart;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa không?", "Có", "Hủy bỏ");
            if (answer)
            {
                HttpClient httpClient = new HttpClient();
                await httpClient.DeleteAsync("http://coffeeapi.somee.com/api/Cart/" + cf.id);
                await DisplayAlert("Thông báo", $"Đã xóa khỏi mục yêu thích", "Đóng");
                GetAllCf();
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{(new Payment(total.Text))}");
            //await Navigation.PushAsync(new Payment(total.Text));
        }
    }
}
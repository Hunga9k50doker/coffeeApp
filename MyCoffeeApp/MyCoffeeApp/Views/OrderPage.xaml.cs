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
    public partial class OrderPage : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();
        public List<cartDetails> listInit;


        public OrderPage()
        {
            
            InitializeComponent();
            GetAllCf();
        }
        async void GetAllCf()
        {
            HttpClient httpClient = new HttpClient();

            var result = await httpClient.GetStringAsync("http://coffeeapi.somee.com/api/Cart/" + ((App)App.Current).userId);
            var kqtv = JsonConvert.DeserializeObject<Cart>(result);
            listInit = kqtv.cartDetails;
            var sum = 0;
            foreach (var item in listInit)
            {
                sum += int.Parse(item.coffee.price.ToString()) * item.quantity;
            }
            total.Text = sum.ToString();
            cvcCart.ItemsSource = listInit;
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
            var ct = swItem.CommandParameter as cartDetails;
            var cf = new
            {
                coffeeId = ct.coffee.id,
                favouriteId = ((App)App.Current).favId,
            };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(cf);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            await http.PostAsync
              ("http://coffeeapi.somee.com/api/Favorite", httcontent);
            await DisplayAlert("Thông báo", $"Đã thêm vào mục yêu thích.", "Đóng");
        
    }
        private async  void  Up_Clicked(object sender, EventArgs e)
        {
            var item = cvcCart.SelectedItem as cartDetails;

            var cf = new 
            {
                quantity = 1,
                coffeeId = item.coffee.id,
                cartId = ((App)App.Current).cartId,
            };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(cf);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
           var result= await http.PostAsync("http://coffeeapi.somee.com/api/Cart", httcontent);
            GetAllCf();
        }

        private async void Down_Clicked(object sender, EventArgs e)
        {
            var item = cvcCart.SelectedItem as cartDetails;
            Console.WriteLine(item.coffee.id, item.quantity);
            if (item.quantity > 1)
            {
                var cf = new 
                {
                    quantity = -1,
                    coffeeId = item.coffee.id,
                    cartId = ((App)App.Current).cartId,
                };
                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(cf);
                StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                await http.PostAsync("http://coffeeapi.somee.com/api/Cart", httcontent);
            }
            GetAllCf();

        }

        private async void delete_Invoked_1(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as cartDetails;
            var mi = ((MenuItem)sender);
            cartDetails cf = (cartDetails)mi.CommandParameter;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa không?", "Có", "Hủy bỏ");
            if (answer)
            {
                HttpClient httpClient = new HttpClient();
                await httpClient.DeleteAsync("http://coffeeapi.somee.com/api/Cart/" + cf.id);
                await DisplayAlert("Thông báo", $"Đã xóa khỏi giỏ hàng", "Đóng");
                GetAllCf();
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{(new Payment(total.Text))}");
            await Navigation.PushAsync(new Payment(total.Text));
        }
    }
}
using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace MyCoffeeApp.Views
{
    public partial class CoffeeEquipmentPage : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();
        public List<Coffee> listInit;
        public List<Coffee> listCf;

        public CoffeeEquipmentPage()
        {
            InitializeComponent();
            GetAllCf();
        }
        async void GetAllCf()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("http://coffeeapi.somee.com/api/Coffee");
            listInit = JsonConvert.DeserializeObject<List<Coffee>>(result);
            listCf = listInit;
            clsCoffee.ItemsSource = listInit;
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            GetAllCf();

        }
        private void addCoffee_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMyCoffeePage());
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cf = clsCoffee.SelectedItem as Coffee;
            Navigation.PushAsync(new MyCoffeeDetailsPage(cf));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            clsCoffee.ItemsSource = listInit.Concat(listCf).ToList();

        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Coffee;
            var us = new Favorite
            {
                coffeeId = ct.id,
                favouriteId = ((App)App.Current).favId,
            };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(us);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq = await http.PostAsync
            ("http://coffeeapi.somee.com/api/Favourite", httcontent);
            await DisplayAlert("Thông báo", $"Đã thêm vào mục yêu thích.", "Đóng");
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Coffee;
            var cf = new Cart
            {
                quantity = 1,
                coffeeId= ct.id,
                cartId = ((App)App.Current).cartId,
            };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(cf);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq = await http.PostAsync
            ("http://coffeeapi.somee.com/api/Cart", httcontent);
            await DisplayAlert("Thông báo", $"Đã thêm vào giỏ hàng.", "Đóng");
        }

        private async void SwipeItem_Invoked_2(object sender, EventArgs e)
        {
            var swItem = sender as SwipeItem;
            var ct = swItem.CommandParameter as Coffee;
            if (App.CoffeeDb.RemoveCoffee(ct))
            {
                await DisplayAlert("Thông báo", $"Đã xoas {ct.name} thành công.", "Đóng");
            }
        }
    }
}
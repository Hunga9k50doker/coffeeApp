using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public List<favouriteDetails> listInit;
        public MyStoredCoffeePage()
        {
            InitializeComponent();
            GetAllCf();

        }
        async void GetAllCf()
        {
            HttpClient httpClient = new HttpClient();

            var result = await httpClient.GetStringAsync("http://coffeeapi.somee.com/api/Favourite/" + ((App)App.Current).userId);
            var kqtv = JsonConvert.DeserializeObject<Favorite>(result);
            listInit =  kqtv.favouriteDetails;
            cvcFavorite.ItemsSource = listInit;
        }
        protected override  void OnAppearing()
        {
            base.OnAppearing();
            GetAllCf();
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            favouriteDetails cf = (favouriteDetails)mi.CommandParameter;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa không?", "Có", "Hủy bỏ");
            if (answer)
            {
                HttpClient httpClient = new HttpClient();
                await httpClient.DeleteAsync("http://coffeeapi.somee.com/api/Favourite/" + cf.id);
                await DisplayAlert("Thông báo", $"Đã xóa khỏi mục yêu thích", "Đóng");
                GetAllCf();
            }
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            favouriteDetails ct = (favouriteDetails)mi.CommandParameter;
            Console.WriteLine(ct.coffee.id);
            var cf = new 
            {
                quantity = 1,
                coffeeId = ct.coffee.id,
                cartId = ((App)App.Current).cartId,
            };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(cf);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
          await http.PostAsync("http://coffeeapi.somee.com/api/Cart", httcontent);
            await DisplayAlert("Thông báo", $"Đã thêm vào giỏ hàng.", "Đóng");
        }
    }
}
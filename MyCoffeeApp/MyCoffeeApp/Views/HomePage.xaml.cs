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
    public partial class HomePage : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();
        public List<Coffee> listInit;
        public HomePage()
        {
            InitializeComponent();
            GetAllCf();
        }

        async void GetAllCf()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("http://coffeeapi.somee.com/api/Coffee");
            listInit = JsonConvert.DeserializeObject<List<Coffee>>(result);
            //cvcCoffee_1.ItemsSource = listInit;
        }
        private void searchItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ImgAddToWishList_Tapped(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            img.Source = img.Source == (ImageSource)"FavouriteBlackIcon.png" ? "FavouriteRedIcon.png" : "FavouriteBlackIcon.png";
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var swItem =cvcCoffee_2.SelectedItem as Coffee;
            await Navigation.PushAsync(new MyCoffeeDetailsPage(swItem));
        }
        private async void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var swItem = cvcCoffee_1.SelectedItem as Coffee;
            await Navigation.PushAsync(new MyCoffeeDetailsPage(swItem));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAllCf();
        }
    }
}
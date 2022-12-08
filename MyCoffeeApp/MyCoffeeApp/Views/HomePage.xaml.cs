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
    public partial class HomePage : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();
        public HomePage()
        {
            InitializeComponent();
            //List<Coffee> list = _cfDatabase.GetCoffee();
            //cvcCoffee_1.ItemsSource = list;
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
            await Navigation.PushAsync(new MyCoffeeDetailsPage(swItem.Name, swItem.Price, swItem.Detail, swItem.Image));
        }
        private async void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var swItem = cvcCoffee_1.SelectedItem as Coffee;
            await Navigation.PushAsync(new MyCoffeeDetailsPage(swItem.Name, swItem.Price, swItem.Detail, swItem.Image));
        }
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var vm = (MyCoffeeViewModel)BindingContext;
        //    if (vm.Coffee.Count == 0)
        //        await vm.RefreshCommand.ExecuteAsync();
        //}
    }
}
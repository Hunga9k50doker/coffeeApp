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
        public HomePage()
        {
            InitializeComponent();

        }

        private void searchItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ImgAddToWishList_Tapped(object sender, EventArgs e)
        {

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
using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    public partial class OtherCoffee : ContentPage
    {
        public OtherCoffee()
        {
            InitializeComponent();

        }

      
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var random = new Random();
            var random1 = (int)random.Next(0, 255);
            var random2 = (int)random.Next(0, 255);
            var random3 = (int)random.Next(0, 255);
            App.Current.Resources["WindowBackgroundColor"] = Color.FromRgb(random1, random2, random3);
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
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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {

            InitializeComponent();
        }

        private async void Button_Clicked_Register(object sender, EventArgs e)
        {
            DisplayAlert("Notify", "Success!", "Ok");
            await Shell.Current.GoToAsync($"//{nameof(CoffeeEquipmentPage)}");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");

        }

    }
}
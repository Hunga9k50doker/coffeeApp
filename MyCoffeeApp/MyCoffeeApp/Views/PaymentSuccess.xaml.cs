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
    public partial class PaymentSuccess : ContentPage
    {
        public PaymentSuccess(string name, string addressUser, string number, string total)
        {
            InitializeComponent();
            nameuser.Text = name;
            address.Text = addressUser;
            phonenumber.Text = number;
            totalPayment.Text = total;
        }

        protected override  void OnAppearing()
        {
            //  base.OnAppearing();
            // var loggedin = true;
            // if(loggedin)
            //await Shell.Current.GoToAsync($"//{nameof(OrderPage)}");

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(OrderPage)}");
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
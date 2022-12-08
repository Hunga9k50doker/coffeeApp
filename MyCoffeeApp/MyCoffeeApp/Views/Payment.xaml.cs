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
    public partial class Payment : ContentPage
    {
        public Payment(string totalPrice)
        {
            InitializeComponent();
            total.Text = totalPrice+"$";
        }

        protected override  void OnAppearing()
        {
          //  base.OnAppearing();
           // var loggedin = true;
           // if(loggedin)
             //   await Shell.Current.GoToAsync($"//{nameof(CoffeeEquipmentPage)}");

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nameuser.Text) || string.IsNullOrWhiteSpace(address.Text)|| string.IsNullOrWhiteSpace(phonenumber.Text))
            {
                await DisplayAlert("Thông báo!", "Vui lòng nhập đầy đủ thông tin", "Đóng");
            }else
                await Navigation.PushAsync(new PaymentSuccess(nameuser.Text,address.Text,phonenumber.Text,total.Text));
        }
    }
}
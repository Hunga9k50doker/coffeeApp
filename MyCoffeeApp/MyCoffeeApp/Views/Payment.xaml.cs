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

        public async void Button_Clicked(object sender, EventArgs e)
        {
            var cf = new
            {
                name=nameuser.Text,
                address= address.Text,
                phoneNumber  = phonenumber.Text,
                email = "hungphanha@example.com",
                userId = ((App)App.Current).userId,
            };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(cf);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            if (string.IsNullOrWhiteSpace(nameuser.Text) || string.IsNullOrWhiteSpace(address.Text)|| string.IsNullOrWhiteSpace(phonenumber.Text))
            {
                await DisplayAlert("Thông báo!", "Vui lòng nhập đầy đủ thông tin", "Đóng");
            }else
            await http.PostAsync("http://coffeeapi.somee.com/api/Order/order", httcontent);
            await Navigation.PushAsync(new PaymentSuccess(nameuser.Text,address.Text,phonenumber.Text,total.Text));
        }
    }
}
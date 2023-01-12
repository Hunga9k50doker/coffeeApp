using MyCoffeeApp.Shared.Models;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            TapGestureRecognizer();
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
            User us = new User
            {
                username = UsernameEntry.Text,
                password = PasswordEntry.Text
            };
            HttpClient http = new HttpClient();
          
            if (string.IsNullOrWhiteSpace(us.id)|| string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Thông báo", "Tên đăng nhập hoặc mật khẩu không chính xác.", "OK");

            }
            else if (!string.IsNullOrWhiteSpace(us.id))
            {
                string jsonlh = JsonConvert.SerializeObject(us);
                StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq = await http.PostAsync
                ("http://coffeeapi.somee.com/api/User/login", httcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                us = JsonConvert.DeserializeObject<User>(kqtv);
                if (string.IsNullOrWhiteSpace(us.favourite?.id))
                {
                await http.GetStringAsync
                ("http://coffeeapi.somee.com/api/Favourite/"+ us.id);
                }
                if (string.IsNullOrWhiteSpace(us.cart?.id))
                {
                await http.GetStringAsync
                ("http://coffeeapi.somee.com/api/Cart/"+ us.id);
                }
                ((App)App.Current).userId = us.id;
                ((App)App.Current).favId = us.favourite?.id;
                ((App)App.Current).cartId = us.cart?.id;
                ((App)App.Current).role = us.username;
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                await DisplayAlert("Thông báo", "Đăng nhập thành công.", "OK");
            }
        }

        void TapGestureRecognizer()
        {
            TapGestureRecognizer_Tapped.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");

                })

            });

        }
      
    }
}
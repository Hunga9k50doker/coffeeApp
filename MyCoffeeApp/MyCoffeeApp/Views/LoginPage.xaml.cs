using MyCoffeeApp.Shared.Models;
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
            var us = new User
            {
                username = UsernameEntry.Text,
                password = PasswordEntry.Text
            };
            if(!App.CoffeeDb.Login(us) || string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Thông báo", "Tên đăng nhập hoặc mật khẩu không chính xác.", "OK");

            }
            else if(App.CoffeeDb.Login(us))
            {
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
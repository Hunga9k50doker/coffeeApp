using MyCoffeeApp.Shared.Models;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        //public ICommand TapGestureRecognizer_Tapped => new Command(TapGestureRecognizer);
        public RegistrationPage()
        {

            InitializeComponent();
            TapGestureRecognizer();
        }

        private async void Button_Clicked_Register(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin.", "Đóng");

            } 
            else if(PasswordEntry.Text != ConfirmPassword.Text)
            {
                await DisplayAlert("Thông báo", "Mật khẩu không khớp.", "Đóng");
            }
            else
            {
                var us = new User
                {
                    username = UsernameEntry.Text,
                    password = PasswordEntry.Text
                };
                if (App.CoffeeDb.Register(us))
                {
                await DisplayAlert("Thông báo", "Đăng ký thành công!", "Đóng");
                await Shell.Current.GoToAsync($"//{nameof(CoffeeEquipmentPage)}");
                }
            }
        }

        void TapGestureRecognizer()
        {
            TapGestureRecognizer_Tapped.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                 Shell.Current.GoToAsync($"{nameof(LoginPage)}");

                })

            });

        }

    }
}
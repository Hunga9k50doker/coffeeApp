using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoffeeApp.Shared.Models;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private SQLiteConnection DB;
        User1 _user;
        public RegistrationPage()
        {
            InitializeComponent();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DB = new SQLiteConnection(System.IO.Path.Combine(folder, "UserDatabase.db"));
            DB.CreateTable<User1>();

            _user = new User1()
            {
                UserName = EntryUsername.Text,
                UserPassword = EntryPassword.Text,
            };

            DB.Insert(_user);
        }

        private async void Button_Clicked_Register(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntryUsername.Text) || string.IsNullOrWhiteSpace(EntryPassword.Text))
            {
                await DisplayAlert("THÔNG BÁO", "Vui lòng điền đủ thông tin", "OK");
            }
            else
            {
                await DisplayAlert("Notify", "Success!", "Ok");
                await Shell.Current.GoToAsync($"//{nameof(CoffeeEquipmentPage)}");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");

        }

    }
}
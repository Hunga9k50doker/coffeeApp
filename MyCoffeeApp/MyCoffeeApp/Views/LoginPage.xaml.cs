using MyCoffeeApp.Shared.Models;
using SQLite;
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
        private SQLiteConnection DB;
        User1 _user;
        public LoginPage()
        {
            InitializeComponent();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DB = new SQLiteConnection(System.IO.Path.Combine(folder, "UserDatabase.db"));
           
        }

        protected override async void OnAppearing()
        {
            //  base.OnAppearing();
            // var loggedin = true;
            // if(loggedin)
            //   await Shell.Current.GoToAsync($"//{nameof(CoffeeEquipmentPage)}");

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var item1 = DB.Table<User1>().Where(u => u.UserName.Equals(EnterUserName1.Text) && u.UserPassword.Equals(EnterUserPass1.Text)).FirstOrDefault();
            
            if (item1 != null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await this.DisplayAlert("THÔNG BÁO", "Thông tin không đúng!", "OK");
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                });

            }
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");

        }
    }
}
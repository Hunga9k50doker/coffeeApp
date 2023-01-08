using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMyCoffeePage : ContentPage
    {
        public AddMyCoffeePage()
        {
            InitializeComponent();
        }

        //async Task Save()
        //{
        //    if (string.IsNullOrWhiteSpace(name) ||
        //        string.IsNullOrWhiteSpace(detail))
        //    {
        //        return;
        //    }


        //    Coffee cf = new Coffee
        //    {
        //        Name = name,
        //        Image = image,
        //        Price = price,
        //        Detail = detail,
        //    };
        //    if (App.CoffeeDb.AddCoffee(cf))
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Thông báo", $"Thêm thành công!", "OK");
        //        await Application.Current.MainPage.Navigation.PopAsync();
        //    }
        //    else
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Lỗi", "Thêm mới thất bại", "OK");
        //    }

        //    await Shell.Current.GoToAsync("..");
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
             Coffee cf = new Coffee
            {
                name = name.Text,
                image = image.Text,
                price = Convert.ToInt32 (price.Text),
                detail = detail.Text,
            };
            if (App.CoffeeDb.AddCoffee(cf))
            {
                await Application.Current.MainPage.DisplayAlert("Thông báo", $"Thêm thành công!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", "Thêm mới thất bại", "OK");
            }
        }
    }
}
using MvvmHelpers.Commands;
using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace MyCoffeeApp.ViewModels
{

    //[QueryProperty(nameof(Name), nameof(Name))]
    public class AddMyCoffeeViewModel :ViewModelBase
    {
      
        string name, detail, image;
        float price;
        public string Image { get => image; set => SetProperty(ref image, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Detail { get => detail; set => SetProperty(ref detail, value); }
        public float Price { get => price; set => SetProperty(ref price, value); }
        public AsyncCommand SaveCommand { get; }

        public AddMyCoffeeViewModel()
        {
            SaveCommand = new AsyncCommand(Save);
        }
        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(detail))
            {
                return;
            }


            Coffee cf = new Coffee
            {
                Name = name,
                Image =image,
                Price = price,
                Detail = detail,
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

            await Shell.Current.GoToAsync("..");
        }

      
    }
}

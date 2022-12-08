using MvvmHelpers.Commands;
using MyCoffeeApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class EditMyCoffeeViewModel : ViewModelBase
    {

        string name, detail,image;
            float price;
        int id;
        public int Id { get => id; set => SetProperty(ref id, value); }
        public string Image { get => image; set => SetProperty(ref image, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Detail { get => detail; set => SetProperty(ref detail, value); }
        public float Price { get => price; set => SetProperty(ref price, value); }


        public AsyncCommand SaveCommand { get; }
        CoffeeService coffeeService;
        public EditMyCoffeeViewModel()
        {
            SaveCommand = new AsyncCommand(Save);
            coffeeService = DependencyService.Get<CoffeeService>();
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(detail) )
            {
                return;
            }

            //await coffeeService.EditCoffee(id,name,image,detail,price);

            await Shell.Current.GoToAsync("..");
        }
    }
}

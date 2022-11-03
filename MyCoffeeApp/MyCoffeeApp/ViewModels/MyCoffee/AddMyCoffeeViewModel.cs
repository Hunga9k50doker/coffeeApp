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
    public class AddMyCoffeeViewModel : ViewModelBase
    {

        string name, detail;
            float price;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Detail { get => detail; set => SetProperty(ref detail, value); }
        public float Price { get => price; set => SetProperty(ref price, value); }


        public AsyncCommand SaveCommand { get; }
        ICoffeeService coffeeService;
        public AddMyCoffeeViewModel()
        {
            Title = "Add Coffee";
            SaveCommand = new AsyncCommand(Save);
            coffeeService = DependencyService.Get<ICoffeeService>();
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(detail) )
            {
                return;
            }

            await coffeeService.AddCoffee(name,detail,price);

            await Shell.Current.GoToAsync("..");
        }
    }
}

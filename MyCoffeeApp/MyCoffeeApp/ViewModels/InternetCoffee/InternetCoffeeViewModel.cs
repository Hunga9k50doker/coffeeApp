using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MyCoffeeApp.ViewModels
{
    public class InternetCoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Coffee> RemoveCommand { get; }


        public InternetCoffeeViewModel()
        {

            Title = "Internet Coffee";

            Coffee = new ObservableRangeCollection<Coffee>();
  

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
        }

        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of coffee");
            var detail = await App.Current.MainPage.DisplayPromptAsync("Detail", "detail of coffee");
            var price = await App.Current.MainPage.DisplayPromptAsync("Price", "price of coffee");

            await InternetCoffeeService.AddCoffee(name, detail, float.Parse(price, CultureInfo.InvariantCulture.NumberFormat));
            await Refresh();
        }

        async Task Remove(Coffee coffee)
        {
            await InternetCoffeeService.RemoveCoffee(coffee.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Coffee.Clear();

            var coffees = await InternetCoffeeService.GetCoffee();

            Coffee.AddRange(coffees);

            IsBusy = false;
        }
    }
}

using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
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
    public partial class Espresso : ContentPage
    {
        private readonly CoffeeService _cfDatabase = new CoffeeService();
        public List<CoffeeTL> list;
        public Espresso()
        {
            InitializeComponent();
            list = new List<CoffeeTL>
            {
               new CoffeeTL { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Espresso", price = 12, image = "espresso.jpg" },
               new CoffeeTL { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Espresso Con Panna", price = 11, image = "espresso_con_panna.jpg" },
                new CoffeeTL { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Espresso Macchiato", price = 6, image = "espresso_macchiato.jpg" }
            };
            clsCoffee.ItemsSource = list;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            list.Add(new CoffeeTL { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Espresso", price = 12, image = "espresso.jpg" });
            list.Add(new CoffeeTL { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Espresso Con Panna", price = 11, image = "espresso_con_panna.jpg" });
            list.Add(new CoffeeTL { detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", name = "Espresso Macchiato", price = 6, image = "espresso_macchiato.jpg" });
            clsCoffee.ItemsSource = list;

        }

        private void clsCoffee_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CoffeeTL coffee = (CoffeeTL)e.SelectedItem;
            //Navigation.PushAsync(new MyCoffeeDetailsPage(coffee.id, coffee.name, coffee.price, coffee.detail, coffee.image));

        }
    }
}
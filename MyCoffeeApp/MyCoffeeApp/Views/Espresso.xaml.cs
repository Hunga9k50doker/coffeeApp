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
        public List<Coffee> list;
        public Espresso()
        {
            InitializeComponent();
            list = new List<Coffee>
            {
               new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Espresso", Price = 12, Image = "espresso.jpg" },
               new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Espresso Con Panna", Price = 11, Image = "espresso_con_panna.jpg" },
                new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Espresso Macchiato", Price = 6, Image = "espresso_macchiato.jpg" }
            };
            clsCoffee.ItemsSource = list;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            list.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Espresso", Price = 12, Image = "espresso.jpg" });
            list.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Espresso Con Panna", Price = 11, Image = "espresso_con_panna.jpg" });
            list.Add(new Coffee { Detail = "Một loại cà phê mang đến cho bạn cảm giác mới lạ. Độc đáo, giá cả phải chăng, mua ngay.", Name = "Espresso Macchiato", Price = 6, Image = "espresso_macchiato.jpg" });
            clsCoffee.ItemsSource = list;

        }

        private void clsCoffee_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Coffee coffee = (Coffee)e.SelectedItem;
            Navigation.PushAsync(new MyCoffeeDetailsPage(coffee.id, coffee.Name, coffee.Price, coffee.Detail, coffee.Image));

        }
    }
}
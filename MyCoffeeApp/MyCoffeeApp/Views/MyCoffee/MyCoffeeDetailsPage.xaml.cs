using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [QueryProperty(nameof(CoffeeId), nameof(CoffeeId))]
    public partial class MyCoffeeDetailsPage : ContentPage
    {
        public string CoffeeId { get; set; }

        public string imagePath { get; set; }
        public Coffee coffee { get; set; }

        CoffeeService coffeeService;
        public MyCoffeeDetailsPage(int id, string name, float price, string detail, string image)
        {
            InitializeComponent();
            //coffeeService = DependencyService.Get<CoffeeService>();
            imagePath=image;
            coffee = new Coffee
            {
                id = id,
            Name = name,
            Image = image,
            Price = price,
            Detail = detail,
        };

            Name.Text =  name;
            Price.Text = price.ToString();
            Detail.Text = detail;
            Image.Source = image;
        }

       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            int.TryParse(Price.Text, out int res);
            Cart cf = new Cart
            {
                Name = Name.Text,
                Image = imagePath,
                Price = res,
                Detail = Detail.Text,
                Count= 1
            };
            if (App.CoffeeDb.AddCoffeeToCart(cf))
            {
                await DisplayAlert("Thông báo!", $"Đã thêm sản phẩm vào giỏ hàng!", "Đóng");
                await Shell.Current.GoToAsync("..");
            }
        }
        //private async void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    var coffee = sender as Coffee;
        //    bool isDelete = await DisplayAlert("Thông báo", "Bạn có muốn xóa không?", "Xóa", "Hủy bỏ");
        //    if (isDelete)
        //    {
        //        //await coffeeService.RemoveCoffee(coffee);
        //        //await Refresh();
        //        //buttonDelete.Command = "{Binding Source={x:Reference MyCoffeePage}, Path=BindingContext.RemoveCommand}";
        //        await Shell.Current.GoToAsync("..");
        //    }
        //}

        private void editCoffee_Clicked(object sender, EventArgs e)
        {
            int.TryParse(Price.Text, out int res);
            Navigation.PushAsync(new EditMyCoffeePage(coffee));
        }
        protected override  void OnAppearing()
        {
            base.OnAppearing();
           
        }
    }
}
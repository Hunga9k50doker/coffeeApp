using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public MyCoffeeDetailsPage(Coffee cf)
        {
            InitializeComponent();
            imagePath=cf.image;
            CoffeeId = cf.id;
            coffee = new Coffee
            {
                id = cf.id,
                name = cf.name,
                image = cf.image,
                price = cf.price,
                detail = cf.detail,
            };

            Name.Text =  cf.name;
            Price.Text = cf.price.ToString();
            Detail.Text = cf.detail;
            Image.Source = cf.image;
        }

       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            int.TryParse(Price.Text, out int res);
            Cart cf = new Cart
            {
                quantity = 1,
                coffeeId = CoffeeId,
                cartId = ((App)App.Current).cartId,
            };
          
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(cf);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            await http.PostAsync
              ("http://coffeeapi.somee.com/api/Cart", httcontent);
            await DisplayAlert("Thông báo", $"Đã thêm vào giỏ hàng.", "Đóng");

            //if (App.CoffeeDb.AddCoffeeToCart(cf))
            //{
            //    await DisplayAlert("Thông báo!", $"Đã thêm sản phẩm vào giỏ hàng!", "Đóng");
            //    await Shell.Current.GoToAsync("..");
            //}
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
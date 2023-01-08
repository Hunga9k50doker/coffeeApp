using MyCoffeeApp.Shared.Models;
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
    public partial class EditMyCoffeePage : ContentPage
    {
        Coffee _coffee;

        public EditMyCoffeePage(Coffee cf)
        {
            InitializeComponent();
            _coffee = cf;
            name.Text = cf.name;
            image.Text = cf.image;
            price.Text = (cf.price).ToString();
            detail.Text = cf.detail;
            name.Focus();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(image.Text)|| string.IsNullOrWhiteSpace(price.Text) || string.IsNullOrWhiteSpace(detail.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đẩy đủ thông tin", "OK");
            }
            else if (_coffee != null)
            {
                float.TryParse(price.Text, out float pr);
                _coffee.name = name.Text;
                _coffee.image = image.Text;
                _coffee.price = pr;
                _coffee.detail = detail.Text;
                Console.WriteLine(_coffee.name);
                App.CoffeeDb.EditCoffee(_coffee);
                await DisplayAlert("Thông báo", $"Sửa thành công!", "OK");
                    await Shell.Current.GoToAsync("..");
            }
        }
    }
}
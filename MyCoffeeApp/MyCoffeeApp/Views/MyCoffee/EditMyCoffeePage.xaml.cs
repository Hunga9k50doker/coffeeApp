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
            name.Text = cf.Name;
            image.Text = cf.Image;
            price.Text = (cf.Price).ToString();
            detail.Text = cf.Detail;
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
                _coffee.Name = name.Text;
                _coffee.Image = image.Text;
                _coffee.Price = pr;
                _coffee.Detail = detail.Text;
                Console.WriteLine(_coffee.Name);
                App.CoffeeDb.EditCoffee(_coffee);
                await DisplayAlert("Thông báo", $"Sửa thành công!", "OK");
                    await Shell.Current.GoToAsync("..");
            }
        }
    }
}
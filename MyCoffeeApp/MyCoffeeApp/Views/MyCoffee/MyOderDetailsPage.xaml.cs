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
    public partial class MyOderDetailsPage : ContentPage
    {
        public List<Orders> listInit;
        public MyOderDetailsPage()
        {
            InitializeComponent();
            GetAllCf();
        }

        async void GetAllCf()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("http://coffeeapi.somee.com/api/Order/orders/" + ((App)App.Current).userId);
            listInit = JsonConvert.DeserializeObject<List<Orders>>(result);
            cvcOrderDetail.ItemsSource = listInit;
        }
       
     
        protected override  void OnAppearing()
        {
            base.OnAppearing();
            GetAllCf();
        }

        private void cvcOrderDetail_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Orders od = (Orders)e.SelectedItem;
            Navigation.PushAsync(new MyOderDetailItemPage(od.id));
        }
    }
}
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
    public partial class MyOderDetailItemPage : ContentPage
    {
        public List<orderDetails> listInit;

        public MyOderDetailItemPage(string id)
        {
            InitializeComponent();
            GetOderById(id);
        }
        async void GetOderById(string id)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("http://coffeeapi.somee.com/api/Order/order/" + id);
            var kqtv = JsonConvert.DeserializeObject<Orders>(result);
            listInit = kqtv.orderDetails;
            cvcOrderDetail.ItemsSource = listInit;
        }
    }
}
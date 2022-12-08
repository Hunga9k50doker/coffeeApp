using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderCell : ContentView
    {
        public OrderCell()
        {
            InitializeComponent();
        }

        private void Up_Clicked(object sender, EventArgs e)
        {
            int coutItems = int.Parse(count.Text);
            count.Text = (coutItems + 1).ToString();
        }

        private void Down_Clicked(object sender, EventArgs e)
        {
            if (int.Parse(count.Text) > 1)
            {
                int coutItems = int.Parse(count.Text);
                count.Text = (coutItems - 1).ToString();
            }

        }
    }
}
﻿using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Themes
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DarkTheme
    {
        public DarkTheme()
        {
            this.InitializeComponent();
        }
    }
}
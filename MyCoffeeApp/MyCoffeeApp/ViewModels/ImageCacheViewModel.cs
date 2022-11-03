using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace MyCoffeeApp.ViewModels
{
    public  class ImageCacheViewModel : ViewModelBase
    {
        public UriImageSource Image { get; set; } =
            new UriImageSource
            {
                Uri = new Uri("https://file.vfo.vn/hinh/2018/02/hinh-anh-cafe-dep-ly-cafe-ca-phe-sua-da-ca-phe-den-27.jpg"),
                CachingEnabled = true,
                CacheValidity = TimeSpan.FromMinutes(1)
            };

        public Command RefreshCommand { get; }

        public ImageCacheViewModel()
        {
            RefreshCommand = new Command(() =>
            {
                Image = new UriImageSource
                {
                    Uri = new Uri("https://file.vfo.vn/hinh/2018/02/hinh-anh-cafe-dep-ly-cafe-ca-phe-sua-da-ca-phe-den-27.jpg"),
                    CachingEnabled = true,
                    CacheValidity = TimeSpan.FromMinutes(1)
                };
                OnPropertyChanged(nameof(Image));
            });

            RefreshLongCommand = new AsyncCommand(async () =>
            {
                IsBusy = true;
                await Task.Delay(5000);
                IsBusy = false;
            });

        }

        public AsyncCommand RefreshLongCommand { get; }

    }
}

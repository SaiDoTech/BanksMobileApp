using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Extensions;
using XamarinApp.LangResource;
using XamarinApp.View.Pages;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static App CurrentApp { get; private set; }

        public App()
        {
            CurrentApp = this;

            InitializeComponent();

            if (Device.RuntimePlatform != Device.UWP)
            {
                Resource.Culture = DependencyService.Get<ILocalize>()
                                    .GetCurrentCultureInfo();
            }

            MainPage = new LoginPage();
        }

        public void GotLogged()
        {
            MainPage = new NoScrollTabbedPage();
        }
    }
}

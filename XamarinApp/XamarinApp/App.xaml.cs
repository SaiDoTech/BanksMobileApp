using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Controllers;
using XamarinApp.View.Pages;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static App CurrentApp { get; private set; }
        public static ThemeController ThemeController { get; private set; }
        public static FontController FontController { get; private set; }

        public App()
        {
            CurrentApp = this;
            ThemeController = new ThemeController();
            FontController = new FontController();

            InitializeComponent();

            MainPage = new LoginPage();
        }

        public void GotLogged()
        {
            MainPage = new NoScrollTabbedPage();
        }
    }
}

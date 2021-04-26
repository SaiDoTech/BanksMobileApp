using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.View.Pages;

namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NoScrollTabbedPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

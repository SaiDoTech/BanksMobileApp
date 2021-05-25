using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Controllers;
using XamarinApp.View;
using XamarinApp.View.Pages;

using XamarinApp.Model;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static App CurrentApp { get; private set; }
        public ThemeController ThemeController { get; private set; }
        public FontController FontController { get; private set; }
        public LanguageController LangController { get; private set; }
        public DBaseController DBaseController { get; private set; }
        public UserController UserController { get; private set; }

        public static UIBind UIBind; 

        public App()
        {
            CurrentApp = this;
            ThemeController = new ThemeController();
            FontController = new FontController();
            LangController = new LanguageController();

            DBaseController = new DBaseController("https://geolovemaps-default-rtdb.firebaseio.com/");

            UIBind = new UIBind(FontController, ThemeController);

            InitializeComponent();

            MainPage = new LoginPage();
        }

        public async void GotLoggedAsync(Bank currentBank)
        {
            UserController = new UserController(currentBank);
            this.UserController.Banks = await UserController.GetAllBanks();
            MainPage = new NoScrollTabbedPage();
        }
    }
}

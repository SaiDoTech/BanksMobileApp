using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.LangResource;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            tapGesture.Tapped += (s, e) =>
            {
                registryLabel.TextColor = App.CurrentApp.ThemeController.CurrentTheme.ActiveColor;
                Navigation.PushModalAsync(new RegistryPage());
            };
            registryLabel.GestureRecognizers.Add(tapGesture);
        }

        private void OnLogButtonClicked(object sender, EventArgs e)
        {
            App.CurrentApp.GotLogged();
        }

        protected override void OnAppearing()
        {
            ReColor();
            ReTranslate();
            ReFont();
        }

        public void ReColor()
        {
            this.BackgroundColor = App.CurrentApp.ThemeController.CurrentTheme.AddColor;

            loginEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;
            loginEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;

            keyEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;
            keyEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;

            loginButton.BackgroundColor = App.CurrentApp.ThemeController.CurrentTheme.ActiveColor;
            loginButton.TextColor = App.CurrentApp.ThemeController.CurrentTheme.BackColor;

            registryLabel.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;
        }

        public void ReTranslate()
        {
            loginEntry.Placeholder = Resource.Login_NameEntry_PH;
            keyEntry.Placeholder = Resource.Login_KeyEntry_PH;
            loginButton.Text = Resource.Login_LoginPutton_T;
            registryLabel.Text = Resource.Login_RegLabel_T;
        }

        public void ReFont()
        {
            loginEntry.FontFamily = App.CurrentApp.FontController.CurrentFont;
            keyEntry.FontFamily = App.CurrentApp.FontController.CurrentFont;
            loginButton.FontFamily = App.CurrentApp.FontController.CurrentFont;
            registryLabel.FontFamily = App.CurrentApp.FontController.CurrentFont;
        }
    }
}
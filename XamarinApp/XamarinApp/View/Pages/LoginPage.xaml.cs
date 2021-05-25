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

        private async void OnLogButtonClicked(object sender, EventArgs e)
        {
            var name = nameEntry.Text;
            var key = keyEntry.Text;

            var response = await App.CurrentApp.DBaseController.LogInBank(name, key);
            if (response != null)
            {
                App.CurrentApp.GotLoggedAsync(response);
            }
            else
            {
                await this.DisplayAlert("Alert", "Invalid name or key!", "Try again");
            }
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

            nameEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;
            nameEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;

            keyEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;
            keyEntry.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;

            loginButton.BackgroundColor = App.CurrentApp.ThemeController.CurrentTheme.ActiveColor;
            loginButton.TextColor = App.CurrentApp.ThemeController.CurrentTheme.BackColor;

            registryLabel.TextColor = App.CurrentApp.ThemeController.CurrentTheme.FontColor;
        }

        public void ReTranslate()
        {
            nameEntry.Placeholder = Resource.Login_NameEntry_PH;
            keyEntry.Placeholder = Resource.Login_KeyEntry_PH;
            loginButton.Text = Resource.Login_LoginPutton_T;
            registryLabel.Text = Resource.Login_RegLabel_T;
        }

        public void ReFont()
        {
            nameEntry.FontFamily = App.CurrentApp.FontController.CurrentFont;
            keyEntry.FontFamily = App.CurrentApp.FontController.CurrentFont;
            loginButton.FontFamily = App.CurrentApp.FontController.CurrentFont;
            registryLabel.FontFamily = App.CurrentApp.FontController.CurrentFont;
        }
    }
}
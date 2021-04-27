using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                registryLabel.TextColor = Color.FromHex("E72C28");
                Navigation.PushModalAsync(new RegistryPage());
            };
            registryLabel.GestureRecognizers.Add(tapGesture);
        }

        protected override void OnAppearing()
        {
            registryLabel.TextColor = Color.FromHex("040200");
        }

        private void OnLogButtonClicked(object sender, EventArgs e)
        {
            App.CurrentApp.GotLogged();
        }
    }
}
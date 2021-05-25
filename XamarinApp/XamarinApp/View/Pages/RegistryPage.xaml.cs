using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.LangResource;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistryPage : ContentPage
    {
        public RegistryPage()
        {
            InitializeComponent();

            ReTranslate();
        }

        public void ReTranslate()
        {
            latitudeEntry.Text = "53.900609";
            longitudeEntry.Text = "27.558953";

            registryLabel.Text = Resource.Registry_RegistryLabel_T;
            mainLabel.Text = Resource.Registry_MainLabel_T;
            nameLabel.Text = Resource.Registry_NameLabel_T + ": ";
            keyLabel.Text = Resource.Registry_KeyLabel_T + ": ";
            locationLabel.Text = Resource.Registry_LocationLabel_T;
            latitudeLabel.Text = Resource.Registry_LatitLabel_T + ": ";
            longitudeLabel.Text = Resource.Registry_LongLabel_T + ": ";
            registryButton.Text = Resource.Registry_RegButton_T;
        }

        protected override void OnAppearing()
        {
            ReTranslate();
        }

        private async void registryButton_ClickedAsync(object sender, EventArgs e)
        {
            var name = nameEntry.Text;
            var key = keyEntry.Text;
            var latitude = latitudeEntry.Text;
            var longitude = longitudeEntry.Text;

            try
            {
                var responce = await App.CurrentApp.DBaseController.CreateNewBank(name, key, new Xamarin.Forms.Maps.Position(Double.Parse(latitude), Double.Parse(longitude)));

                if (responce)
                {
                    await DisplayAlert("Congratulation!", "Successful registry!", "OK!");
                    await Navigation.PopModalAsync();
                }
                else
                    throw new Exception("Something went wrong!");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert!", ex.Message, "OK!");
            }
        }
    }
}
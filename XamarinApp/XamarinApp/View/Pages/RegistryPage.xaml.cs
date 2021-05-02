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
    public partial class RegistryPage : ContentPage
    {
        public RegistryPage()
        {
            InitializeComponent();

            ReTranslate();
        }

        public void ReTranslate()
        {
            registryLabel.Text = Resource.Registry_RegistryLabel_T;
            mainLabel.Text = Resource.Registry_MainLabel_T;
            nameLabel.Text = Resource.Registry_NameLabel_T + ": ";
            keyLabel.Text = Resource.Registry_KeyLabel_T + ": ";
            webLabel.Text = Resource.Registry_WebLabel_T + ": ";
            locationLabel.Text = Resource.Registry_LocationLabel_T;
            latitudeLabel.Text = Resource.Registry_LatitLabel_T + ": ";
            longitudeLabel.Text = Resource.Registry_LongLabel_T + ": ";
            registryButton.Text = Resource.Registry_RegButton_T;
        }

        protected override void OnAppearing()
        {
            ReTranslate();
        }
    }
}
﻿using System;
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

            ReTranslateAsync();
        }

        public async Task ReTranslateAsync()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                latitudeEntry.Text = location.Latitude.ToString();
                longitudeEntry.Text = location.Longitude.ToString();
            }

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
            ReTranslateAsync();
        }
    }
}
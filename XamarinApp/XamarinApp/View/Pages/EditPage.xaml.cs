using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Model;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EditPage(Bank bank)
        {
            InitializeComponent();

            nameEntry.Text = bank.Name;
            keyEntry.Text = bank.VerificationKey;
            latitudeEntry.Text = bank.Position.Latitude.ToString();
            longitudeEntry.Text = bank.Position.Longitude.ToString();
            buyEntry.Text = bank.Exchange.BuyPrice.ToString();
            sellEntry.Text = bank.Exchange.SellPrice.ToString();
            webEntry.Text = bank.WebSite;
            logoEntry.Text = bank.LogoPath;
            videoEntry.Text = bank.VideoUrl;

            currencyPicker.SelectedIndex = 0;
        }
    }
}
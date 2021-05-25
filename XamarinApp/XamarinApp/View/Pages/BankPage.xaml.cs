using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Model;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BankPage : ContentPage
    {
        public BankPage(Bank bank)
        {
            InitializeComponent();

            bankUserNameLabel.Text = bank.Name;
            bankUserWebLabel.Text = bank.WebSite;
            currencyLabel.Text = bank.Exchange.Currency;
            sellLabel.Text = bank.Exchange.SellPrice.ToString();
            buyLabel.Text = bank.Exchange.BuyPrice.ToString();

            if (bank.LogoPath == null)
            {
                bankLogoFrame.Content = new Image
                {
                    Source = ImageSource.FromResource("XamarinApp.View.Images.BankAppLogo.png"),
                    Aspect = Aspect.AspectFill
                };
            }
            else
            {
                bankLogoFrame.Content = new Image
                {
                    Source = ImageSource.FromUri(new Uri(bank.LogoPath)),
                    Aspect = Aspect.AspectFill
                };
            }

            TapGestureRecognizer webGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            webGesture.Tapped += (s, e) =>
            {
                ContentPage webPage = new ContentPage
                {
                    Content = new WebView
                    {
                        Source = new UrlWebViewSource { Url = "https://devblogs.microsoft.com/xamarin/" },
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }
                };

                Navigation.PushModalAsync(webPage);
            };
            bankUserWebLabel.GestureRecognizers.Add(webGesture);

            TapGestureRecognizer videoGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            videoGesture.Tapped += (s, e) =>
            {
                ContentPage videoPage = new ContentPage
                {
                    Content = new MediaElement
                    {
                        Source = "https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        AutoPlay = false
                    }
                };

                Navigation.PushModalAsync(videoPage);
            };
            bankVideoLabel.GestureRecognizers.Add(videoGesture);
        }
    }
}
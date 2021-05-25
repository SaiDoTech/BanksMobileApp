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
    public partial class TablePage : ContentPage
    {
        private byte viewMode = 0;

        public TablePage()
        {
            InitializeComponent();

            gridStack.IsVisible = false;
            gridStack.IsEnabled = false;

            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            tapGesture.Tapped += (s, e) =>
            {
                OnViewModelChanched();
                //Navigation.PushModalAsync(new BankPage());
            };
            viewLabel.GestureRecognizers.Add(tapGesture);
        }

        private void OnViewModelChanched()
        {
            if (viewMode == 0)
            {
                viewMode = 1;

                listStack.IsVisible = false;
                listStack.IsEnabled = false;

                gridStack.IsVisible = true;
                gridStack.IsEnabled = true;
            }
            else
            {
                viewMode = 0;

                listStack.IsVisible = true;
                listStack.IsEnabled = true;

                gridStack.IsVisible = false;
                gridStack.IsEnabled = false;
            }
        }
    }
}
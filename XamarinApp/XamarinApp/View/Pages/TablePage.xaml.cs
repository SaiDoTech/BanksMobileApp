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
        public TablePage()
        {
            InitializeComponent();

            sortPicker.SelectedIndex = 0;
            sortPicker.TextColor = Color.FromHex("040200");

            for (int i=0; i<10; i++)
            {
                var bankFrame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 0
                };

                bankStack.Children.Add(bankFrame);
            }
        }
    }
}
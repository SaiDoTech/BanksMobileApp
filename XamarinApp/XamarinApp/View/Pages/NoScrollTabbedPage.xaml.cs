using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoScrollTabbedPage : Xamarin.Forms.TabbedPage, IDynamicPage
    {
        public NoScrollTabbedPage()
        {
            InitializeComponent();

            this.CurrentPage = this.Children[this.Children.Count/2];

            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            ReColor();
        }

        public void ReColor()
        {
            this.BackgroundColor = App.ThemeController.CurrentTheme.BackColor;
            this.SelectedTabColor = App.ThemeController.CurrentTheme.ActiveColor;
            this.UnselectedTabColor = App.ThemeController.CurrentTheme.FontColor;
        }

        public void ReFont()
        {
        }

        public void ReTranslate()
        {
        }
    }
}
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
    public partial class SettingsPage : ContentPage, IDynamicPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            foreach (var font in App.FontController.AppFonts)
            {
                fontPicker.Items.Add(font);
            }
            fontPicker.SelectedIndex = 0;

            foreach (var theme in App.ThemeController.AppThemes)
            {
                themePicker.Items.Add(theme.Title);
            }
            themePicker.SelectedIndex = 0;

            settingsPicker.SelectedIndex = 0;
            settingsPicker.TextColor = App.ThemeController.CurrentTheme.FontColor;

            ReTranslate();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
        }

        private void fontPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.FontController.ChangeFont(fontPicker.SelectedIndex);

            ReFont();
        }

        public void ReFont()
        {
            settingsPicker.FontFamily = App.FontController.CurrentFont;

            fontLabel.FontFamily = App.FontController.CurrentFont;
        }

        public void ReTranslate()
        {

        }

        public void ReColor()
        {

        }
    }
}
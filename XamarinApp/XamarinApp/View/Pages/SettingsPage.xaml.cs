using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Controllers;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public static UIBind uIBind;

        public SettingsPage()
        {
            uIBind = new UIBind(App.FontController, App.LangController, App.ThemeController);

            InitializeComponent();

            foreach (var lang in uIBind.languageController.AppLanguages)
            {
                langPicker.Items.Add(lang.Title);
            }
            langPicker.SelectedIndex = 0;

            foreach (var theme in uIBind.themeController.AppThemes)
            {
                themePicker.Items.Add(theme.Title);
            }
            themePicker.SelectedIndex = 0;

            foreach (var font in uIBind.fontController.AppFonts)
            {
                fontPicker.Items.Add(font);
            }
            fontPicker.SelectedIndex = 0;

            settingsPicker.SelectedIndex = 0;

            signLabel.Text = decimalStepper.Value.ToString();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            signLabel.Text = decimalStepper.Value.ToString();
        }

        private void fontPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            uIBind.fontController.ChangeFont(fontPicker.SelectedIndex);
            uIBind.OnPropertyChanged("CurrentFont");
        }

        private void langPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            uIBind.languageController.SetNewCulture(langPicker.SelectedIndex);
        }

        private void themePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            uIBind.themeController.ChangeTheme(themePicker.SelectedIndex);
            uIBind.OnPropertyChanged("FontColor");
            uIBind.OnPropertyChanged("BackColor");
            uIBind.OnPropertyChanged("AddColor");
        }
    }
}
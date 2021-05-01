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
        public static FontController fontController;
        public static LanguageController languageController;

        public SettingsPage()
        {
            fontController = App.FontController;
            languageController = App.LangController;

            InitializeComponent();

            foreach (var lang in languageController.AppLanguages)
            {
                langPicker.Items.Add(lang.Title);
            }
            langPicker.SelectedIndex = 0;

            foreach (var theme in App.ThemeController.AppThemes)
            {
                themePicker.Items.Add(theme.Title);
            }
            themePicker.SelectedIndex = 0;

            foreach (var font in fontController.AppFonts)
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
            fontController.ChangeFont(fontPicker.SelectedIndex);
        }

        private void langPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            languageController.SetNewCulture(langPicker.SelectedIndex);
        }
    }
}
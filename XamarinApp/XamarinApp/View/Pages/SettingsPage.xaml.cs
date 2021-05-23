using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Controllers;
using XamarinApp.LangResource;

namespace XamarinApp.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            foreach (var lang in App.CurrentApp.LangController.AppLanguages)
            {
                langPicker.Items.Add(lang.Title);
            }
            langPicker.SelectedIndex = 0;

            foreach (var theme in App.UIBind.themeController.AppThemes)
            {
                themePicker.Items.Add(theme.Title);
            }
            themePicker.SelectedIndex = 0;

            foreach (var font in App.UIBind.fontController.AppFonts)
            {
                fontPicker.Items.Add(font);
            }
            fontPicker.SelectedIndex = 0;


            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            tapGesture.Tapped += (s, e) =>
            {
                Navigation.PushModalAsync(new EditPage());
            };
            changeLabel.GestureRecognizers.Add(tapGesture);

            ReTranslate();
        }

        protected override void OnAppearing()
        {
            ReTranslate();
        }

        private void ReTranslate()
        {
            settingsLabel.Text = Resource.Settings_SettLabel_T;
            interfaceLabel.Text = Resource.Settings_IntfLable_T;
            langLabel.Text = Resource.Settings_LangLabel_T + ": ";
            fontLabel.Text = Resource.Settings_FontLabel_T + ": ";
            themeLabel.Text = Resource.Settings_ThemeLabel_T + ": ";
            accountLabel.Text = Resource.Settings_AccountLabel_T;
            changeLabel.Text = Resource.Settings_ChangeLabel_T; 
        }

        private void fontPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.UIBind.fontController.ChangeFont(fontPicker.SelectedIndex);
            App.UIBind.OnPropertyChanged("CurrentFont");
        }

        private void langPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.CurrentApp.LangController.SetNewCulture(langPicker.SelectedIndex);
            ReTranslate();
        }

        private void themePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.UIBind.themeController.ChangeTheme(themePicker.SelectedIndex);
            App.UIBind.OnPropertyChanged("FontColor");
            App.UIBind.OnPropertyChanged("BackColor");
            App.UIBind.OnPropertyChanged("AddColor");
            App.UIBind.OnPropertyChanged("ActiveColor");
        }
    }
}
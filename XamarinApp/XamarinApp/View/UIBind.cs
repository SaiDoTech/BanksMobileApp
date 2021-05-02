using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Controllers;
using System.ComponentModel;
using Xamarin.Forms;
using System.Globalization;

namespace XamarinApp.View
{
    public class UIBind : INotifyPropertyChanged
    {
        public FontController fontController { get; private set; }
        public ThemeController themeController { get; private set; }

        public string CurrentFont
        {
            get { return fontController.CurrentFont; }
            set
            {
                if (fontController.CurrentFont != value)
                {
                    fontController.CurrentFont = value;
                    OnPropertyChanged("CurrentFont");
                }
            }
        }

        public Color BackColor
        {
            get { return themeController.CurrentTheme.BackColor; }
            set
            {
                if (themeController.CurrentTheme.BackColor != value)
                {
                    themeController.CurrentTheme.BackColor = value;
                    OnPropertyChanged("BackColor");
                }
            }
        }

        public Color AddColor
        {
            get { return themeController.CurrentTheme.AddColor; }
            set
            {
                if (themeController.CurrentTheme.AddColor != value)
                {
                    themeController.CurrentTheme.AddColor = value;
                    OnPropertyChanged("AddColor");
                }
            }
        }
        public Color FontColor
        {
            get { return themeController.CurrentTheme.FontColor; }
            set
            {
                if (themeController.CurrentTheme.FontColor != value)
                {
                    themeController.CurrentTheme.FontColor = value;
                    OnPropertyChanged("FontColor");
                }
            }
        }

        public Color ActiveColor
        {
            get { return themeController.CurrentTheme.ActiveColor; }
            set
            {
                if (themeController.CurrentTheme.ActiveColor != value)
                {
                    themeController.CurrentTheme.ActiveColor = value;
                    OnPropertyChanged("ActiveColor");
                }
            }
        }

        public UIBind(FontController fontController,
                      ThemeController themeController)
        {
            if ((fontController != null) && (themeController != null))
            {
                this.fontController = fontController;
                this.themeController = themeController;
            }
            else
                throw new ArgumentNullException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

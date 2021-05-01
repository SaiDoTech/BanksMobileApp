using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace XamarinApp.Controllers
{
    public class FontController : INotifyPropertyChanged
    {
        private string currentFont;

        public List<string> AppFonts { get; private set; }

        public string CurrentFont
        {
            get { return currentFont; }
            set
            {
                if (currentFont != value)
                {
                    currentFont = value;
                    OnPropertyChanged("CurrentFont");
                }
            }
        }

        public FontController()
        {
            AppFonts = new List<string>()
            {
                "Arial",
                "Kirucoupage",
                "Lobster"
            };

            currentFont = AppFonts[0];
            OnPropertyChanged("CurrentFont");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void ChangeFont(int indx)
        {
            if ((indx >= 0) && (indx < AppFonts.Count))
            {
                CurrentFont = AppFonts[indx];
                OnPropertyChanged("CurrentFont");
            }
        }
    }
}

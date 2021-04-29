using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinApp.View;

namespace XamarinApp.Controllers
{
    public class ThemeController
    {
        public AppTheme CurrentTheme { get; private set; }

        public List<AppTheme> AppThemes { get; private set; }

        public ThemeController()
        {
            var themeLight = new AppTheme("Light", Color.FromHex("fafafa"), Color.FromHex("#E3000E"), Color.FromHex("222222"));
            var themeDark = new AppTheme("Dark", Color.FromHex("222222"), Color.FromHex("#E3000E"), Color.FromHex("BDBFAC"));

            AppThemes = new List<AppTheme>()
            {
                themeLight,
                themeDark
            };

            CurrentTheme = AppThemes[0];
        }

        public void ChangeTheme(int indx)
        {
            CurrentTheme = AppThemes[indx];
        }
    }
}

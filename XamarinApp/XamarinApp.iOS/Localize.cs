using Foundation;
using Xamarin.Forms;
using XamarinApp.Extensions;

[assembly: Dependency(typeof(XamarinApp.iOS.Localize))]

namespace XamarinApp.iOS
{
    class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var prefLanguage = "en-US";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-"); // заменяет pt_BR на pt-BR
            }
            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch
            {
                ci = new System.Globalization.CultureInfo(prefLanguage);
            }
            return ci;
        }
    }
}
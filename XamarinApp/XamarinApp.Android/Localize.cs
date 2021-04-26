using Xamarin.Forms;
using XamarinApp.Extensions;

[assembly: Dependency(typeof(XamarinApp.Droid.Localize))]

namespace XamarinApp.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}
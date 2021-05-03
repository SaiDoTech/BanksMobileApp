using System;
using System.Collections.Generic;
using XamarinApp.LangResource;
using XamarinApp.View;

namespace XamarinApp.Controllers
{
    public class LanguageController
    {
        public List<AppLanguage> AppLanguages { get; private set; }

        public LanguageController()
        {
            var eng = new AppLanguage("English", "en-us");
            var ru = new AppLanguage("Русский", "ru-ru");
            var by = new AppLanguage("Беларуская", "be-BY");

            AppLanguages = new List<AppLanguage>()
            {
                eng,
                ru,
                by
            };

            Resource.Culture = new System.Globalization.CultureInfo(AppLanguages[0].CI);
        }

        public void SetNewCulture(int indx)
        {
            Resource.Culture = new System.Globalization.CultureInfo(AppLanguages[indx].CI);
        }
    }
}
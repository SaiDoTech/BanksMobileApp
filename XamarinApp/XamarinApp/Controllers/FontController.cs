using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Controllers
{
    public class FontController
    {
        public string CurrentFont { get; private set; }

        public List<string> AppFonts { get; private set; }

        public FontController()
        {
            AppFonts = new List<string>()
            {
                "Arial",
                "Helvetica",
                "Kirucoupage",
                "Lobster"
            };

            CurrentFont = AppFonts[0];
        }

        public void ChangeFont(int indx)
        {
            if ((indx >= 0) && (indx < AppFonts.Count))
                CurrentFont = AppFonts[indx];
        }
    }
}

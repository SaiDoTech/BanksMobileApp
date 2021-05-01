using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace XamarinApp.Controllers
{
    public class FontController
    {
        public string CurrentFont { get; set; }

        public List<string> AppFonts { get; private set; }

        public FontController()
        {
            AppFonts = new List<string>()
            {
                "Arial",
                "Kirucoupage",
                "Lobster"
            };

            CurrentFont = AppFonts[0];
        }

        public void ChangeFont(int indx)
        {
            if ((indx >= 0) && (indx < AppFonts.Count))
            {
                CurrentFont = AppFonts[indx];
            }
        }
    }
}

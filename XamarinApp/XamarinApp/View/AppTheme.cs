using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinApp.View
{
    public class AppTheme
    {
        public string Title { get; private set; }
        public Color BackColor { get; set; }
        public Color AddColor { get; set; }
        public Color ActiveColor { get; set; }
        public Color FontColor { get; set; }

        public AppTheme(string title, Color back, Color add, Color act, Color font)
        {
            Title = title;
            BackColor = back;
            AddColor = add;
            ActiveColor = act;
            FontColor = font;
        }
    }
}

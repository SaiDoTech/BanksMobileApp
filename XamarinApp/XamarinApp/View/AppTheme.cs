using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinApp.View
{
    public class AppTheme
    {
        public string Title { get; private set; }
        public Color BackColor { get; private set; }
        public Color ActiveColor { get; private set; }
        public Color FontColor { get; private set; }

        public AppTheme(string title, Color back, Color act, Color font)
        {
            Title = title;
            BackColor = back;
            ActiveColor = act;
            FontColor = font;
        }
    }
}

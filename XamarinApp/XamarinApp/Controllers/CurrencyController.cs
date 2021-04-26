using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Controllers
{
    class CurrencyController
    {
        public List<string> currencies { get; private set;}

        public CurrencyController()
        {
            currencies = new List<string>();

            currencies.Add("BYN");
            currencies.Add("USD");
            currencies.Add("EU");
        }
    }
}

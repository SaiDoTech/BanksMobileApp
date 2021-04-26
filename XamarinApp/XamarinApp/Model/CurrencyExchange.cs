using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Model
{
    class CurrencyExchange
    { 
        public string CurrentCurrency { get; private set; }
        public string AnotherCurrency { get; private set; }
        public decimal BuyAnother { get; private set; }
        public decimal SellAnother { get; private set; }

        public CurrencyExchange(string current, string target, decimal buy, decimal sell)
        {
            if ( !(string.IsNullOrWhiteSpace(current)) && (current != null))
                CurrentCurrency = current;
            else
                throw new Exception("Wrong format for current currency!");

            if (!(string.IsNullOrWhiteSpace(target)) && (target != null))
                AnotherCurrency = target;
            else
                throw new Exception("Wrong format for target currency!");

            if (buy > 0)
                BuyAnother = buy;
            else
                throw new Exception("Wrong format for buy price currency!");

            if (sell > 0)
                SellAnother = sell;
            else
                throw new Exception("Wrong format for sell price currency!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Model
{
    public class CurrencyExchange
    { 
        public string Currency { get; private set; }
        public decimal BuyPrice { get; private set; }
        public decimal SellPrice { get; private set; }

        public CurrencyExchange(string currency, decimal buy, decimal sell)
        {
            if (!(string.IsNullOrWhiteSpace(currency)) && (currency != null))
                this.Currency = currency;
            else
                throw new Exception("Wrong format for currency!");

            if (buy >= 0)
                BuyPrice = buy;
            else
                throw new Exception("Wrong format for buy price currency!");

            if (sell >= 0)
                SellPrice = sell;
            else
                throw new Exception("Wrong format for sell price currency!");
        }
    }
}

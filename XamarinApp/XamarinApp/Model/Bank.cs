using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace XamarinApp.Model
{
    class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VerificationKey { get; set; }

        public Position Location { get; set; }
        public string LogoPath { get; set; }

        public List<CurrencyExchange> exchanges { get; set; }


        public Bank(int id,
                    string name,
                    string verificationKey,
                    Position location,
                    List<CurrencyExchange> currencies)
        {
            if (id > 0)
                this.Id = id;
            else
                throw new Exception("Wrong Id!");

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
                this.Name = name;
            else
                throw new Exception("Please, enter Bank's name!");

            if (!string.IsNullOrEmpty(verificationKey) && !string.IsNullOrWhiteSpace(verificationKey))
                this.VerificationKey = verificationKey;
            else
                throw new Exception("Please, enter Verification key!");

            if (location != null)
                this.Location = location;
            else
                throw new Exception("Please, enter Bank's location!");

            this.LogoPath = null;

            if (currencies.Count > 0)
            {
                exchanges = new List<CurrencyExchange>();
                foreach (var currency in currencies)
                {
                    if (currency != null)
                    {
                        this.exchanges.Add(currency);
                    }
                    else
                        throw new Exception("Wrong currency format!");
                }
            }
        }
    }
}

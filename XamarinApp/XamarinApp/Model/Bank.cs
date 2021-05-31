using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace XamarinApp.Model
{
    public class Bank
    {
        // System
        public int Id { get; set; }
        public string Name { get; set; }
        public string VerificationKey { get; set; }

        // Info
        public string WebSite { get; set; }
        public Position Position { get; set; }
        public CurrencyExchange Exchange { get; set; }

        // Media
        public string LogoPath { get; set; }
        public string VideoUrl { get; set; }

        // When Log In
        public Bank(int id, string name, string verificationKey, Position position,
                    CurrencyExchange exchange, string webSite, string logoPath, string videoUrl)
        {
            Id = id;
            Name = name;
            VerificationKey = verificationKey;
            Position = position;
            Exchange = exchange;
            WebSite = webSite;
            LogoPath = logoPath;
            VideoUrl = videoUrl;
        }

        // When Create New Bank
        public Bank(int id, string name, string key, Position position)
        {
            if (id > 0)
                this.Id = id;
            else
                throw new Exception("Wrong Id!");

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
                this.Name = name;
            else
                throw new Exception("Please, enter Bank's name!");

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
                this.VerificationKey = key;
            else
                throw new Exception("Please, enter Verification key!");
            if (position != null)
                this.Position = position;

            WebSite = null;
            Exchange = new CurrencyExchange("USD", (decimal)0.0, (decimal)0.0);
            LogoPath = null;
            VideoUrl = null;
        }

        public Bank()
        {

        }
    }
}

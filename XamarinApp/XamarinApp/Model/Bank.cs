using System;
using System.Collections.Generic;
using System.Text;
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
        public Position Location { get; set; }
        public List<CurrencyExchange> exchanges { get; set; }

        // Media
        public string LogoPath { get; set; }
        public string VideoUrl { get; set; }

        public Bank(int id,
                    string name,
                    string verificationKey,
                    string website,
                    Position location)
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

            if (!string.IsNullOrEmpty(website) && !string.IsNullOrWhiteSpace(website))
                this.WebSite = website;
            else
                throw new Exception("Please, enter Web Site!");

            if (location != null)
                this.Location = location;
            else
                throw new Exception("Please, enter Bank's location!");

            this.LogoPath = null;
        }

        public Bank(int id,
                    string name,
                    string verificationKey,
                    string website,
                    Position location,
                    string logopath) : this(id, name, verificationKey, website, location)
        {
            this.LogoPath = logopath;
        }

        public Bank()
        {

        }
    }
}

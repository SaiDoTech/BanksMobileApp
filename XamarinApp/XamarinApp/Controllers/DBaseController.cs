using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms.Maps;
using XamarinApp.Model;

namespace XamarinApp.Controllers
{
    public class DBaseController
    {
        public FirebaseClient firebaseClient { get; private set; }
        private const string BanksTable = "Banks"; 

        public DBaseController(string key)
        {
            firebaseClient = new FirebaseClient(key);
        }

        public async Task<Bank> LogInBank(string name, string key)
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child(BanksTable)
                    .OnceAsync<Bank>()).Where(a => a.Object.Name == name).
                                        Where(b => b.Object.VerificationKey == key).FirstOrDefault();

                if (gotted != null)
                {
                    Bank bank = new Bank(gotted.Object.Id, gotted.Object.Name,
                                         gotted.Object.VerificationKey, gotted.Object.Position, gotted.Object.Exchange,
                                         gotted.Object.WebSite, gotted.Object.LogoPath, gotted.Object.VideoUrl);
                    return bank;
                }
            }
            return null;
        }

        public async Task<int> GetBanksCount()
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child(BanksTable)
                    .OnceAsync<Bank>()).Count;
                return gotted;
            }
            return 0;
        }

        public async Task<bool> RegBank(Bank bank)
        {
            if ((bank != null) && (firebaseClient != null))
            {
                await firebaseClient
                    .Child(BanksTable)
                    .PostAsync(bank);

                return true;
            }
            else
                return false;
        }

        public async Task<List<Bank>> GetAllBanks()
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child(BanksTable)
                    .OnceAsync<Bank>()).Select(bank => new Bank
                    {
                        Id = bank.Object.Id,
                        Name = bank.Object.Name,
                        VerificationKey = bank.Object.VerificationKey,
                        Position = bank.Object.Position,
                        WebSite = bank.Object.WebSite,
                        LogoPath = bank.Object.LogoPath,
                        Exchange = bank.Object.Exchange,
                        VideoUrl = bank.Object.VideoUrl
                    }).ToList();

                if (gotted != null)
                {
                    return new List<Bank>(gotted);
                }
            }
            return null;
        }

        public async Task<bool> IsNameFree(string name)
        {
            if (firebaseClient != null)
            {
                var gotted = (await firebaseClient
                    .Child(BanksTable)
                    .OnceAsync<Bank>()).Where(a => a.Object.Name == name).FirstOrDefault();

                if (gotted != null)
                    return false;
            }
            return true;
        }

        public async Task<bool> UpdateBank(Bank bank)
        {
            if ((bank != null) && (firebaseClient != null))
            {
                var deleted = (await firebaseClient
                    .Child(BanksTable)
                    .OnceAsync<Bank>()).Where(a => a.Object.Id == bank.Id).FirstOrDefault();
                await firebaseClient.Child(BanksTable).Child(deleted.Key).DeleteAsync();

                if (deleted.Object != null)
                {
                    await firebaseClient.Child(BanksTable).PostAsync(bank);

                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
                return false;
        }
    
        public async Task<bool> CreateNewBank(string name, string key, Position position)
        {
            var response = await this.IsNameFree(name);

            if (response)
            {
                var id = await this.GetBanksCount();
                id++;

                var bank = new Model.Bank(id, name, key, position);

                var registered = await this.RegBank(bank);
                if (registered)
                    return true;
                else
                    return false;
            }
            else
            {
                throw new Exception("Sorry, but this name is already taken!");
            }
        }

    }
}

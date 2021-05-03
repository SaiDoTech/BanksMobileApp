using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
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
                                         gotted.Object.VerificationKey, gotted.Object.WebSite,
                                         gotted.Object.Location, gotted.Object.LogoPath);
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
                        WebSite = bank.Object.WebSite,
                        Location = bank.Object.Location,
                        LogoPath = bank.Object.LogoPath
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
                    .OnceAsync<Bank>()).Where(a => a.Object.Name == bank.Name).FirstOrDefault();
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
    }
}

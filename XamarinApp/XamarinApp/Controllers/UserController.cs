using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Model;

namespace XamarinApp.Controllers
{
    public class UserController
    {
        public Bank CurrentBank { get; private set; }
        public List<Bank> Banks { get; set; }

        public UserController(Bank bank)
        {
            if (bank != null)
                CurrentBank = bank;
        }

        public UserController()
        {
        }

        public async Task<List<Bank>> GetAllBanks()
        {
            return await App.CurrentApp.DBaseController.GetAllBanks();
        }
    }
}

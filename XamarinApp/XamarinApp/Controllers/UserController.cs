using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

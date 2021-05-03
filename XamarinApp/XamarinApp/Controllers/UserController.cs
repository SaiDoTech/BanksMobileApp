using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Model;

namespace XamarinApp.Controllers
{
    class UserController
    {
        public static Bank CurrentBank { get; private set; }

        public UserController(Bank bank)
        {
            if (bank != null)
                CurrentBank = bank;
        }

    }
}

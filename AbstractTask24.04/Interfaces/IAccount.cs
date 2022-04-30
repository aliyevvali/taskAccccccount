using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractTask24._04.Interfaces
{
    interface IAccount
    {
        bool PasswordChecker(string password);
        void ShowInfo();
    }
}

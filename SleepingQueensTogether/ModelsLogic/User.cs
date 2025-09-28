using SleepingQueensTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.ModelsLogic
{
    internal class User : UserModel
    {
        public override bool IsRegistered => !string.IsNullOrWhiteSpace(Preferences.Get(Keys.UsernameKey, string.Empty));
        public override void Register()
        {
            Preferences.Set(Keys.UsernameKey, Username);
            Preferences.Set(Keys.GmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
        }
        public override bool Login()
        {
            return true;
        }
    }
}

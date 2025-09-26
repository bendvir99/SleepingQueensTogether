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
        public override void Register()
        {
            Preferences.Set(Keys.UsernameKey, Username);
        }

        public User()
        {
            Preferences.Get(Keys.UsernameKey, string.Empty);
        }
    }
}

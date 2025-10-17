using SleepingQueensTogether.ModelsLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.Models
{
    internal abstract class UserModel
    {
        protected FbData fbd = new();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EventHandler? OnAuthenticationComplete;
        public bool RememberMe { get; set; } = Preferences.Get(Keys.RememberMeKey, false);
        public abstract bool IsRegistered { get; }
        public abstract void Register();
        public abstract void RegisterGoogle();
        public abstract void Login();
    }
}

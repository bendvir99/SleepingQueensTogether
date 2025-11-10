using SleepingQueensTogether.ModelsLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SleepingQueensTogether.Models
{
    internal abstract class UserModel
    {
        protected FbData fbd = new();
        protected enum Actions { Register, Login }
        protected Actions CurrentAction = Actions.Login;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public EventHandler<bool>? OnAuthenticationComplete;
        public bool RememberMe { get; set; } = Preferences.Get(Keys.RememberMeKey, false);
        public bool IsBusy { get; protected set; } = false;
        public bool IsRegistered => !string.IsNullOrWhiteSpace(Preferences.Get(Keys.GmailKey, string.Empty));
        public abstract void Register();
        public abstract bool IsValidRegister();
        public abstract bool IsValidLogin();
        public abstract void RegisterGoogle();
    }
}

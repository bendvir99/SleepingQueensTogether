using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.ModelsLogic
{
    internal class User : UserModel
    {
        public override bool IsRegistered => !string.IsNullOrWhiteSpace(Preferences.Get(Keys.UsernameKey, string.Empty));
        public override void Register()
        {
            fbd.CreateUserWithEmailAndPasswordAsync(Email, Password, Username, OnComplete);
        }

        private void OnComplete(Task task)
        {
            if (task.IsCompletedSuccessfully)
                SaveToPreferences();
            else
                Username = string.Empty;
                Email = string.Empty;
                Password = string.Empty;
        }

        private void SaveToPreferences()
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

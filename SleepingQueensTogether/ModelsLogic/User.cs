using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.ModelsLogic
{
    internal class User : UserModel
    {
        public override bool IsRegistered => !string.IsNullOrWhiteSpace(Preferences.Get(Keys.GmailKey, string.Empty));
        public override void Register()
        {
            fbd.CreateUserWithEmailAndPasswordAsync(Email, Password, Username,OnCompleteRegister);
        }
        public override void RegisterGoogle()
        {
            //fbd.SignInWithGoogleAsync(OnComplete);
        }

        private void ShowAlert(string message)
        {
            message = fbd.GetErrorMessage(message);
            ToastMake(message);
        }

        private void OnCompleteRegister(Task task)
        {
            if (task.IsCompletedSuccessfully)
            {
                SaveToPreferences();
                OnAuthenticationComplete?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                if (task.Exception != null)
                {
                    Exception ex = task.Exception.InnerException ?? task.Exception;

                    ShowAlert(ex.Message);

                }
                Username = string.Empty;
                Email = string.Empty;
                Password = string.Empty;
            }
        }
        private void OnCompleteLogin(Task task)
        {
            if (task.IsCompletedSuccessfully)
            {
                SaveToPreferences();
                OnAuthenticationComplete?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ToastMake(Strings.LoginFailedError);
                Username = string.Empty;
                Email = string.Empty;
                Password = string.Empty;

            }
        }

        private void SaveToPreferences()
        {
            Preferences.Set(Keys.UsernameKey, Username);
            Preferences.Set(Keys.GmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
            Preferences.Set(Keys.RememberMeKey, RememberMe);
        }

        public override void Login()
        {
            fbd.SignInWithEmailAndPasswordAsync(Email, Password, OnCompleteLogin);
        }

        public static void ToastMake(string message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Toast.Make(message, ToastDuration.Long).Show();
            });
        }
    }
}

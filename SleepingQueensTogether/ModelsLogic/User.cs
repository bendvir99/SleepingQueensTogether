using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SleepingQueensTogether.Models;
using SleepingQueensTogether.ViewModels;

namespace SleepingQueensTogether.ModelsLogic
{
    internal class User : UserModel
    {
        public override void Register()
        {
            IsBusy = true;
            CurrentAction = Actions.Register;
            fbd.CreateUserWithEmailAndPasswordAsync(Email, Password, Name,OnCompleteRegister);
        }
        public void Login()
        {
            IsBusy = true;
            
            fbd.SignInWithEmailAndPasswordAsync(Email, Password, OnCompleteLogin);
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
            IsBusy = false;
            if (task.IsCompletedSuccessfully)
            {
                SaveToPreferences();
                OnAuthenticationComplete?.Invoke(this, true);
            }
            else
            {
                if (task.Exception != null)
                {
                    Exception ex = task.Exception.InnerException ?? task.Exception;

                    ShowAlert(ex.Message);
                    OnAuthenticationComplete?.Invoke(this, false);

                }
                Name = string.Empty;
                Email = string.Empty;
                Password = string.Empty;
            }
        }
        private void OnCompleteLogin(Task task)
        {
            IsBusy = false;
            if (task.IsCompletedSuccessfully)
            {
                SaveToPreferences();
                OnAuthenticationComplete?.Invoke(this, true);
            }
            else
            {
                ToastMake(Strings.LoginFailedError);
                OnAuthenticationComplete?.Invoke(this, false);
                Name = string.Empty;
                Email = string.Empty;
                Password = string.Empty;

            }
        }

        public void SaveToPreferences()
        {
            Preferences.Set(Keys.UsernameKey, Name);
            Preferences.Set(Keys.GmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
            Preferences.Set(Keys.RememberMeKey, RememberMe);
        }
        public override bool IsValidRegister()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email);
        }
        public override bool IsValidLogin()
        {
            return !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email);
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

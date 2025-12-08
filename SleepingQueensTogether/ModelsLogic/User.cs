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
        public override void Login()
        {
            IsBusy = true;
            
            fbd.SignInWithEmailAndPasswordAsync(Email, Password, OnCompleteLogin);
        }
        public override void ResetPassword(string email)
        {
            IsBusy = true;

            fbd.ResetPasswordWithEmail(email, OnCompleteResetPassword);
        }
        public override void RegisterGoogle()
        {
            //fbd.SignInWithGoogleAsync(OnComplete);
        }

        protected override void ShowAlert(string message)
        {
            message = fbd.GetErrorMessage(message);
            General.ToastMake(message);
        }

        protected override void OnCompleteRegister(Task task)
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
        protected override void OnCompleteLogin(Task task)
        {
            IsBusy = false;
            if (task.IsCompletedSuccessfully)
            {
                SaveToPreferences();
                OnAuthenticationComplete?.Invoke(this, true);
            }
            else
            {
                General.ToastMake(Strings.LoginFailedError);
                OnAuthenticationComplete?.Invoke(this, false);
                Name = string.Empty;
                Email = string.Empty;
                Password = string.Empty;

            }
        }
        protected override void OnCompleteResetPassword(Task task)
        {
            IsBusy = false;
            if (!task.IsCompletedSuccessfully)
            {
                if (task.Exception != null)
                {
                    Exception ex = task.Exception.InnerException ?? task.Exception;
                    Console.WriteLine(ex);
                }
                General.ToastMake(Strings.ResetPasswordFailed);
            }
        }

        public override void SaveToPreferences()
        {
            Preferences.Set(Keys.UsernameKey, Name);
            Preferences.Set(Keys.GmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
            Preferences.Set(Keys.RememberMeKey, RememberMe);
        }
        public override bool IsValidRegister()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email) && !IsBusy;
        }
        public override bool IsValidLogin()
        {
            return !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email) && !IsBusy;
        }

        
    }
}

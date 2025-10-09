using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.ModelsLogic
{
    internal class User : UserModel
    {
        public override bool IsRegistered => !string.IsNullOrWhiteSpace(Preferences.Get(Keys.UsernameKey, string.Empty));
        public override void Register()
        {
            fbd.CreateUserWithEmailAndPasswordAsync(Email, Password, Username,OnCompleteRegister);
        }
        public override void RegisterGoogle()
        {
            //fbd.SignInWithGoogleAsync(OnComplete);
        }

        private void OnCompleteRegister(Task task)
        {
            if (task.IsCompletedSuccessfully)
                SaveToPreferences();
            else
            {
                if (task.Exception != null)
                {
                    Exception ex = task.Exception.InnerException ?? task.Exception;

                    Console.WriteLine(ex.Message);

                    if (ex.Message.Contains(Strings.InvalidEmail))
                    {
                        MainThread.BeginInvokeOnMainThread(async () =>
                        {
                            if (Application.Current?.MainPage != null)
                                await Application.Current.MainPage.DisplayAlert(Strings.RegisterFailed, Strings.RegisterFailedInvalidEmail, Strings.OK);
                        });
                    }
                    else if (ex.Message.Contains(Strings.EmailExists))
                    {
                        MainThread.BeginInvokeOnMainThread(async () =>
                        {
                            if (Application.Current?.MainPage != null)
                                await Application.Current.MainPage.DisplayAlert(Strings.RegisterFailed, Strings.RegisterFailedEmailExists, Strings.OK);
                        });
                    }
                    else if (ex.Message.Contains(Strings.WeakPassword))
                    {
                        MainThread.BeginInvokeOnMainThread(async () =>
                        {
                            if (Application.Current?.MainPage != null)
                                await Application.Current.MainPage.DisplayAlert(Strings.RegisterFailed, Strings.RegisterFailedWeakPassword, Strings.OK);
                        });
                    }
                }

                Username = string.Empty;
                Email = string.Empty;
                Password = string.Empty;
            }
        }
        private void OnCompleteLogin(Task task)
        {
            if (task.IsCompletedSuccessfully)
                SaveToPreferences();
            else
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (Application.Current?.MainPage != null)
                        await Application.Current.MainPage.DisplayAlert(Strings.LoginFailed, Strings.LoginFailedError, Strings.OK);
                });

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
        }

        public override void Login()
        {
            fbd.SignInWithEmailAndPasswordAsync(Email, Password, OnCompleteLogin);
        }
    }
}

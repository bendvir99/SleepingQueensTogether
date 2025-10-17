using SleepingQueensTogether.Models;
using SleepingQueensTogether.ModelsLogic;
using System.Windows.Input;

namespace SleepingQueensTogether.ViewModels
{
    class LoginPageVM : ObservableObject
    {
        private readonly User user = new();
        public ICommand LoginCommand { get; }
        public ICommand ToggleIsPasswordCommand { get; }
        public bool IsBusy { get; set; } = false;
        public bool IsPassword { get; set; } = true;
        public bool RememberMe
        {
            get => user.RememberMe;
            set => user.RememberMe = value;
        }
        public string Password
        {
            get => user.Password;
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    (LoginCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        public string Email
        {
            get => user.Email;
            set
            {
                if (user.Email != value)
                {
                    user.Email = value;
                    (LoginCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        private void ToggleIsPassword()
        {
            IsPassword = !IsPassword;
            OnPropertyChanged(nameof(IsPassword));
        }
        public LoginPageVM()
        {
            LoginCommand = new Command(Login, CanLogin);
            ToggleIsPasswordCommand = new Command(ToggleIsPassword);
            user.OnAuthenticationComplete += OnAuthComplete;
            if (Preferences.Get(Keys.RememberMeKey, false))
            {
                Password = Preferences.Get(Keys.PasswordKey, string.Empty);
                Email = Preferences.Get(Keys.GmailKey, string.Empty);
            }
        }

        private void OnAuthComplete(object? sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Application.Current != null)
                {
                    Application.Current.MainPage = new AppShell();
                }
            });
        }

        private bool CanLogin()
        {
            return (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email));
        }

        private void Login()
        {
            user.Login();
        }
    }
}

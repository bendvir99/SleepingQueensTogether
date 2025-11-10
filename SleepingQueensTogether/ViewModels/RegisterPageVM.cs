using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SleepingQueensTogether.Models;
using SleepingQueensTogether.ModelsLogic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace SleepingQueensTogether.ViewModels
{
    internal class RegisterPageVM : ObservableObject
    {
        private readonly User user = new();
        public ICommand RegisterCommand { get; }
        public ICommand RegisterGoogleCommand { get; }
        public ICommand ToggleIsPasswordCommand { get; }
        public bool IsBusy => user.IsBusy;
        public bool IsPassword { get; set; } = true;
        public bool IsEnabled { get; set; } = true;
        public bool IsRegistered => user.IsRegistered;
        public string Name
        { 
            get => user.Name;
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    (RegisterCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        public string Password
        {
            get => user.Password;
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    (RegisterCommand as Command)?.ChangeCanExecute();
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
                    (RegisterCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        private void ToggleIsPassword()
        {
            IsPassword = !IsPassword;
            OnPropertyChanged(nameof(IsPassword));
        }
        public RegisterPageVM()
        {
            RegisterCommand = new Command(Register, CanRegister);
            RegisterGoogleCommand = new Command(RegisterGoogle);
            ToggleIsPasswordCommand = new Command(ToggleIsPassword);
            user.OnAuthenticationComplete += OnAuthComplete;
        }

        private void OnAuthComplete(object? sender, bool success)
        {
            IsEnabled = true;
            OnPropertyChanged(nameof(IsBusy));
            OnPropertyChanged(nameof(IsBusy));
            if (success && Application.Current != null)
            {
                MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Application.Current.MainPage = new AppShell();
                });
            }
        }

        private bool CanRegister()
        {
            return user.IsValidRegister();
        }

        private void Register()
        {
            user.Register();
            IsEnabled = false;
            OnPropertyChanged(nameof(IsBusy));
            OnPropertyChanged(nameof(IsEnabled));

        }
        private void RegisterGoogle()
        {
            user.RegisterGoogle();
            OnPropertyChanged(nameof(IsBusy));
        }
    }
}

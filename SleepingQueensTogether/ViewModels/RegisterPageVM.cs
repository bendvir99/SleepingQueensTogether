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
        public bool IsBusy { get; set; } = false;
        public bool IsPassword { get; set; } = true;
        public string Username
        { 
            get => user.Username;
            set
            {
                if (user.Username != value)
                {
                    user.Username = value;
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
            RegisterCommand = new Command(async () => await Register(), CanRegister);
            RegisterGoogleCommand = new Command(RegisterGoogle);
            ToggleIsPasswordCommand = new Command(ToggleIsPassword);
        }

        private bool CanRegister()
        {
            return (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email));
        }

        private async Task Register()
        {
            IsBusy = true;
            OnPropertyChanged(nameof(IsBusy));
            await Task.Delay(5000);
            IsBusy = false;
            OnPropertyChanged(nameof(IsBusy));
            user.Register();
        }
        private void RegisterGoogle()
        {
            user.RegisterGoogle();
        }
    }
}

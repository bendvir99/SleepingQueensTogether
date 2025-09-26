using SleepingQueensTogether.ModelsLogic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace SleepingQueensTogether.ViewModels
{
    internal class RegisterPageViewModel
    {
        private readonly User user = new();
        public ICommand RegisterCommand { get; }
        public string Username
        { 
            get => user.Username;
            set
            {
                if (user.Username != value)
                {
                    user.Username = value;
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
                }
            }
        }
        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(Register, CanRegister);
        }

        private bool CanRegister()
        {
            return true;
        }

        private void Register()
        {
        }
    }
}

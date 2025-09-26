using SleepingQueensTogether.Views;

namespace SleepingQueensTogether
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RegisterPage();
        }
    }
}

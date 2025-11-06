using SleepingQueensTogether.ViewModels;

namespace SleepingQueensTogether
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageVM();
        }
    }
}

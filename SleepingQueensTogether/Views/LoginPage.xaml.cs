using SleepingQueensTogether.ViewModels;

namespace SleepingQueensTogether.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageVM();
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }
}
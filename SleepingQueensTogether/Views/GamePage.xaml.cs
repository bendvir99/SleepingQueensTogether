using SleepingQueensTogether.ModelsLogic;
using SleepingQueensTogether.ViewModels;

namespace SleepingQueensTogether.Views;

public partial class GamePage : ContentPage
{
	public GamePage(Game game)
	{
		InitializeComponent();
        BindingContext = new GamePageVM(game);
    }
}
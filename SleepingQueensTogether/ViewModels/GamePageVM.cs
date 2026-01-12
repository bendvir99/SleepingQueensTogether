using CommunityToolkit.Maui.Alerts;
using SleepingQueensTogether.Models;
using SleepingQueensTogether.ModelsLogic;
using System.Windows.Input;

namespace SleepingQueensTogether.ViewModels
{
    public partial class GamePageVM : ObservableObject
    {
        private readonly Game game;
        public string Timeleft => game.TimeLeft;
        public string MyName => game.MyName;
        public string StatusMessage => game.StatusMessage;
        public string OpponentName => game.OpponentName;
        public static string Total => $"{Strings.TotalQueens}\n{Strings.TotalPoints}";
        public string[] CardImages => [.. game.Cards.Select(c => c.Image)];
        public string[] QueenCardImages => [.. Enumerable.Range(0, 12).Select(i => GetCardImage(i))];

        public bool CanStartGame => CanStart();
        public ICommand ChangeTurnCommand { get; }
        public ICommand StartGameCommand { get; }
        public GamePageVM(Game game)
        {
            game.GameChanged += OnGameChanged;
            game.TimeLeftChanged += OnTimeLeftChanged;
            ChangeTurnCommand = new Command(ChangeTurn);
            StartGameCommand = new Command(StartGame);
            this.game = game;
            if (!game.IsHostUser)
            {
                game.UpdateGuestUser(OnComplete);
            }
        }

        private void OnTimeLeftChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Timeleft));
        }

        private void StartGame()
        {
            game.InitializeCards();
            OnPropertyChanged($"CardImages");
            OnPropertyChanged($"QueenCardImages");
            OnPropertyChanged(nameof(CanStartGame));
        }

        private bool CanStart()
        {
            return !game.IsHostUser && game.DeckCards.Count == 66;
        }

        private void ChangeTurn()
        {
            game.IsHostTurn = !game.IsHostTurn;
            Dictionary<string, object> dict = new()

            {
                { nameof(game.IsHostTurn), game.IsHostTurn }
            };
            FbData fbd = new();
            fbd.UpdateFields(Keys.GamesCollection, game.Id, dict, OnComplete);
            OnPropertyChanged(nameof(StatusMessage));
        }
        private string GetCardImage(int index)
        {
            if (game.QueenTableCards.Count == 0)
                return "greencard.png";
            if (!game.QueenTableCards[index].IsAwaken)
            {
                return game.QueenTableCards[index].Image;
            }
            else
                return game.QueenTableCards[index].BackImage;
        }
        private void OnGameChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(OpponentName));
            OnPropertyChanged(nameof(StatusMessage));
            if (game.DeckCards.Count == 61 && game.IsHostUser)
            {
                game.InitializeCards();
                OnPropertyChanged($"CardImages");
                OnPropertyChanged($"QueenCardImages");
            }
        }

        private void OnComplete(Task task)
        {
            if (!task.IsCompletedSuccessfully)
                Toast.Make(Strings.JoinGameErr, CommunityToolkit.Maui.Core.ToastDuration.Long, 14);

        }
        public void AddSnapshotListener()
        {
            game.AddSnapshotListener();
        }

        public void RemoveSnapshotListener()
        {
            game.RemoveSnapshotListener();
        }
    }
}


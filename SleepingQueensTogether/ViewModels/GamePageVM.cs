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
        public string Card1Image => game.Cards[0].Image;
        public string Card2Image => game.Cards[1].Image;
        public string Card3Image => game.Cards[2].Image;
        public string Card4Image => game.Cards[3].Image;
        public string Card5Image => game.Cards[4].Image;
        public string QueenCard1Image => GetCardImage(0);
        public string QueenCard2Image => GetCardImage(1);
        public string QueenCard3Image => GetCardImage(2);
        public string QueenCard4Image => GetCardImage(3);
        public string QueenCard5Image => GetCardImage(4);
        public string QueenCard6Image => GetCardImage(5);
        public string QueenCard7Image => GetCardImage(6);
        public string QueenCard8Image => GetCardImage(7);
        public string QueenCard9Image => GetCardImage(8);
        public string QueenCard10Image => GetCardImage(9);
        public string QueenCard11Image => GetCardImage(10);
        public string QueenCard12Image => GetCardImage(11);
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
            for(int i = 0; i < 5; i++)
            {
                OnPropertyChanged($"Card{i + 1}Image");
            }
            for (int i = 0; i < 12; i++)
            {
                OnPropertyChanged($"QueenCard{i + 1}Image");
            }
            OnPropertyChanged(nameof(CanStartGame));
        }

        private bool CanStart()
        {
            return !game.IsHostUser && game.DeckCards.Count == 20;
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
            if (game.QueenTableCards[index].IsAwaken)
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
            if (game.DeckCards.Count == 15 && game.IsHostUser)
            {
                game.InitializeCards();
                for (int i = 0; i < 5; i++)
                {
                    OnPropertyChanged($"Card{i + 1}Image");
                }
                for (int i = 0; i < 12; i++)
                {
                    OnPropertyChanged($"QueenCard{i + 1}Image");
                }
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


using CommunityToolkit.Maui.Alerts;
using SleepingQueensTogether.Models;
using SleepingQueensTogether.ModelsLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SleepingQueensTogether.ViewModels
{
    public partial class GamePageVM : ObservableObject
    {
        private readonly Game game;
        public string MyName => game.MyName;
        public string StatusMessage => game.StatusMessage;
        public string OpponentName => game.OpponentName;
        public string Total => $"{Strings.TotalQueens}\n{Strings.TotalPoints}";
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
        public string QueenCard10Image => GetCardImage(10);
        public string QueenCard11Image => GetCardImage(11);
        public string QueenCard12Image => GetCardImage(12);
        public bool IsGuest => !game.IsHostUser;
        public ICommand ChangeTurnCommand { get; }
        public ICommand StartGameCommand { get; }
        public GamePageVM(Game game)
        {
            game.OnGameChanged += OnGameChanged;
            ChangeTurnCommand = new Command(ChangeTurn);
            StartGameCommand = new Command(StartGame);
            this.game = game;
            if (!game.IsHostUser)
            {
                game.UpdateGuestUser(OnComplete);
            }
        }

        private void StartGame()
        {
            game.InitializeCards();
            OnPropertyChanged(nameof(Card1Image));
            OnPropertyChanged(nameof(Card2Image));
            OnPropertyChanged(nameof(Card3Image));
            OnPropertyChanged(nameof(Card4Image));
            OnPropertyChanged(nameof(Card5Image));
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
                OnPropertyChanged(nameof(Card1Image));
                OnPropertyChanged(nameof(Card2Image));
                OnPropertyChanged(nameof(Card3Image));
                OnPropertyChanged(nameof(Card4Image));
                OnPropertyChanged(nameof(Card5Image));
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


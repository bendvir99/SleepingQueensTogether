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
        public ICommand ChangeTurnCommand { get; }
        public GamePageVM(Game game)
        {
            game.OnGameChanged += OnGameChanged;
            ChangeTurnCommand = new Command(ChangeTurn);
            this.game = game;
            if (!game.IsHostUser)
            {
                game.UpdateGuestUser(OnComplete);
            }
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

        private void OnGameChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(OpponentName));
            OnPropertyChanged(nameof(StatusMessage));
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


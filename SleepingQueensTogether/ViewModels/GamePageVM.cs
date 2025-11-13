using CommunityToolkit.Maui.Alerts;
using SleepingQueensTogether.Models;
using SleepingQueensTogether.ModelsLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.ViewModels
{
    internal class GamePageVM : ObservableObject
    {
        private readonly Game game;
        public string MyName => game.MyName;
        public string Player2Number => game.Player2Number;
        public string Player3Number => game.Player2Number;
        public string Player4Number => game.Player2Number;
        public string OpponentName1 => game.Opponent1Name;
        public string OpponentName2 => game.Opponent2Name;
        public string OpponentName3 => game.Opponent3Name;
        public GamePageVM(Game game)
        {
            this.game = game;
            if (!game.IsHostUser)
            {
                if (game.PlayerAmount == 1)
                {
                    game.Player2Number = MyName;
                    game.PlayerAmount = 2;
                    game.SetDocument(OnComplete);
                }
                else if (game.PlayerAmount == 2)
                {
                    game.Player3Number = MyName;
                    game.PlayerAmount = 3;
                    game.SetDocument(OnComplete);
                }
                else if (game.PlayerAmount == 3)
                {
                    game.Player4Number = MyName;
                    game.PlayerAmount = 4;
                    game.SetDocument(OnComplete);
                }
                if (game.PlayerCount == game.PlayerAmount)
                {
                    game.IsFull = true;
                    game.SetDocument(OnComplete);
                }
            }
        }
        private void OnComplete(Task task)
        {
            if (!task.IsCompletedSuccessfully)
                Toast.Make(Strings.JoinGameErr, CommunityToolkit.Maui.Core.ToastDuration.Long, 14);

        }
    }
}

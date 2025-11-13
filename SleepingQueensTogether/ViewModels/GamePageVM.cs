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
    class GamePageVM : ObservableObject
    {
        private readonly Game game;
        public string MyName => game.MyName;
        public string OpponentName => game.OpponentName;
        public GamePageVM(Game game)
        {
            this.game = game;
            if (!game.IsHost)
            {
                game.GuestName = MyName;
                game.IsFull = true;
                game.SetDocument(OnComplete);
            }
        }

        private void OnComplete(Task task)
        {
            if (!task.IsCompletedSuccessfully)
                Toast.Make(Strings.JoinGameErr, CommunityToolkit.Maui.Core.ToastDuration.Long, 14);

        }
    }
}

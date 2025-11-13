using Microsoft.Maui.Controls;
using SleepingQueensTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.ModelsLogic
{
    public class Game : GameModel
    {
        public override string OpponentName => IsHost ? GuestName : HostName;

        internal Game()
        {
            HostName = fbd.DisplayName;
            Created = DateTime.Now;
        }

        public override void SetDocument(Action<System.Threading.Tasks.Task> OnComplete)
        {
            Id = fbd.SetDocument(this, Keys.GamesCollection, Id, OnComplete);
        }
    }
}

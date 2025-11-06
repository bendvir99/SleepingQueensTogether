using Microsoft.Maui.Controls;
using SleepingQueensTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.ModelsLogic
{
    class Game : GameModel
    {
        internal Game(GameSize selectedGameSize)
        {
            HostName = fbd.DisplayName;
            PlayerCount = selectedGameSize.Size;
            Created = DateTime.Now;
        }
        internal Game()
        {
        }
        public override void SetDocument(Action<System.Threading.Tasks.Task> OnComplete)
        {
            Id = fbd.SetDocument(this, Keys.GamesCollection, Id, OnComplete);
        }
    }
}

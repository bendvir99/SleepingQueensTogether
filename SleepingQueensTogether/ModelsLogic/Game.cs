using Microsoft.Maui.Controls;
using Plugin.CloudFirestore;
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
        public override string Opponent1Name
        {
            get
            {
                if (fbd.DisplayName == Player1Number) return Player2Number;
                return Player1Number;
            }

        }
        public override string Opponent2Name
        {
            get
            {
                if (Opponent1Name == Player1Number)
                {
                    if (fbd.DisplayName == Player2Number) return Player3Number;
                    return Player2Number;
                }
                return Player3Number;
            }

        }
        public override string Opponent3Name
        {
            get
            {
                if (Opponent2Name == Player2Number)
                {
                    if (fbd.DisplayName == Player3Number) return Player4Number;
                    return Player3Number;
                }
                return Player4Number;
            }

        }
        internal Game(GameSize selectedGameSize)
        {
            Player1Number = fbd.DisplayName;
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

using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using SleepingQueensTogether.ModelsLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.Models
{
    public abstract class GameModel
    {
        protected static FbData fbd = new();
        [Ignored]
        public string Id { get; set; } = string.Empty;
        public string Player1Number { get; set; } = string.Empty;
        public string Player2Number { get; set; } = string.Empty;
        public string Player3Number { get; set; } = string.Empty;
        public string Player4Number { get; set; } = string.Empty;
        public int PlayerAmount { get; set; } = 1;
        public DateTime Created { get; set; }
        public int PlayerCount { get; set; }
        public bool IsFull { get; set; }
        [Ignored]
        public string PlayerCountName => $"{PlayerCount} Players";
        [Ignored]
        public string MyName { get; set; } = fbd.DisplayName;
        [Ignored]
        public bool IsHostUser { get; set; }
        [Ignored]
        public abstract string Opponent1Name { get; }
        [Ignored]
        public abstract string Opponent2Name { get; }
        [Ignored]
        public abstract string Opponent3Name { get; }
        public abstract void SetDocument(Action<System.Threading.Tasks.Task> OnComplete);

    }
}

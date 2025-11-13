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
        public string HostName { get; set; } = string.Empty;
        public string GuestName { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public bool IsFull { get; set; }
        [Ignored]
        public string MyName { get; set; } = fbd.DisplayName;
        [Ignored]
        public bool IsHost { get; set; }
        [Ignored]
        public abstract string OpponentName { get; }
        public abstract void SetDocument(Action<System.Threading.Tasks.Task> OnComplete);
    }
}

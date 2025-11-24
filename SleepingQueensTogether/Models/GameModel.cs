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
        protected IListenerRegistration? ilr;
        protected abstract GameStatus Status { get; }
        protected GameStatus _status = new();
        [Ignored]
        public string StatusMessage => Status.StatusMessage;
        [Ignored]
        public EventHandler? OnGameChanged;
        [Ignored]
        public EventHandler? OnGameDeleted;
        [Ignored]
        public string Id { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
        public string GuestName { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public bool IsFull { get; set; }
        public bool IsHostTurn { get; set; } = false;
        [Ignored]
        public string MyName { get; set; } = fbd.DisplayName;
        [Ignored]
        public bool IsHostUser { get; set; }
        [Ignored]
        public abstract string OpponentName { get; }
        public abstract void SetDocument(Action<System.Threading.Tasks.Task> OnComplete);
        public abstract void RemoveSnapshotListener();
        public abstract void AddSnapshotListener();
        public abstract void DeleteDocument(Action<System.Threading.Tasks.Task> OnComplete);
        protected abstract void UpdateStatus();

    }
}

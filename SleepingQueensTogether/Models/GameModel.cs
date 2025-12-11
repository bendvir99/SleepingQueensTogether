using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using SleepingQueensTogether.ModelsLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.Models
{
    public abstract class GameModel
    {
        protected static FbData fbd = new();
        protected Random random = new();
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
        [Ignored]
        public string MyName { get; set; } = fbd.DisplayName;
        [Ignored]
        public bool IsHostUser { get; set; }
        [Ignored]
        public abstract string OpponentName { get; }
        [Ignored]
        public Card[] Cards = {new Card(), new Card(), new Card(), new Card(), new Card() };
        public List<Card> DeckCards = [new Card("Number", 1), new Card("Number", 2), new Card("Number", 3), new Card("Number", 4), new Card("Number", 5), new Card("Number", 6), new Card("Number", 7), new Card("Number", 8), new Card("Number", 9), new Card("Number", 10), new Card("King", 1), new Card("King", 2), new Card("King", 3), new Card("King", 4), new Card("King", 5), new Card("King", 6), new Card("King", 7), new Card("King", 8), new Card("King", 9), new Card("King", 10)];
        public List<Card> QueenTableCards = [new Card("Queen", 1), new Card("Queen", 2), new Card("Queen", 3), new Card("Queen", 4), new Card("Queen", 5), new Card("Queen", 6), new Card("Queen", 7), new Card("Queen", 8), new Card("Queen", 9), new Card("Queen", 10)];
        public string HostName { get; set; } = string.Empty;
        public string GuestName { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public bool IsFull { get; set; }
        public bool IsHostTurn { get; set; } = false;
        public abstract void SetDocument(Action<System.Threading.Tasks.Task> OnComplete);
        public abstract void RemoveSnapshotListener();
        public abstract void AddSnapshotListener();
        public abstract void DeleteDocument(Action<System.Threading.Tasks.Task> OnComplete);
        public abstract void UpdateGuestUser(Action<Task> OnComplete);
        public abstract void InitializeCards();
        protected abstract void UpdateStatus();
        protected abstract void UpdateFbJoinGame(Action<Task> OnComplete);
        protected abstract void UpdateFbInGame(Action<Task> OnComplete);
        protected abstract void OnComplete(Task task);
        protected abstract void OnCompleteUpdate(Task task);
        protected abstract void OnChange(IDocumentSnapshot? snapshot, Exception? error);

    }
}

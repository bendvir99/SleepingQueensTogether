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
        public Card Card1 { get; set; } = new();
        [Ignored]
        public Card Card2 { get; set; } = new();
        [Ignored]
        public Card Card3 { get; set; } = new();
        [Ignored]
        public Card Card4 { get; set; } = new();
        [Ignored]
        public Card Card5 { get; set; } = new();
        public List<Card> DeckCards = [new Card("Number", "ace_club.png", 1), new Card("Number", "two_club.png", 2), new Card("Number", "three_club.png", 3), new Card("Number", "four_club.png", 4), new Card("Number", "five_club.png", 5), new Card("Number", "six_club.png", 6), new Card("Number", "seven_club.png", 7), new Card("Number", "eight_club.png", 8), new Card("Number", "nine_club.png", 9), new Card("Number", "ten_club.png", 10), new Card("Number", "ace_spade.png", 1), new Card("Number", "two_spade.png", 2), new Card("Number", "three_spade.png", 3), new Card("Number", "four_spade.png", 4), new Card("Number", "five_spade.png", 5), new Card("Number", "six_spade.png", 6), new Card("Number", "seven_spade.png", 7), new Card("Number", "eight_spade.png", 8), new Card("Number", "nine_spade.png", 9), new Card("Number", "ten_spade.png", 10), new Card("Number", "ace_heart.png", 1), new Card("Number", "two_heart.png", 2), new Card("Number", "three_heart.png", 3), new Card("Number", "four_heart.png", 4), new Card("Number", "five_heart.png", 5), new Card("Number", "six_heart.png", 6), new Card("Number", "seven_heart.png", 7), new Card("Number", "eight_heart.png", 8), new Card("Number", "nine_heart.png", 9), new Card("Number", "ten_heart.png", 10), new Card("Number", "ace_diamond.png", 1), new Card("Number", "two_diamond.png", 2), new Card("Number", "three_diamond.png", 3), new Card("Number", "four_diamond.png", 4), new Card("Number", "five_diamond.png", 5), new Card("Number", "six_diamond.png", 6), new Card("Number", "seven_diamond.png", 7), new Card("Number", "eight_diamond.png", 8), new Card("Number", "nine_diamond.png", 9), new Card("Number", "ten_diamond.png", 10), new Card("Number", "jack_diamond.png", 11), new Card("Number", "queen_diamond.png", 12), new Card("Number", "king_diamond.png", 13), new Card("Number", "jack_club.png", 11), new Card("Number", "queen_club.png", 12), new Card("Number", "king_club.png", 13), new Card("Number", "jack_spade.png", 11), new Card("Number", "queen_spade.png", 12), new Card("Number", "king_spade.png", 13), new Card("Number", "jack_heart.png", 11), new Card("Number", "queen_heart.png", 12), new Card("Number", "king_heart.png", 13)];
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

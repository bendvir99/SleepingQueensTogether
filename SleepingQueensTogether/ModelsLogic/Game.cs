using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Animations;
using Plugin.CloudFirestore;
using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.ModelsLogic
{
    public class Game : GameModel
    {
        public override string OpponentName => IsHostUser ? GuestName : HostName;
        protected override GameStatus Status => _status;

        internal Game()
        {
            HostName = fbd.DisplayName;
            Created = DateTime.Now;
            InitializeCards();
            UpdateStatus();
        }
        protected override void UpdateStatus()
        {
            _status.CurrentStatus = IsHostUser && IsHostTurn || !IsHostUser && !IsHostTurn ?
                GameStatus.Statuses.Play : GameStatus.Statuses.Wait;
        }

        public override void SetDocument(Action<System.Threading.Tasks.Task> OnComplete)
        {
            Id = fbd.SetDocument(this, Keys.GamesCollection, Id, OnComplete);
        }
        public void UpdateGuestUser(Action<Task> OnComplete)
        {
            IsFull = true;
            GuestName = MyName;
            UpdateFbJoinGame(OnComplete);
        }

        private void UpdateFbJoinGame(Action<Task> OnComplete)
        {
            Dictionary<string, object> dict = new()
            {
                { nameof(IsFull), IsFull },
                { nameof(GuestName), GuestName }
            };
            fbd.UpdateFields(Keys.GamesCollection, Id, dict, OnComplete);
        }

        public override void AddSnapshotListener()
        {
            ilr = fbd.AddSnapshotListener(Keys.GamesCollection, Id, OnChange);
        }

        public override void RemoveSnapshotListener()
        {
            ilr?.Remove();
            DeleteDocument(OnComplete);
        }

        private void OnComplete(Task task)
        {
            if (task.IsCompletedSuccessfully)
                OnGameDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void OnChange(IDocumentSnapshot? snapshot, Exception? error)
        {
            Game? updatedGame = snapshot?.ToObject<Game>();
            if (updatedGame != null)
            {
                IsFull = updatedGame.IsFull;
                GuestName = updatedGame.GuestName;
                IsHostTurn = updatedGame.IsHostTurn;
                OnGameChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Shell.Current.Navigation.PopAsync();
                    Toast.Make(Strings.GameCanceled, CommunityToolkit.Maui.Core.ToastDuration.Long, 14).Show();
                });

            }
        }
        protected override void InitializeCards()
        {
            int number = random.Next(0, DeckCards.Count);
            Card1 = DeckCards[number];
            DeckCards.RemoveAt(number);
            int number2 = random.Next(0, DeckCards.Count);
            Card2 = DeckCards[number2];
            DeckCards.RemoveAt(number2);
            int number3 = random.Next(0, DeckCards.Count);
            Card3 = DeckCards[number3];
            DeckCards.RemoveAt(number3);
            int number4 = random.Next(0, DeckCards.Count);
            Card4 = DeckCards[number4];
            DeckCards.RemoveAt(number4);
            int number5 = random.Next(0, DeckCards.Count);
            Card5 = DeckCards[number5];
            DeckCards.RemoveAt(number5);

        }
        public override void DeleteDocument(Action<Task> OnComplete)
        {
            fbd.DeleteDocument(Keys.GamesCollection, Id, OnComplete);
        }
    }
}

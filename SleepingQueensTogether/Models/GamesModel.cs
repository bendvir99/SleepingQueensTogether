using Plugin.CloudFirestore;
using SleepingQueensTogether.ModelsLogic;
using System.Collections.ObjectModel;

namespace SleepingQueensTogether.Models
{
    public abstract class GamesModel
    {
        protected FbData fbd = new();
        protected IListenerRegistration? ilr;
        protected Game? currentGame;

        public bool IsBusy { get; set; }
        public Game? CurrentGame { get => currentGame; set => currentGame = value; }
        public ObservableCollection<Game>? GamesList { get; set; } = [];

        public EventHandler<Game>? OnGameAdded;
        public EventHandler? OnGamesChanged;
        public abstract void RemoveSnapshotListener();
        public abstract void AddSnapshotListener();

    }
}

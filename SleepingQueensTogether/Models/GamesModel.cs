using Plugin.CloudFirestore;
using SleepingQueensTogether.ModelsLogic;
using System.Collections.ObjectModel;

namespace SleepingQueensTogether.Models
{
    public class GamesModel
    {
        protected FbData fbd = new();
        protected IListenerRegistration? ilr;
        protected Game? currentGame;

        public bool IsBusy { get; set; }
        public Game? CurrentGame { get => currentGame; set => currentGame = value; }
        public ObservableCollection<Game>? GamesList { get; set; } = [];
        public ObservableCollection<GameSize>? GameSizes { get; set; } = [new GameSize(2), new GameSize(3), new GameSize(4)];
        public GameSize SelectedGameSize { get; set; } = new GameSize();

        public EventHandler<Game>? OnGameAdded;
        public EventHandler? OnGamesChanged;

    }
}

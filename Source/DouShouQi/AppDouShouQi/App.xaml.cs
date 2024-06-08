using System.Collections.ObjectModel;
using System.ComponentModel;
using DouShouQiLib;
using DataContractPersist;

namespace AppDouShouQi
{
    
    public partial class App : Application
    {
        public Manager TheMgr { get; set; } = new Manager();

        public IPersistanceManager SaveManager = new XMLPersist(); 
        
        public int loadingPlayer { get; set; }
        
        public ReadOnlyObservableCollection<Game> Games { get; private set; }
        private readonly ObservableCollection<Game> games = [];
        
        public ReadOnlyObservableCollection<Joueur> Players { get; private set; }
        private readonly ObservableCollection<Joueur> players = [];

        public bool DeleteGame(Game game)
        {
            bool ok = SaveManager.DeleteAGame(game);
            if (!ok) return false;
            return games.Remove(game);
        }

        public bool AddGame(Game game)
        {
            games.Insert(0, game);
            SaveManager.SaveAGame(game);
            return true;
        }

        public bool AddPlayer(Joueur player)
        {
            SaveManager.SaveAPlayer(player);
            players.Add(player);
            return true;
        }

        public void LoadGames()
        {
            foreach (Game game in SaveManager.LoadGame())
            {
                games.Insert(0, game);
            }
        }
        
        public void LoadPlayers()
        {
            foreach (Joueur player in SaveManager.LoadPlayer())
            {
                players.Add(player);
            }
        }

        public void AddVictory(Joueur player)
        {
            player.AddVictory();
            SaveManager.SaveAPlayer(player);
        }
        
        public App()
        {
            InitializeComponent();
            Application.Current!.UserAppTheme = Application.Current.RequestedTheme;
            MainPage = new AppShell();
            Games = new ReadOnlyObservableCollection<Game>(games);
            Players = new ReadOnlyObservableCollection<Joueur>(players);
            LoadGames();
            LoadPlayers();
        }
    }
}

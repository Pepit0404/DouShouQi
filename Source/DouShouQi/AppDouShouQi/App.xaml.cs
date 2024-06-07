﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using DouShouQiLib;
using DataContractPersist;

namespace AppDouShouQi
{
    
    public partial class App : Application
    {
        public Manager TheMgr { get; set; } = new Manager();

        public IPersistanceManager SaveManager = new XMLPersist(); 
        
        public ReadOnlyObservableCollection<Game> Games { get; private set; }
        private readonly ObservableCollection<Game> games = [];

        public bool Delete_Game(Game game)
        {
            bool ok = SaveManager.DeleteAGame(game);
            if (!ok) return false;
            return games.Remove(game);
        }

        public bool Add_Game(Game game)
        {
            games.Add(game);
            SaveManager.SaveAGame(game);
            return true;
        }

        public void LoadGames()
        {
            foreach (Game game in SaveManager.LoadGame())
            {
                games.Add(game);
            }
        }
        
        public App()
        { 
            InitializeComponent();
            MainPage = new AppShell();
            Games = new ReadOnlyObservableCollection<Game>(games);
            LoadGames();
        }
    }
}

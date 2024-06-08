using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Manager : INotifyPropertyChanged
    {
        public event EventHandler<StartingGameEventArgs>? StartingGame;
        public Game game { get; set; }

        public Plateau? Plateau
            => this.game.Plateau;
      
        public IRegles? Regles { get; set; }
        public Joueur[] Joueurs { get; set; } = new Joueur[2];

        public void SetNameJoueurs(int number, string name)
        {
            if (number != 1 && number != 2) return;
            Joueurs[number - 1].Name = name;
            OnPropertyChanged(nameof(Joueurs) );
        }
        public string CurrentPlayer => "Au tour de " + game.JoueurCourant;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void InitGame()
        {
            game.BoardChanged += Manager_OnBoardChanged;
            game.PlayerChanged += Manager_OnPlayerChanged;
            Joueurs[0] = game.Joueur1;
            Joueurs[1] = game.Joueur2;
            OnStartingGame(Joueurs[0], Joueurs[1]);
            OnPropertyChanged(nameof(Plateau) );
            OnPropertyChanged(nameof(CurrentPlayer) );
            OnPropertyChanged(nameof(Joueurs) );
        }
        
        public void CreateGame()
        {
            if (Regles == null) return ;
            game = new Game(Regles, Joueurs[0], Joueurs[1]);
            InitGame();
        }
        
        public Manager()
        {
            Joueurs[0] = new HumainJoueur("", 1);
            Joueurs[1] = new HumainJoueur("", 2);
        }

        public void setRegles(string regle)
        {
            Regles = regle switch
            {
                "classic" => new regleOrigin(),
                "remix" => new regleVariente(),
                _ => null,
            };
        }

        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        protected virtual void OnStartingGame(Joueur j1, Joueur j2)
            => StartingGame?.Invoke(this, new StartingGameEventArgs(j1, j2));

        public void CreatePlayer(string name, int id)
        {
            Joueurs[id - 1] = new HumainJoueur(name,id) ;
            OnPropertyChanged(nameof(Joueurs) );
        }

        void Manager_OnBoardChanged(object? sender, BoardChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Plateau) );
        }
        void Manager_OnPlayerChanged(object? sender, PlayerChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CurrentPlayer));
        }
    }
}

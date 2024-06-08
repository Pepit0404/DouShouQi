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

        /// <summary>
        ///     Initialisation de la partie en créant le plateau et les joueurs
        /// </summary>
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

        /// <summary>
        ///     Crée la partie avec les bonnes règles et les bons joueurs
        /// </summary>
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

        /// <summary>
        ///     Met en place les bonnes règles choisit par le joueur
        /// </summary>
        /// <param string="regle"></param>
        public void setRegles(string regle)
        {
            Regles = regle switch
            {
                "classic" => new regleOrigin(),
                "remix" => new regleVariente(),
                _ => null,
            };
        }

        /// <summary>
        ///     Evènement qui renvoie un changement dans la partie
        /// </summary>
        /// /// <param string="propertyName"></param>
        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        /// <summary>
        ///     Evènement qui avertie quand la partie commence
        /// </summary>
        /// /// <param Joueur="j1"></param>
        /// 
        protected virtual void OnStartingGame(Joueur j1, Joueur j2)
            => StartingGame?.Invoke(this, new StartingGameEventArgs(j1, j2));

<<<<<<< HEAD
        /// <summary>
        ///     crée un joueur humain avec un nom et un id
        /// </summary>
        /// <param string="name"></param>
        /// /// <param int="id"></param>
        public void CreatePlayer(string name, int id)
=======
        public void CreatePlayer(string name, int id, int nbVictory = 0)
>>>>>>> Theme
        {
            Joueurs[id - 1] = new HumainJoueur(name,id) ;
            for (int i = 0; i <= nbVictory; i++)
            {
                Joueurs[id - 1].AddVictory();
            }
            OnPropertyChanged(nameof(Joueurs) );
        }

        /// <summary>
        ///     Evènement qui renvoie un changement dans la partie
        /// </summary>
        /// /// <param string="propertyName"></param>
        void Manager_OnBoardChanged(object? sender, BoardChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Plateau) );
        }

        /// <summary>
        ///     Evènement qui renvoie un changement dans la partie
        /// </summary>
        /// /// <param string="propertyName"></param>
        void Manager_OnPlayerChanged(object? sender, PlayerChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CurrentPlayer));
        }
    }
}

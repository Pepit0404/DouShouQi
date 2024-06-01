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
    public class Manager: INotifyPropertyChanged
    {
        public Game game { get; set; }
        public Plateau? Plateau => game.Plateau;    
      
        public IRegles? Regles { get; set; }
        public Joueur[] Joueurs { get; set; } = new Joueur[2];

        public event PropertyChangedEventHandler? PropertyChanged;

        public void CreateGame()
        {
            if (Regles == null) return ;
            game = new Game(Regles, Joueurs[0], Joueurs[1]);
            game.BoardChanged += Manger_OnBoardChanged;
            OnPropertyChanged(nameof(Plateau) );
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

        public void CreatePlayer(string name, int id)
        {
            Joueurs[id - 1] = new HumainJoueur(name,id) ;
            OnPropertyChanged(nameof(Joueurs) );
        }

        void Manger_OnBoardChanged(object? sender, BoardChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Plateau) );
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Manager: INotifyPropertyChanged
    {
        public Game Game { get; set; }
        public Plateau Plateau { get; set; }    
      
        public IRegles Regles { get; set; }
        public Joueur[] Joueurs { get; set; } = new Joueur[2];

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void CreatePlayer(string name, int id)
        {
            Joueurs[id - 1] = new HumainJoueur(name,id) ;
            OnPropertyChanged("Joueurs");
        }

    }
}

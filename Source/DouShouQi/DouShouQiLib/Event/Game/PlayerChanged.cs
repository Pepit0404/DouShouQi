using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class PlayerChangedEventArgs : EventArgs
    {
        public Joueur NouveauJoueur { get; private init; }

        public PlayerChangedEventArgs(Joueur nouveauJoueur)
        {
            NouveauJoueur = nouveauJoueur;
        }
    }
}

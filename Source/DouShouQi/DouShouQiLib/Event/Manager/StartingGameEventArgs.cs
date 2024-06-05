using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class StartingGameEventArgs : EventArgs
    {
        public Joueur J1 { get; set; } 
        public Joueur J2 { get; set; }

        public StartingGameEventArgs(Joueur j1, Joueur j2)
        {
            J1 = j1;
            J2 = j2;
        }
    }
}

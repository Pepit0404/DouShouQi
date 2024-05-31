using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class GameOverEventArgs : EventArgs
    {
        public bool End {  get; set; }

        public Joueur? Winer { get; set; }

        public GameOverEventArgs(bool end, Joueur? winer) 
        {
            End = end;
            Winer = winer;
        }
    }
}

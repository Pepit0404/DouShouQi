using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    internal class Manager
    {
        public Game Game { get; set; }
        public Plateau Plateau { get; set; }    
      
        public IRegles Regles { get; set; }
        public Joueur[] Joueur { get; set; } = new Joueur[2];
      
    }
}

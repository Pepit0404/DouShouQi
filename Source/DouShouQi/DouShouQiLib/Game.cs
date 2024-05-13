using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Game
    {
        private Plateau Plateau {  get; init; }

        private IRegles Regle {  get; init; }

        public Game(IRegles regles) 
        {
            Regle= regles;
            Plateau= Regle.initPlateau();
        }
    }
}

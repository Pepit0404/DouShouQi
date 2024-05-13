using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Game
    {
        public Plateau Plateau {  get; init; }

        private IRegles Regle {  get; init; }

        public Joueur Joueur1 {  get; init; }

        public Joueur Joueur2 { get; init; }

        public Joueur JoueurCourant { get; private set; }

        public Game(IRegles regles, Joueur joueur1, Joueur joueur2) 
        {
            Regle= regles;
            Plateau= Regle.initPlateau();
            Joueur1 = joueur1;
            Joueur2 = joueur2;
            JoueurCourant = Joueur1;
        }

        public bool MovePiece(Case caseD, Case caseA)
        {
            if ( ! Regle.PouvoirBouger(caseD, caseA))
            {
                return false;
            }
            caseA.Onthis = caseD.Onthis;
            caseD.Onthis = null; 
            return true;
        }

    }
}

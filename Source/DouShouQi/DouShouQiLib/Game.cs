using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public Piece[] Piece { get; private set; }

    public Game(IRegles regles, Joueur joueur1, Joueur joueur2) 
        {
            this.Plateau = new Plateau();
            Regle = regles;
            Joueur1 = joueur1;
            Joueur2 = joueur2;
            JoueurCourant = Joueur1;
            Regle.initPlateau(this);
        }

        public bool MovePiece(Case caseD, Case caseA, Plateau plateau)
        {
            if ( ! Regle.PouvoirBouger(caseD, caseA, plateau))
            {
                return false;
            }
            caseA.Onthis = caseD.Onthis;
            caseD.Onthis = null; 
            return true;
        }

        public void ChangePlayer()
        {
            if (JoueurCourant == Joueur1)
            {
                JoueurCourant = Joueur2;
            }
            else
            {
                JoueurCourant = Joueur1;
            }
            OnPlayerChanged(JoueurCourant);          
        }
        public event EventHandler<PlayerChangedEventArgs> PlayerChanged;
        protected virtual void OnPlayerChanged(Joueur nouveauJoueur)
        {
            if(PlayerChanged != null)
            {
                PlayerChanged(this, new PlayerChangedEventArgs(nouveauJoueur));
            }
        }
    }
}

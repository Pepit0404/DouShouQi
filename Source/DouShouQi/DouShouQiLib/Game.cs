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

        public Piece[] Piece { get; private set; }

        public event EventHandler<BoardChangedEventArgs>? BoardChanged;
        public event EventHandler<OnPieceMovedEventArgs>? PieceMoved;


        protected virtual void OnBoardChanged(Plateau newBoard, Case depart, Case arrivee)
        {
            BoardChanged?.Invoke(this, new BoardChangedEventArgs(newBoard, depart, arrivee));
        }
        protected virtual void OnPieceMoved(bool ok, Case depart, Case arrive)
        {
            PieceMoved?.Invoke(this, new OnPieceMovedEventArgs(ok, depart, arrive));
        }

        public Game(IRegles regles, Joueur joueur1, Joueur joueur2)
        {
            Plateau = new Plateau();
            Regle = regles;
            Joueur1 = joueur1;
            Joueur2 = joueur2;
            JoueurCourant = Joueur1;
            Regle.initPlateau(this);
        }

        public bool MovePiece(Case caseD, Case caseA)
        {
            if ( ! Regle.PouvoirBouger(caseD, caseA))
            {
                OnPieceMoved(false, caseD, caseA);
                return false;
            }
            caseA.Onthis = caseD.Onthis;
            caseD.Onthis = null;

            OnBoardChanged(Plateau, caseD, caseA);
            OnPieceMoved(true, caseD, caseA);

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
        }

        public bool isFini()
        {
            return Regle.EstFini(this);
        }
    }
}

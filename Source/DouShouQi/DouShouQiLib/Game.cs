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

        public event EventHandler<BoardChangedEventArgs>? BoardChanged;
        public event EventHandler<OnPieceMovedEventArgs>? PieceMoved;
        public event EventHandler<PlayerChangedEventArgs>? PlayerChanged;
        public event EventHandler<GameOverEventArgs>? GameOver;


        protected virtual void OnBoardChanged(Plateau newBoard, Case depart, Case arrivee)
        {
            BoardChanged?.Invoke(this, new BoardChangedEventArgs(newBoard, depart, arrivee));
        }
        protected virtual void OnPieceMoved(bool ok, Case depart, Case arrive)
        {
            PieceMoved?.Invoke(this, new OnPieceMovedEventArgs(ok, depart, arrive));
        }
        protected virtual void OnPlayerChanged(Joueur nouveauJoueur)
        {
            if (PlayerChanged != null)
            {
                PlayerChanged?.Invoke(this, new PlayerChangedEventArgs(nouveauJoueur));
            }
        }
        protected virtual void OnGameOver(bool end, Joueur? winer, Case? where)
        {
            if (end)
            {
                GameOver?.Invoke(this, new GameOverEventArgs(true, winer, where));
                return;
            }
            GameOver?.Invoke(this, new GameOverEventArgs(false, null, null));
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

        public bool MovePiece(Case caseD, Case caseA, Plateau plateau)
        {
            if ( ! Regle.PouvoirBouger(caseD, caseA, plateau))
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
            OnPlayerChanged(JoueurCourant);          
        }

        public bool isFini()
        {
            if (Regle.EstFini(this))
            {
                OnGameOver(true, JoueurCourant, null); // a changer ça
                return true;
            }
            OnGameOver(false, null, null);
            return false;
        }
    }
}

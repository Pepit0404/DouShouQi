using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public List<Piece> Liste_Piece_J1 { get; private set; }

        public List<Piece> Liste_Piece_J2 { get; private set; }

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

            Liste_Piece_J1 = new List<Piece>();
            Liste_Piece_J2 = new List<Piece>();


            //Liste_Piece_J1[0] = new Piece(PieceType.souris, Joueur1);
            //Liste_Piece_J1[1] = new Piece(PieceType.chat, Joueur1);
            //Liste_Piece_J1[2] = new Piece(PieceType.chien, Joueur1);
            //Liste_Piece_J1[3] = new Piece(PieceType.loup, Joueur1);
            //Liste_Piece_J1[4] = new Piece(PieceType.leopard, Joueur1);
            //Liste_Piece_J1[5] = new Piece(PieceType.tigre, Joueur1);
            //Liste_Piece_J1[6] = new Piece(PieceType.lion, Joueur1);
            //Liste_Piece_J1[7] = new Piece(PieceType.elephant, Joueur1);

            //Liste_Piece_J2[0] = new Piece(PieceType.souris, Joueur2);
            //Liste_Piece_J2[1] = new Piece(PieceType.chat, Joueur2);
            //Liste_Piece_J2[2] = new Piece(PieceType.chien, Joueur2);
            //Liste_Piece_J2[3] = new Piece(PieceType.loup, Joueur2);
            //Liste_Piece_J2[4] = new Piece(PieceType.leopard, Joueur2);
            //Liste_Piece_J2[5] = new Piece(PieceType.tigre, Joueur2);
            //Liste_Piece_J2[6] = new Piece(PieceType.lion, Joueur2);
            //Liste_Piece_J2[7] = new Piece(PieceType.elephant, Joueur2);

            Regle.initPlateau(this);
        }

        public bool MovePiece(Case caseD, Case caseA, Plateau plateau)
        {
            if ( ! Regle.PouvoirBouger(caseD, caseA, plateau))
            {
                OnPieceMoved(false, caseD, caseA);
                return false;
            }
            if (caseA.Onthis.HasValue)
            {
                Liste_Piece_J1.Remove(caseA.Onthis.Value);
                Liste_Piece_J2.Remove(caseA.Onthis.Value);
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

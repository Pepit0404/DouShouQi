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

        public IRegles Regle {  get; init; }

        public Joueur Joueur1 {  get; init; }

        public Joueur Joueur2 { get; init; }

        public Joueur JoueurCourant { get; private set; }

        public event EventHandler<BoardChangedEventArgs>? BoardChanged;
        public event EventHandler<PieceMovedEventArgs>? PieceMoved;
        public event EventHandler<PlayerChangedEventArgs>? PlayerChanged;
        public event EventHandler<GameOverEventArgs>? GameOver;
        public event EventHandler<AppartientEventArgs>? LuiAppartient;
        public event EventHandler<TalkToPlayerEventArgs>? TalkToPlayer;
        public delegate Case[] AskMooveDelegate(int maxX, int maxY, Game game);
        public event AskMooveDelegate AskMoove;

        protected virtual void OnAppartient(bool ok, Joueur proprietaire)
        {
            LuiAppartient?.Invoke(this, new AppartientEventArgs(ok, proprietaire));
        }
        protected virtual void OnBoardChanged(Plateau newBoard, Case depart, Case arrivee)
        {
            BoardChanged?.Invoke(this, new BoardChangedEventArgs(newBoard, depart, arrivee));
        }
        protected virtual void OnPieceMoved(bool ok, Case depart, Case arrive)
        {
            PieceMoved?.Invoke(this, new PieceMovedEventArgs(ok, depart, arrive));
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
        protected virtual void OnTalkToPlayer(string message)
        {
            TalkToPlayer?.Invoke(this, new TalkToPlayerEventArgs(message));
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
            if (caseA.Onthis.HasValue)
            {
                Joueur1.Liste_Piece.Remove(caseA.Onthis.Value);
                Joueur2.Liste_Piece.Remove(caseA.Onthis.Value);
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

        public bool AppartientJC(Piece piece)
        {
            if (JoueurCourant.appartient(piece)){
                OnAppartient(true, piece.Proprietaire);
                return true;
            }
            OnAppartient(false, piece.Proprietaire);
            return false;
        }

        public void Start()
        {
            while (!isFini())
            {
                ChangePlayer();

                OnTalkToPlayer("Qu'elle piece bouger ?");

                Case[] coup = AskMoove(this.Plateau.width, this.Plateau.height, this);
                MovePiece(coup[0], coup[1], this.Plateau);
            }
        }
    }
}

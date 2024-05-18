using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    abstract public class Joueur
    {

        /**
         *\ brief Vérifie si une pièce appartient à ce joueur
         *\ param piece la pièce dont on veut vérifier l'appartenence
         *\ return vrai si la pièce lui appartient, faux dans le cas contraire
         */
        public bool appartient(Piece piece)
        {
            if (piece.Proprietaire == this)
            {
                return true;
            }
            return false;
        }

        abstract public Case[] ChoisirCoup(Game game);
        public List<Piece> Liste_Piece { get; private set; }

        private string Identifiant { get; init; }

        /**
         *\ brief Constructeur de Joueur
         *\ param identifiant nom du joueur
         */
        public Joueur(string identifiant)
        {
            Identifiant = identifiant;
            Liste_Piece = new List<Piece>();
        }


        /**
         *\ brief Affichage des joueur
         *\ return l'affichage des joueurs
         */
        public override string ToString()
        {
            return $"{Identifiant}";
        }

        public class RandomJoueur : Joueur
        {

            /**
             *\ brief Constructeur de case
             *\ param x coordonnée en abscisse
             */
            public override Case[] ChoisirCoup(Game game)
            {
                System.Threading.Thread.Sleep(1000);
                Case[] cout = new Case[2];
                Piece choisit = this.Liste_Piece[new Random().Next(0, this.Liste_Piece.Count)];
                int x = 0;
                int y = 0;
                for (int i = 0; i < game.Plateau.width; i++)
                {
                    for (int j = 0; j < game.Plateau.height; j++)
                    {
                        if (game.Plateau[i, j].Onthis.HasValue)
                        {
                            if (game.Plateau[i, j].Onthis.Value == choisit)
                            {
                                x=i; y=j;
                                i = game.Plateau.width;
                                j = game.Plateau.height;
                            }
                        }
                    }
                }
                List<Case> possibilite = game.Regle.CoupPossible(game.Plateau[x, y], game);

                cout[0] = game.Plateau[x, y];
                cout[1] = possibilite[new Random().Next(0, possibilite.Count)];

                return cout;
            }
            public RandomJoueur(string identifiant) : base(identifiant)
            { }
        }

        public class HumainJoueur : Joueur
        {
            public override Case[] ChoisirCoup(Game game)
            {
                Case[] cout = new Case[2];
                return cout;
            }
            public HumainJoueur(string identifiant) : base(identifiant)
            { }
        }
    }
}

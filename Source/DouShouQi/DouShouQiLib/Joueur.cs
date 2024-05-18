using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    abstract public class Joueur
    {

        /// <summary>
        ///     Vérifie si une pièce appartient à joueur
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>bool</returns>
        public bool Appartient(Piece piece)
        {
            if (piece.Proprietaire == this)
            {
                return true;
            }
            return false;
        }

        abstract public Case[] ChoisirCoup(Game game);

        /// <summary>
        ///    Liste des pièces que possède le joueur
        /// </summary>
        public List<Piece> Liste_Piece { get; private set; }

        /// <summary>
        ///    Nom du joueur
        /// </summary>
        private string Identifiant { get; init; }

        /// <summary>
        ///     Constructeur de Joueur
        /// </summary>
        /// <param name="identifiant"></param>
        public Joueur(string identifiant)
        {
            Identifiant = identifiant;
            Liste_Piece = new List<Piece>();
        }


        /// <summary>
        ///     Affichage des Joueur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Identifiant}";
        }

        public class RandomJoueur : Joueur
        {

            /// <summary>
            ///     Choisit un coup aléatoirement parmit une liste de tous les coups possible
            /// </summary>
            /// <param name="game"></param>
            /// <returns>Un coup possible</returns>
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

            /// <summary>
            ///    Constructeur d'un joueur ordinateur
            /// </summary>
            /// <param name="identifiant"></param>
            public RandomJoueur(string identifiant) : base(identifiant)
            { }
        }

        public class HumainJoueur : Joueur
        {
            /// <summary>
            ///    Ne sert pas, car le joueur humain choisira lui même son coup
            /// </summary>
            /// <param name="game"></param>
            /// <returns>Rien</returns>
            public override Case[] ChoisirCoup(Game game)
            {
                Case[] cout = new Case[2];
                return cout;
            }

            /// <summary>
            ///    Constructeur d'un joueur humain
            /// </summary>
            /// <param name="identifiant"></param>
            public HumainJoueur(string identifiant) : base(identifiant)
            { }
        }
    }
}

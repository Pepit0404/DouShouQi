using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class regleOrigin : IRegles
    {
        private Game PlacementAnimaux(Game game)
        {

            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.souris, game.Joueur1));
            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.chat, game.Joueur1));
            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.chien, game.Joueur1));
            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.loup, game.Joueur1));
            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.leopard, game.Joueur1));
            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.tigre, game.Joueur1));
            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.lion, game.Joueur1));
            game.Joueur1.Liste_Piece.Add(new Piece(PieceType.elephant, game.Joueur1));

            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.souris, game.Joueur2));
            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.chat, game.Joueur2));
            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.chien, game.Joueur2));
            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.loup, game.Joueur2));
            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.leopard, game.Joueur2));
            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.tigre, game.Joueur2));
            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.lion, game.Joueur2));
            game.Joueur2.Liste_Piece.Add(new Piece(PieceType.elephant, game.Joueur2));

            game.Plateau.echequier[2, 0].Onthis = game.Joueur1.Liste_Piece[0];
            game.Plateau.echequier[1, 5].Onthis = game.Joueur1.Liste_Piece[1];
            game.Plateau.echequier[1, 1].Onthis = game.Joueur1.Liste_Piece[2];
            game.Plateau.echequier[2, 4].Onthis = game.Joueur1.Liste_Piece[3];
            game.Plateau.echequier[2, 2].Onthis = game.Joueur1.Liste_Piece[4];
            game.Plateau.echequier[0, 6].Onthis = game.Joueur1.Liste_Piece[5];
            game.Plateau.echequier[0, 0].Onthis = game.Joueur1.Liste_Piece[6];
            game.Plateau.echequier[2, 6].Onthis = game.Joueur1.Liste_Piece[7];


            game.Plateau.echequier[6, 6].Onthis = game.Joueur2.Liste_Piece[0];
            game.Plateau.echequier[7, 1].Onthis = game.Joueur2.Liste_Piece[1];
            game.Plateau.echequier[7, 5].Onthis = game.Joueur2.Liste_Piece[2];
            game.Plateau.echequier[6, 2].Onthis = game.Joueur2.Liste_Piece[3];
            game.Plateau.echequier[6, 4].Onthis = game.Joueur2.Liste_Piece[4];
            game.Plateau.echequier[8, 0].Onthis = game.Joueur2.Liste_Piece[5];
            game.Plateau.echequier[8, 6].Onthis = game.Joueur2.Liste_Piece[6];
            game.Plateau.echequier[6, 0].Onthis = game.Joueur2.Liste_Piece[7];
            return game;
        }
        public void initPlateau(Game game)
        {
            for (int i = 0; i < game.Plateau.echequier.GetLength(0); i++)
            {
                for (int j = 0; j < game.Plateau.echequier.GetLength(1); j++)
                {
                    if (j == 3 && (i == 0 || i == 8))
                    {
                        game.Plateau.echequier[i, j] = new Case(i, j, CaseType.Taniere);
                    }
                    else if (((j == 2 || j == 4) && (i == 0 || i == 8)) || ((i == 1 || i == 7) && j == 3))
                    {
                        game.Plateau.echequier[i, j] = new Case(i, j, CaseType.Piege);
                    }
                    else if (((j == 4 || j == 5) && (i == 3 || i == 4 || i == 5)) || ((j == 1 || j == 2) && (i == 3 || i == 4 || i == 5)))
                    {
                        game.Plateau.echequier[i, j] = new Case(i, j, CaseType.Eau);
                    }
                    else
                    {
                        game.Plateau.echequier[i, j] = new Case(i, j, CaseType.Terre);
                    }
                }
            }
            game = PlacementAnimaux(game);
        }
        public bool Manger(PieceType meurtrier, PieceType victime)

        {
            if (meurtrier == PieceType.souris && victime == PieceType.elephant)
            {
                return true;
            }
            if (meurtrier == PieceType.elephant && victime == PieceType.souris)
            {
                return false;
            }
            if ((int)meurtrier >= (int)victime)
            {
                return true;
            }
            return false;
        }
        public bool PouvoirBouger(Case caseActu, Case caseAdja, Plateau plateau)
        {
            // Vérifie si ce n'est pas en diagonale
            if (caseAdja.X != caseActu.X && caseAdja.Y != caseActu.Y)
            {
                return false;
            }
            // Vérfie si il y a bien une piece sur la case d'origine
            if (!caseActu.Onthis.HasValue)
            {
                return false;
            }
            if (!caseAdja.Onthis.HasValue)
            {
                if (caseActu.Onthis.Value.Type != PieceType.souris && caseAdja.Type == CaseType.Eau)
                {
                    return false;
                }
            }
            else
            {
                if ((!Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type) || (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre)) || caseAdja.Type != CaseType.Piege)
                {
                    return false;
                }
            }
            // vérifie si la case visé n'est pas celle adjacente
            if (caseAdja.X != caseActu.X - 1 && caseAdja.Y != caseActu.Y + 1 && caseAdja.X != caseActu.X + 1 && caseAdja.Y != caseActu.Y - 1)
            {
                // cas où l'animal peut sauté par dessus la riviére
                if ((caseActu.Onthis.Value.Type == PieceType.tigre || caseActu.Onthis.Value.Type == PieceType.lion))
                {
                    if (caseAdja.X != caseActu.X)
                    {
                        int diff = caseAdja.X - caseActu.X;
                        diff /= Math.Abs(diff);
                        int i = caseActu.X + diff;
                        while (i != caseAdja.X)
                        {
                            Console.WriteLine(plateau.echequier[i, caseAdja.Y]);
                            if (plateau.echequier[i, caseAdja.Y].Type != CaseType.Eau)
                            {
                                return false;
                            }
                            i += diff;
                        }
                        return true;
                    }
                    if (caseAdja.Y != caseActu.Y)
                    {
                        int diff = caseAdja.Y - caseActu.Y;
                        diff /= Math.Abs(diff);
                        int i = caseActu.Y + diff;
                        while (i != caseAdja.Y)
                        {
                            Console.WriteLine(plateau.echequier[caseAdja.X, i]);
                            if (plateau.echequier[caseAdja.X, i].Type != CaseType.Eau)
                            {
                                return false;
                            }
                            i += diff;
                        }
                        return true;
                    }
                }
                return false;
            }
            return true;

        }

        public bool EstFini(Game game)
        {
            if (game.Plateau.echequier[0, 3].Onthis.HasValue)
            {
                Joueur joueur = game.Plateau.echequier[0, 3].Onthis.Value.Proprietaire;
                if (joueur == game.Joueur2)
                {
                    return true;
                }
            }

            if (game.Plateau.echequier[8, 3].Onthis.HasValue)
            {
                Joueur joueur = game.Plateau.echequier[8, 3].Onthis.Value.Proprietaire;
                if (joueur == game.Joueur1)
                {
                    return true;
                }
            }

            if (game.Joueur1.Liste_Piece.Count == 0 || game.Joueur2.Liste_Piece.Count == 0)
            {
                return true;
            }

            return false;
        }

        public List<Case> CoupPossible(Case caseActu, Game game)
        {
            List<Case> posssible = new List<Case>();
            for (int i = 0; i < game.Plateau.width; i++)
            {
                for (int j = 0; j < game.Plateau.height; j++)
                {

                    if (PouvoirBouger(caseActu, game.Plateau[i, j], game.Plateau))
                    {
                        posssible.Add(game.Plateau[i, j]);
                    }
                }
            }
            return posssible;
        }

    }
}

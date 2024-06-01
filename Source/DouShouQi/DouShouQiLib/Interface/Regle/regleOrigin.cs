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

        private bool IsPiege(Case caseAdja)
        {
            if (caseAdja.Type == CaseType.Piege)
            {
                return true;
            }
            return false;
        }

        public bool PouvoirBouger(Case caseActu, Case caseAdja, Plateau plateau)
        {
            // Si la case actuelle est vide, retournez false
            if (!caseActu.Onthis.HasValue)
            {
                return false;
            }

            if (caseActu == caseAdja) 
            {

                return false;
            }

            // Vérifier si les cases sont adjacentes
            if (IsAdja(caseActu, caseAdja))
            {
                // Si la case adjacente est occupée, vérifier si l'on peut la manger
                if (caseAdja.Onthis.HasValue && !Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type))
                {
                    if (!IsPiege(caseAdja))
                    {
                        return false;
                    }
                }

                // Vérifier si l'animal dans l'eau n'essaye pas de manger un qui n'est pas dans l'eau
                if (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre && caseAdja.Onthis.HasValue)
                {
                    return false;
                }

                // Vérifier si l'animal peut aller sur l'eau
                if (caseAdja.Type == CaseType.Eau && !CanGoWater(caseActu, caseAdja))
                {
                    return false;
                }

                return true;
            }

            // Vérifier si l'on peut sauter
            if (CanJump(caseActu, caseAdja, plateau))
            {
                // Empêcher la souris de manger en sortant de l'eau
                if (caseActu.Type == CaseType.Eau && caseAdja.Onthis.HasValue && caseActu.Onthis.Value.Type == PieceType.souris)
                {
                    return false;
                }
                if (caseActu.Type == CaseType.Terre && caseAdja.Onthis.HasValue && caseActu.Onthis.Value.Type == PieceType.souris)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private bool CanGoWater(Case caseActu, Case caseAdja)
        {
            if (caseActu.Onthis.Value.Type == PieceType.souris)
            {
                if (caseActu.Type!=caseAdja.Type && caseAdja.Onthis.HasValue)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private bool IsAdja(Case caseActu, Case caseAdja)
        {
            if (caseActu.X == caseAdja.X && Math.Abs(caseActu.Y - caseAdja.Y) == 1)
            {
                return true;
            }
            if (caseActu.Y == caseAdja.Y && Math.Abs(caseActu.X - caseAdja.X) == 1)
            {
                return true;
            }
            return false;
        }

        private bool CanJump(Case caseActu, Case caseAdja, Plateau plateau)
        {
            if (caseActu.Onthis.Value.Type == PieceType.tigre || caseActu.Onthis.Value.Type == PieceType.lion)
            {
                if (caseActu.X == caseAdja.X)
                {
                    int minY = Math.Min(caseActu.Y, caseAdja.Y);
                    int maxY = Math.Max(caseActu.Y, caseAdja.Y);
                    for (int y = minY + 1; y < maxY; y++)
                    {
                        if (plateau.echequier[caseActu.X, y].Type != CaseType.Eau)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                if (caseActu.Y == caseAdja.Y)
                {
                    int minX = Math.Min(caseActu.X, caseAdja.X);
                    int maxX = Math.Max(caseActu.X, caseAdja.X);
                    for (int x = minX + 1; x < maxX; x++)
                    {
                        if (plateau.echequier[x, caseActu.Y].Type != CaseType.Eau)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
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

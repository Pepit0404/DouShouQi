using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class regleVariente : IRegles
    {
        public string name { get; init; } = "variente";

        /// <summary>
        ///    affecte des nouvelles pièces aux joueurs puis les place sur le plateau
        /// </summary>
        /// <param Game="game"></param>
        /// <returns>La partie mise à jour</returns>
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

        /// <summary>
        ///    Place les différentes cases au bon endroit dans le plateau
        /// </summary>
        /// <param Game="game"></param>
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

        /// <summary>
        ///    Définie les conditions ou une pièce peut en manger une autre
        /// </summary>
        /// <param PieceType="meurtrier">La pièce qui veut manger</param>
        /// <param PieceType="victime">La pièce qui se fait manger</param>
        /// <returns>true si la pièce peut manger l'autre et faux si l'inverse</returns>
        public bool Manger(PieceType meurtrier, PieceType victime)
        {
            if (meurtrier == PieceType.souris && victime == PieceType.elephant)
            {
                return true;
            }
            if ((int)meurtrier >= (int)victime)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///    Vérifie si une case est un piège
        /// </summary>
        /// <param Case="caseAdja"></param>
        /// <returns>true si la case est piège et faux si l'inverse</returns>
        private bool IsPiege(Case caseAdja)
        {
            if (caseAdja.Type == CaseType.Piege)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///    Vérifie si un coup est valide
        /// </summary>
        /// <param Case="caseActu">Case de départ</param>
        /// <param Case="caseAdja">Case d'arrivée</param>
        /// <param Plateau="plateau"></param>
        /// <returns>true si le coup est valide et faux si l'inverse</returns>
        public bool PouvoirBouger(Case caseActu, Case caseAdja, Plateau plateau)
        {
            if (!CaseActuV(caseActu, caseAdja))
            {
                return false;
            }

            // Vérifier si les cases sont adjacentes
            if (IsAdja(caseActu, caseAdja))
            {
                if (!AppartientPiece(caseActu, caseAdja))
                {
                    return false;
                }
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
                return true;
            }




            return false;
        }
        private bool AppartientPiece(Case caseActu, Case caseAdja)
        {
            if (caseAdja.Onthis.HasValue)
            {
                if (caseActu.Onthis.Value.Proprietaire == caseAdja.Onthis.Value.Proprietaire)
                {
                    return false;
                }
            }
            return true;
        }
        private bool CaseActuV(Case caseActu, Case caseAdja)
        {
            // Si la case actuelle est vide, retournez false
            if (!caseActu.Onthis.HasValue)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///    Vérifie si une pièce peut aller sur une case eau
        /// </summary>
        /// <param Case="caseActu">Case de la pièce</param>
        /// <param Case="caseAdja">Case d'eau</param>
        /// <returns>true si le coup est valide et faux si l'inverse</returns>
        private bool CanGoWater(Case caseActu, Case caseAdja)
        {
            if (caseActu.Onthis.Value.Type == PieceType.souris || caseActu.Onthis.Value.Type == PieceType.chien)
            {
                if (caseActu.Type != caseAdja.Type && caseAdja.Onthis.HasValue)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        ///    Vérifie si deux cases sont côte à côte
        /// </summary>
        /// <param Case="caseActu"></param>
        /// <param Case="caseAdja"></param>
        /// <returns>true si les case sont à côtées et faux si l'inverse</returns>
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

        /// <summary>
        ///    Vérifie si une pièce peut sauter
        /// </summary>
        /// <param Case="caseActu">Case de la pièce</param>
        /// <param Case="caseAdja">Case d'arrivée</param>
        /// <returns>true si la pièce peut sauter et faux si l'inverse</returns>
        private bool CanJump(Case caseActu, Case caseAdja, Plateau plateau)
        {
            if (caseActu.Onthis.Value.Type == PieceType.tigre || caseActu.Onthis.Value.Type == PieceType.lion)
            {
                if (caseActu.X == caseAdja.X)
                {
                    if (CanJumpX(caseActu, caseAdja, plateau))
                    { return true; }
                }
                if (caseActu.Y == caseAdja.Y)
                {
                    if (CanJumpY(caseActu, caseAdja, plateau))
                    { return true; }
                }
            }
            return false;
        }
        
        private bool CanJumpX(Case caseActu, Case caseAdja, Plateau plateau)
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
        private bool CanJumpY(Case caseActu, Case caseAdja, Plateau plateau)
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
        
        /// <summary>
        ///    Vérifie si la partie est terminé
        /// </summary>
        /// <param Game="game"></param>
        /// <returns>true si la partie est terminé et faux si l'inverse</returns>
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

        /// <summary>
        ///    Vérifie les coups possibles depuis une case
        /// </summary>
        /// <param Case="caseActu"></param>
        /// <param Game="game"></param>
        /// <returns>Une liste des coups possibles</returns>
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

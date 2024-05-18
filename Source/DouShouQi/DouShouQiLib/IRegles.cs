using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {

        void initPlateau(Game game);
        bool Manger(PieceType meurtrier, PieceType victime);
        bool PouvoirBouger(Case caseActu, Case caseAdja, Plateau plateau);

        bool EstFini(Game game);
    }

    public class regleOrigin : IRegles
    {
        private Game PlacementAnimaux(Game game)
        {

            game.Liste_Piece_J1.Add(new Piece(PieceType.souris, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.chat, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.chien, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.loup, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.leopard, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.tigre, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.lion, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.elephant, game.Joueur1));

            game.Liste_Piece_J2.Add(new Piece(PieceType.souris, game.Joueur2));
            game.Liste_Piece_J2.Add(new Piece(PieceType.chat, game.Joueur2));
            game.Liste_Piece_J2.Add(new Piece(PieceType.chien, game.Joueur2));
            game.Liste_Piece_J2.Add(new Piece(PieceType.loup, game.Joueur2));
            game.Liste_Piece_J2.Add(new Piece(PieceType.leopard, game.Joueur2));
            game.Liste_Piece_J2.Add(new Piece(PieceType.tigre, game.Joueur2));
            game.Liste_Piece_J2.Add(new Piece(PieceType.lion, game.Joueur2));
            game.Liste_Piece_J2.Add(new Piece(PieceType.elephant, game.Joueur2));

            game.Plateau.echequier[2, 0].Onthis = game.Liste_Piece_J1[0];
            game.Plateau.echequier[1, 5].Onthis = game.Liste_Piece_J1[1];
            game.Plateau.echequier[1, 1].Onthis = game.Liste_Piece_J1[2];
            game.Plateau.echequier[2, 4].Onthis = game.Liste_Piece_J1[3];
            game.Plateau.echequier[2, 2].Onthis = game.Liste_Piece_J1[4];
            game.Plateau.echequier[0, 6].Onthis = game.Liste_Piece_J1[5];
            game.Plateau.echequier[0, 0].Onthis = game.Liste_Piece_J1[6];
            game.Plateau.echequier[2, 6].Onthis = game.Liste_Piece_J1[7];


            game.Plateau.echequier[6, 6].Onthis = game.Liste_Piece_J2[0];
            game.Plateau.echequier[7, 1].Onthis = game.Liste_Piece_J2[1];
            game.Plateau.echequier[7, 5].Onthis = game.Liste_Piece_J2[2];
            game.Plateau.echequier[6, 2].Onthis = game.Liste_Piece_J2[3];
            game.Plateau.echequier[6, 4].Onthis = game.Liste_Piece_J2[4];
            game.Plateau.echequier[8, 0].Onthis = game.Liste_Piece_J2[5];
            game.Plateau.echequier[8, 6].Onthis = game.Liste_Piece_J2[6];
            game.Plateau.echequier[6, 0].Onthis = game.Liste_Piece_J2[7];
            return game;
        }
        public void initPlateau(Game game)
        {
            for (int i = 0; i < game.Plateau.echequier.GetLength(0); i++)
            {
                for (int j = 0; j < game.Plateau.echequier.GetLength(1); j++)
                {
                    if (j == 3 && ( i == 0 || i == 8))
                    {
                        game.Plateau.echequier[i, j] = new Case(i, j, CaseType.Taniere);
                    }
                    else if (((j== 2 || j == 4) && (i == 0 || i == 8)) || ((i== 1 || i==7) &&  j==3))
                    {
                        game.Plateau.echequier[i, j] = new Case(i, j, CaseType.Piege);
                    }
                    else if (((j==4 || j == 5) && (i==3 || i == 4 || i == 5)) || ((j==1 || j==2) && (i==3 || i==4 || i==5)))
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
            // Si la case actuelle est vide, retournez false
            if (!caseActu.Onthis.HasValue)
            {
                return false;
            }

            if (IsAdja(caseActu, caseAdja))
            {
                // Vérifier si l'animal peut aller sur l'eau
                if (caseAdja.Type == CaseType.Eau && !CanGoWater(caseActu,caseAdja))
                {
                    return false;
                }

                // Si la case adjacente est occupée, vérifier si l'on peut la manger
                if (caseAdja.Onthis.HasValue)
                {
                    // Empêcher la souris de manger en sortant de l'eau
                    if (caseActu.Type == CaseType.Eau && caseActu.Onthis.Value.Type == PieceType.souris)
                    {
                        return false;
                    }
                    if (!Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type))
                    {
                        return false;
                    }
                }

                return true;
            }

            // Vérifier si l'on peut sauter
            if (CanJump(caseActu, caseAdja, plateau))
            {
                return true;
            }

            // Vérifier si l'animal peut aller sur l'eau
            if (caseAdja.Type == CaseType.Eau && !CanGoWater(caseActu, caseAdja))
            {
                return false;
            }

            return false;
        }

        private bool CanGoWater(Case caseActu, Case caseAdja)
        {
            return caseActu.Onthis.Value.Type == PieceType.souris;
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

            if(game.Liste_Piece_J1.Count == 0 || game.Liste_Piece_J2.Count== 0)
            {
                return true;
            }

            return false;
        }

    }

    public class regleVariente : IRegles
    {
        private Game PlacementAnimaux(Game game)
        {

            game.Liste_Piece_J1.Add(new Piece(PieceType.souris, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.chat, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.chien, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.loup, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.leopard, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.tigre, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.lion, game.Joueur1));
            game.Liste_Piece_J1.Add(new Piece(PieceType.elephant, game.Joueur1));

            game.Liste_Piece_J2.Add(new Piece(PieceType.souris, game.Joueur2));
            //game.Liste_Piece_J2.Add(new Piece(PieceType.chat, game.Joueur2));
            //game.Liste_Piece_J2.Add(new Piece(PieceType.chien, game.Joueur2));
            //game.Liste_Piece_J2.Add(new Piece(PieceType.loup, game.Joueur2));
            //game.Liste_Piece_J2.Add(new Piece(PieceType.leopard, game.Joueur2));
            //game.Liste_Piece_J2.Add(new Piece(PieceType.tigre, game.Joueur2));
            //game.Liste_Piece_J2.Add(new Piece(PieceType.lion, game.Joueur2));
            //game.Liste_Piece_J2.Add(new Piece(PieceType.elephant, game.Joueur2));

            game.Plateau.echequier[2, 0].Onthis = game.Liste_Piece_J1[0];
            game.Plateau.echequier[1, 5].Onthis = game.Liste_Piece_J1[1];
            game.Plateau.echequier[1, 1].Onthis = game.Liste_Piece_J1[2];
            game.Plateau.echequier[2, 4].Onthis = game.Liste_Piece_J1[3];
            game.Plateau.echequier[2, 2].Onthis = game.Liste_Piece_J1[4];
            game.Plateau.echequier[0, 6].Onthis = game.Liste_Piece_J1[5];
            game.Plateau.echequier[0, 0].Onthis = game.Liste_Piece_J1[6];
            game.Plateau.echequier[2, 6].Onthis = game.Liste_Piece_J1[7];


            game.Plateau.echequier[3, 3].Onthis = game.Liste_Piece_J2[0];
            //game.Plateau.echequier[7, 1].Onthis = game.Liste_Piece_J2[1];
            //game.Plateau.echequier[7, 6].Onthis = game.Liste_Piece_J2[2];
            //game.Plateau.echequier[6, 2].Onthis = game.Liste_Piece_J2[3];
            //game.Plateau.echequier[6, 4].Onthis = game.Liste_Piece_J2[4];
            //game.Plateau.echequier[8, 0].Onthis = game.Liste_Piece_J2[5];
            //game.Plateau.echequier[8, 7].Onthis = game.Liste_Piece_J2[6];
            //game.Plateau.echequier[6, 0].Onthis = game.Liste_Piece_J2[7];
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
            if ((int)meurtrier >= (int)victime)
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

            if (IsAdja(caseActu, caseAdja))
            {
                // Vérifier si l'animal peut aller sur l'eau
                if (caseAdja.Type == CaseType.Eau && !CanGoWater(caseActu, caseAdja))
                {
                    return false;
                }

                // Si la case adjacente est occupée, vérifier si l'on peut la manger
                if (caseAdja.Onthis.HasValue)
                {
                    // Empêcher la souris de manger en sortant de l'eau
                    if (caseActu.Type == CaseType.Eau && caseActu.Onthis.Value.Type == PieceType.souris)
                    {
                        return false;
                    }
                    if (!Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type))
                    {
                        return false;
                    }
                }

                return true;
            }

            // Vérifier si l'on peut sauter
            if (CanJump(caseActu, caseAdja, plateau))
            {
                return true;
            }

            // Vérifier si l'animal peut aller sur l'eau
            if (caseAdja.Type == CaseType.Eau && !CanGoWater(caseActu, caseAdja))
            {
                return false;
            }

            return false;
        }

        private bool CanGoWater(Case caseActu, Case caseAdja)
        {
            if (caseActu.Onthis.Value.Type == PieceType.souris || caseActu.Onthis.Value.Type == PieceType.souris)
            {
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

            if (game.Liste_Piece_J1.Count == 0 || game.Liste_Piece_J2.Count == 0)
            {
                return true;
            }

            return false;
        }

    }
}

  

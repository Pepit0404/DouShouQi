using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {

        void initPlateau(Game game);
        bool Manger(PieceType meurtrier, PieceType victime);
        bool PouvoirBouger(Case caseActu, Case caseAdja);


    }

    public class regleOrigin : IRegles
    {
        private Game PlacementAnimaux(Game game)
        {
            game.Plateau.echequier[2, 0].Onthis = new Piece(PieceType.souris, game.Joueur1);
            game.Plateau.echequier[2, 6].Onthis = new Piece(PieceType.elephant, game.Joueur1);
            game.Plateau.echequier[1, 1].Onthis = new Piece(PieceType.chien, game.Joueur1);
            game.Plateau.echequier[0, 6].Onthis = new Piece(PieceType.tigre, game.Joueur1);
            game.Plateau.echequier[0, 0].Onthis = new Piece(PieceType.lion, game.Joueur1);
            game.Plateau.echequier[1, 5].Onthis = new Piece(PieceType.chat, game.Joueur1);
            game.Plateau.echequier[2, 2].Onthis = new Piece(PieceType.leopard, game.Joueur1);
            game.Plateau.echequier[2, 4].Onthis = new Piece(PieceType.loup, game.Joueur1);

            game.Plateau.echequier[7, 5].Onthis = new Piece(PieceType.chien, game.Joueur2);
            game.Plateau.echequier[6, 6].Onthis = new Piece(PieceType.souris, game.Joueur2);
            game.Plateau.echequier[6, 0].Onthis = new Piece(PieceType.elephant, game.Joueur2);
            game.Plateau.echequier[6, 2].Onthis = new Piece(PieceType.loup, game.Joueur2);
            game.Plateau.echequier[7, 1].Onthis = new Piece(PieceType.chat, game.Joueur2);
            game.Plateau.echequier[6, 5].Onthis = new Piece(PieceType.leopard, game.Joueur2);
            game.Plateau.echequier[8, 0].Onthis = new Piece(PieceType.tigre, game.Joueur2);
            game.Plateau.echequier[8, 6].Onthis = new Piece(PieceType.lion, game.Joueur2);
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
        public bool PouvoirBouger(Case caseActu, Case caseAdja)
        {
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
                if (!Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type) || (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre))
                {
                    return false;
                }


            }
            return true;
        }


    }

    public class regleVariente : IRegles
    {
        private Game PlacementAnimaux(Game game)
        {
            game.Plateau.echequier[2, 0].Onthis = new Piece(PieceType.souris, game.Joueur1);
            game.Plateau.echequier[2, 6].Onthis = new Piece(PieceType.elephant, game.Joueur1);
            game.Plateau.echequier[1, 1].Onthis = new Piece(PieceType.chien, game.Joueur1);
            game.Plateau.echequier[0, 6].Onthis = new Piece(PieceType.tigre, game.Joueur1);
            game.Plateau.echequier[0, 0].Onthis = new Piece(PieceType.lion, game.Joueur1);
            game.Plateau.echequier[1, 5].Onthis = new Piece(PieceType.chat, game.Joueur1);
            game.Plateau.echequier[2, 2].Onthis = new Piece(PieceType.leopard, game.Joueur1);
            game.Plateau.echequier[2, 4].Onthis = new Piece(PieceType.loup, game.Joueur1);

            game.Plateau.echequier[7, 5].Onthis = new Piece(PieceType.chien, game.Joueur2);
            game.Plateau.echequier[6, 6].Onthis = new Piece(PieceType.souris, game.Joueur2);
            game.Plateau.echequier[6, 0].Onthis = new Piece(PieceType.elephant, game.Joueur2);
            game.Plateau.echequier[6, 2].Onthis = new Piece(PieceType.loup, game.Joueur2);
            game.Plateau.echequier[7, 1].Onthis = new Piece(PieceType.chat, game.Joueur2);
            game.Plateau.echequier[6, 5].Onthis = new Piece(PieceType.leopard, game.Joueur2);
            game.Plateau.echequier[8, 0].Onthis = new Piece(PieceType.tigre, game.Joueur2);
            game.Plateau.echequier[8, 6].Onthis = new Piece(PieceType.lion, game.Joueur2);
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
        public bool PouvoirBouger(Case caseActu, Case caseAdja)
        {
            if (!caseActu.Onthis.HasValue)
            {
                return false;
            }
            if (!caseAdja.Onthis.HasValue)
            {
                if ((caseActu.Onthis.Value.Type != PieceType.souris && caseActu.Onthis.Value.Type != PieceType.chien) && caseAdja.Type == CaseType.Eau)
                {
                    return false;
                }

            }
            else
            {
                if ((caseActu.Onthis.Value.Type != PieceType.souris && caseActu.Onthis.Value.Type != PieceType.chien) && caseAdja.Type == CaseType.Eau)
                {
                    return false;
                }
                if (!Manger(caseActu.Onthis.Value.Type, caseAdja.Onthis.Value.Type) || (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre))
                {
                    return false;
                }

            }
            return true;
        }
    }
}

  

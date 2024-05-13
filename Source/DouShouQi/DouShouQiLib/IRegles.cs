using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {

        Plateau initPlateau();
        bool Manger(PieceType meurtrier, PieceType victime);
        bool PouvoirBouger(Case caseActu, Case caseAdja);

    }

    public class regleOrigin : IRegles
    {
        private Plateau PlacementAnimaux(Plateau plateau)
        {
            plateau.echequier[2, 0].Onthis = new Piece(PieceType.souris);
            plateau.echequier[2, 6].Onthis = new Piece(PieceType.elephant);
            plateau.echequier[1, 1].Onthis = new Piece(PieceType.chien);
            plateau.echequier[0, 6].Onthis = new Piece(PieceType.tigre);
            plateau.echequier[0, 0].Onthis = new Piece(PieceType.lion);
            plateau.echequier[1, 5].Onthis = new Piece(PieceType.chat);
            plateau.echequier[2, 2].Onthis = new Piece(PieceType.leopard);
            plateau.echequier[2, 4].Onthis = new Piece(PieceType.loup);
            plateau.echequier[7, 5].Onthis = new Piece(PieceType.chien);
            plateau.echequier[6, 6].Onthis = new Piece(PieceType.souris);
            plateau.echequier[6, 0].Onthis = new Piece(PieceType.elephant);
            plateau.echequier[6, 2].Onthis = new Piece(PieceType.loup);
            plateau.echequier[7, 1].Onthis = new Piece(PieceType.chat);
            plateau.echequier[6, 4].Onthis = new Piece(PieceType.leopard);
            plateau.echequier[8, 0].Onthis = new Piece(PieceType.tigre);
            plateau.echequier[8, 6].Onthis = new Piece(PieceType.lion);
            return plateau;
        }
        public Plateau initPlateau()
        {
            Plateau plateau = new Plateau();
            for (int i = 0; i < plateau.echequier.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.echequier.GetLength(1); j++)
                {
                    if (j == 3 && ( i == 0 || i == 8))
                    {
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Taniere);
                    }
                    else if (((j== 2 || j == 4) && (i == 0 || i == 8)) || ((i== 1 || i==7) &&  j==3))
                    {
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Piege);
                    }
                    else if (((j==4 || j == 5) && (i==3 || i == 4 || i == 5)) || ((j==1 || j==2) && (i==3 || i==4 || i==5)))
                    {
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Eau);
                    }
                    else
                    {
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Terre);
                    }
                }
            }
            plateau = PlacementAnimaux(plateau);
            return plateau;
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
        private Plateau PlacementAnimaux(Plateau plateau)
        {
            plateau.echequier[2, 0].Onthis = new Piece(PieceType.souris);
            plateau.echequier[2, 6].Onthis = new Piece(PieceType.elephant);
            plateau.echequier[1, 1].Onthis = new Piece(PieceType.chien);
            plateau.echequier[0, 6].Onthis = new Piece(PieceType.tigre);
            plateau.echequier[0, 0].Onthis = new Piece(PieceType.lion);
            plateau.echequier[1, 5].Onthis = new Piece(PieceType.chat);
            plateau.echequier[2, 2].Onthis = new Piece(PieceType.leopard);
            plateau.echequier[2, 4].Onthis = new Piece(PieceType.loup);
            plateau.echequier[7, 5].Onthis = new Piece(PieceType.chien);
            plateau.echequier[6, 6].Onthis = new Piece(PieceType.souris);
            plateau.echequier[6, 0].Onthis = new Piece(PieceType.elephant);
            plateau.echequier[6, 2].Onthis = new Piece(PieceType.loup);
            plateau.echequier[7, 1].Onthis = new Piece(PieceType.chat);
            plateau.echequier[6, 4].Onthis = new Piece(PieceType.leopard);
            plateau.echequier[8, 0].Onthis = new Piece(PieceType.tigre);
            plateau.echequier[8, 6].Onthis = new Piece(PieceType.lion);
            return plateau;
        }

        public Plateau initPlateau()
        {
            Plateau plateau = new Plateau();
            for (int i = 0; i < plateau.echequier.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.echequier.GetLength(1); j++)
                {
                    if (j == plateau.echequier.GetLength(0) / 2 - 1 && (i == 0 || i == plateau.echequier.GetLength(0) - 1))
                    {
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Taniere);
                    }
                    else if ((j == plateau.echequier.GetLength(0) / 2 - 2 || j == plateau.echequier.GetLength(0) / 2) && (i == 0 || i == plateau.echequier.GetLength(0) - 1))
                    {
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Piege);
                    }
                    else
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Terre);
                }
            }
            plateau = PlacementAnimaux(plateau);
            return plateau;
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
        //public Plateau Bouger(Plateau plateau, Joueur joueur, Piece piece) { }
    }
}

  

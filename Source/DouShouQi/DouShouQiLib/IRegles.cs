using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {

        Plateau initPlateau(Plateau plateau);
        bool Manger(PieceType meurtrier, PieceType victime);
        bool Bouger(Case caseActu, Piece piece, Case caseAdja, Piece? pieceAdja);
    }

    public class regleOrigin : IRegles
    {
        public Plateau initPlateau(Plateau plateau)
        {
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
                        plateau.echequier[i, j] = new Case(i, j, CaseType.Terre);
                }
            }
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
        public bool Bouger(Case caseActu, Piece piece, Case caseAdja, Piece? pieceAdja = null)
        {
            if (pieceAdja == null && caseAdja.Type == CaseType.Eau && piece.Type != PieceType.souris)
            {
                return false;
            }

            if (pieceAdja != null)
            {
                if (caseAdja.Type == CaseType.Eau && (piece.Type != PieceType.souris && piece.Type != PieceType.chien))
                {
                    return false;
                }
                if (caseAdja.Type == CaseType.Terre && caseActu.Type==CaseType.Eau)
                {
                    return false;
                }
                if (piece.Type == PieceType.souris && pieceAdja.Value.Type == PieceType.elephant)
                {
                    return true;
                }
                if (piece.Type < pieceAdja.Value.Type )
                {
                    return false;
                }
                if (piece.Type == PieceType.elephant && pieceAdja.Value.Type == PieceType.souris)
                {
                    return false;
                }
                if (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre)
                {
                    return false;
                }
            }


            return true;
        }

    }

    public class regleVariente : IRegles
    {

        public Plateau initPlateau(Plateau plateau)
        {
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
        public bool Bouger(Case caseActu, Piece piece, Case caseAdja, Piece? pieceAdja = null)
        {
            if (pieceAdja == null && caseAdja.Type == CaseType.Eau && (piece.Type != PieceType.souris && piece.Type != PieceType.chien) )
            {
                return false;
            }

            if (pieceAdja != null )
            {
                if (caseAdja.Type == CaseType.Eau && (piece.Type != PieceType.souris && piece.Type != PieceType.chien))
                {
                    return false;
                }

                if (caseAdja.Type == CaseType.Terre && caseActu.Type == CaseType.Eau)
                {
                    return false;
                }
                if (piece.Type == PieceType.souris && pieceAdja.Value.Type == PieceType.elephant)
                {
                    return true;
                }
                if (piece.Type < pieceAdja.Value.Type)
                {
                    return false;
                }
                
                if (caseActu.Type == CaseType.Eau && caseAdja.Type == CaseType.Terre)
                {
                    return false;
                }
            }


            return true;
        }
    }
        
    }
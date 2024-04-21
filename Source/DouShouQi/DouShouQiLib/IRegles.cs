using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {
        bool Manger(PieceType meurtrier, PieceType victime);
        bool Bouger(Case caseActu, Piece piece, Case caseAdja, Piece? pieceAdja);
    }

    public class regleOrigin : IRegles
    {
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
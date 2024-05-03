using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {
<<<<<<< HEAD
        bool manger(PieceType meurtrier, PieceType victime);
=======
        bool Manger(PieceType meurtrier, PieceType victime);
        bool Bouger(Case caseActu, Piece piece, Case caseAdja, Piece? pieceAdja);
>>>>>>> 261bf2c759289f7bc1e20291ad35993a971a6639
    }

    public class regleOrigin : IRegles
    {
<<<<<<< HEAD
        public bool manger(PieceType meurtrier, PieceType victime)
=======
        public bool Manger(PieceType meurtrier, PieceType victime)
>>>>>>> 261bf2c759289f7bc1e20291ad35993a971a6639
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
<<<<<<< HEAD
        public bool Bouger(Piece piece, Case caseAdja, Piece pieceAdja)
        {
            if (caseAdja.Type == CaseType.Eau && piece.Type != PieceType.souris)
=======
        public bool Bouger(Case caseActu, Piece piece, Case caseAdja, Piece? pieceAdja = null)
        {
            if (pieceAdja == null && caseAdja.Type == CaseType.Eau && piece.Type != PieceType.souris)
>>>>>>> 261bf2c759289f7bc1e20291ad35993a971a6639
            {
                return false;
            }

<<<<<<< HEAD
            if (caseAdja.Onthis != null)
            {
                if (piece.Type < pieceAdja.Type || (piece.Type == PieceType.souris && pieceAdja.Type == PieceType.elephant))
                {
                    return false;
=======
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
>>>>>>> 261bf2c759289f7bc1e20291ad35993a971a6639
                }
                if (piece.Type == PieceType.elephant && pieceAdja.Type == PieceType.souris)
                {
                    return false;
                }
                
            }

<<<<<<< HEAD
=======

>>>>>>> 261bf2c759289f7bc1e20291ad35993a971a6639
            return true;
        }

    }

    public class regleVariente : IRegles
    {
        public bool manger(PieceType meurtrier, PieceType victime)
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
<<<<<<< HEAD
    }
}
=======
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
>>>>>>> 261bf2c759289f7bc1e20291ad35993a971a6639

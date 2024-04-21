using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {
        bool Manger(Piece meurtrier, Piece victime);
        bool Bouger(Piece piece, Case caseAdja);
    }

    public class regleOrigin : IRegles
    {
        public bool Manger(Piece meurtrier, Piece victime)
        {
            if (meurtrier.Type == PieceType.souris && victime.Type == PieceType.elephant)
            {
                return true;
            }
            if (meurtrier.Type == PieceType.elephant && victime.Type == PieceType.souris)
            {
                return false;
            }
            if ((int)meurtrier.Type >= (int)victime.Type)
            {
                return true;
            }
            return false;
        }
        public bool Bouger(Piece piece, Case caseAdja)
        {
            if(caseAdja.Onthis!=null)
            {
                if()
            }
            if (caseAdja.Type == CaseType.Eau && piece.Type == PieceType.souris)
            {
                return true;
            }
            if (caseAdja.Type == CaseType.Eau)
            {
                return false;
            }
            
            return true;
        }
        //changer piece en case pour la praticite

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
    }
}

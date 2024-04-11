using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IRegles
    {
        bool manger(PieceType meurtrier, PieceType victime);
        Case[,] CreateBoard();

    }

    public class regleOrigin : IRegles
    {
        public bool manger(PieceType meurtrier, PieceType victime)
        {
            if (meurtrier==PieceType.souris && victime==PieceType.elephant)
            {
                return true;
            }
            if (meurtrier == PieceType.elephant && victime == PieceType.souris)
            {
                return false;
            }
            if ((int)meurtrier>=(int)victime)
            {
                return true;
            }
            return false;
        }

        public Case[,] CreateBoard()
        {
            Case[,] echequier = new Case[9,7];
            for (int i = 0; i < echequier.GetLength(0); i++)
            {
                for (int j = 0; j < echequier.GetLength(1); j++)
                {
                    echequier[i, j] = new Case(i, j, CaseType.Terre);
                }
            }
            return echequier;
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

        public Case[,] CreateBoard()
        {
            Case[,] echequier = new Case[7, 9];
            for (int i = 0; i < echequier.GetLength(0); i++)
            {
                for (int j = 0; j < echequier.GetLength(1); j++)
                {
                    echequier[i, j] = new Case(i, j, CaseType.Terre);
                }
            }
            return echequier;
        }
    }
}

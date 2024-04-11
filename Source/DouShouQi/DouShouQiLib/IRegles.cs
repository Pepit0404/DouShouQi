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
    }
}

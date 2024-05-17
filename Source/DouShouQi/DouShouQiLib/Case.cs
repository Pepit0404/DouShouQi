using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Case
    {
        public int X {  get; init; }
        
        public int Y { get; init; }

        public Piece? Onthis { get; set; }
   
        public CaseType Type { get; init; }

        public Case(int x, int y, CaseType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public override string ToString()
        {
            if(Onthis  != null)
            {
                return $"[{X},{Y}];{Type};{Onthis}";
            }
            else
            {
                return $"[{X},{Y}];{Type}";
            }
            
        }
    }

    public enum CaseType
    {
        Inconnue,
        Terre,
        Eau,
        Piege,
        Taniere
    }
}

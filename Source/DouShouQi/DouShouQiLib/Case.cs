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
            return $"[{X},{Y}];{Type};{Onthis}";
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

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,

    }
}

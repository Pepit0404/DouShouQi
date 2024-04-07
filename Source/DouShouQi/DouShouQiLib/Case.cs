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
        
        public int Y { get; private set; }

        public Piece Onthis 
        {
            get => _onThis;
            set
            {
                _onThis = value;
            }
        }   
        private Piece? _onThis;

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
        Terre,
        Eau,
        Piege,
        Taniere
    }
}

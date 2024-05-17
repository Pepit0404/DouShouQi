using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Plateau
    {
        public int height
        {
            get
            {
                return echequier.GetLength(1);
            }
        }
        public int width
        {
            get
            {
                return echequier.GetLength(0);
            }
        }

        public Case[,] echequier { get; private set; }

        public IRegles regle { get; init; }


        public Case this[int ligne, int collone]
        {
            get
            {
                if (ligne < 0 || ligne >= echequier.GetLength(0) ) throw new MyOutOfRangeException($"la valeur: {ligne} dépasse les limites du tableau" );
                if (collone < 0 || collone >= echequier.GetLength(1) ) throw new MyOutOfRangeException($"la valeur: {collone} dépasse les limites du tableau");
                return echequier[ligne,collone];
            }
        }

        private IRegles SetRegles(int regle)
        {
            if (regle == 0)
            {
                return new regleOrigin();
            }
            if (regle == 1)
            {
                return new regleVariente();
            }
            throw new NumberRulesException($"La valeur {regle} n'existe pas");
        }

        public Plateau() : this(9,7,0)
        { }

        public Plateau(int height, int width, int regle)
        {
            this.regle = SetRegles(regle);
            echequier = new Case[height, width];
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0;i< echequier.GetLength(0); i++)
            {
                for (int j = 0; j< echequier.GetLength(1); j++)
                {
                    str.Append(echequier[i, j]);
                    str.Append(" | ");
                }
                Console.Write("\n---------------------------------------------------\n");
            }
            return str.ToString();
        }
    }

    public class MyOutOfRangeException : Exception
    {
        public MyOutOfRangeException(string message="Valeur rentrée inconnue")
            : base(message)
        { }
    }

    public class NumberRulesException : Exception
    {
        public NumberRulesException(string message="Veleur rentrée inconnue") 
            : base(message)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Plateau
    {
        private int height;
        private int width;
        private Case[,] echequier;
        public IRegles regle { get; init; }

        public Case this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= echequier.GetLength(0) ) throw new MyOutOfRangeException($"la valeur: {i} dépasse les limites du tableau" ) ;
                if (j < 0 || j >= echequier.GetLength(1) ) throw new MyOutOfRangeException($"la valeur: {j} dépasse les limites du tableau");
                return echequier[i,j];
            }
        }

        private void initPlateau()
        {
            for (int i = 0; i< echequier.GetLength(0); i++)
            {
                for (int j = 0; j< echequier.GetLength(1); j++)
                {
                    echequier[i,j] = new Case(i,j,CaseType.Terre);
                }
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

        public Plateau() : this(7,9,0)
        { }

        public Plateau(int height, int width, int regle )
        {
            this.height = height;
            this.width = width;
            echequier = new Case[height, width];
            this.regle = SetRegles(regle);
            initPlateau();
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
                str.Append("\n");
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

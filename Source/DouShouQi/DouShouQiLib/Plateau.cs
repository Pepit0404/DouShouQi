using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Plateau
    {
        public Case [,] echequier = new Case[9,7];

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

        public Plateau()
        {
            initPlateau();
        }

        public override string ToString()
        {
            string str="";
            for(int i = 0;i< echequier.GetLength(0); i++)
            {
                for (int j = 0; j< echequier.GetLength(1); j++)
                {
                    str += echequier[i, j];
                    str += " | ";
                }
                str += "\n";
            }
            return str;
        }
    }
}

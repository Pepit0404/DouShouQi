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
        /// <summary>
        ///    Hauteur du plateau
        /// </summary>
        public int height
        {
            get
            {
                return echequier.GetLength(1);
            }
        }

        /// <summary>
        ///    Largeur du plateau
        /// </summary>
        public int width
        {
            get
            {
                return echequier.GetLength(0);
            }
        }

        /// <summary>
        ///    Tableau contenant toutes les cases du plateau
        /// </summary>
        public Case[,] echequier { get; private set; }

        /// <summary>
        ///     Permet a Plateau d'avoir accés aux case de l'achéquier directement
        /// </summary>
        /// <param name="ligne"></param>
        /// <param name="collone"></param>
        /// <returns>Case</returns>
        /// <exception cref="MyOutOfRangeException"></exception>
        public Case this[int ligne, int collone]
        {
            get
            {
                if (ligne < 0 || ligne >= echequier.GetLength(0) ) throw new MyOutOfRangeException($"la valeur: {ligne} dépasse les limites du tableau" );
                if (collone < 0 || collone >= echequier.GetLength(1) ) throw new MyOutOfRangeException($"la valeur: {collone} dépasse les limites du tableau");
                return echequier[ligne,collone];
            }
        }

        /// <summary>
        ///    Constructeur d'un plateau de base
        /// </summary>
        public Plateau() : this(9,7)
        { }

        /// <summary>
        ///    Constructeur d'un plateau en entrant une hauteur et une largeur
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Plateau(int height, int width)
        {
            echequier = new Case[height, width];
        }

        public IEnumerable<Case> FlatBoard2d
        {
            get
            {
                List<Case> flatBoard = new List<Case>();

                if (echequier == null)
                {
                    return flatBoard;
                }
                for(int row=0; row < height; row++)
                {
                    for(int col=0; col < width; col++)
                    {
                        flatBoard.Add(echequier[row,col]);
                    }
                }
                return flatBoard;
            }
        }

        /// <summary>
        ///    Affichage d'un plateau
        /// </summary>
        /// <returns>L'affichage</returns>
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

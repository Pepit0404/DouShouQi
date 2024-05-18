using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Case
    {
        /// <summary>
        ///    Abscisse de la case
        /// </summary>
        public int X {  get; init; }

        /// <summary>
        ///    Ordonné de la case
        /// </summary>
        public int Y { get; init; }

        /// <summary>
        ///    La pièce, s'il y en a une, qui est sur cette case
        /// </summary>
        public Piece? Onthis { get; set; }

        /// <summary>
        ///    Type de la case parmit CaseType
        /// </summary>
        public CaseType Type { get; init; }

        /// <summary>
        ///    Constructeur de Case
        /// </summary>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Case(int x, int y, CaseType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        /// <summary>
        ///    Affichage d'une case
        /// </summary>
        /// <returns>L'affichage</returns>
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

    /// <summary>
    ///    Enumération qui définit les types que peut prendre une case
    /// </summary>
    public enum CaseType
    {
        Inconnue,
        Terre,
        Eau,
        Piege,
        Taniere
    }
}

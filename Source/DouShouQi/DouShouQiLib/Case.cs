using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    [DataContract]
    public class Case
    {
        /// <summary>
        ///    Abscisse de la case
        /// </summary>
        [DataMember]
        public int X {  get; private set; }

        /// <summary>
        ///    Ordonné de la case
        /// </summary>
        [DataMember]
        public int Y { get; private set; }

        public int[] pos 
            => new int[]{ X, Y };

        /// <summary>
        ///    La pièce, s'il y en a une, qui est sur cette case
        /// </summary>
        [DataMember]
        public Piece? Onthis { get; set; }

        /// <summary>
        ///    Type de la case parmit CaseType
        /// </summary>
        public CaseType Type { get; private set; }

        [DataMember]
        private int type
        {
            get
            {
                return (int)Type;
            }
            set
            {
                Type = (CaseType)value;
            }
        }

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
    [DataContract]
    public enum CaseType
    {
        [EnumMember]
        Inconnue,
        [EnumMember]
        Terre,
        [EnumMember]
        Eau,
        [EnumMember]
        Piege,
        [EnumMember]
        Taniere
    }
}

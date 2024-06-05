using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    [DataContract]
    public class Plateau : INotifyPropertyChanged
    {
        /// <summary>
        ///    Hauteur du plateau
        /// </summary>
        [DataMember]
        public int height { get; private set; }

        /// <summary>
        ///    Largeur du plateau
        /// </summary>
        [DataMember]
        public int width { get; private set; }

        /// <summary>
        ///    Tableau contenant toutes les cases du plateau
        /// </summary>
        public Case[,] echequier { get; private set; }
        
        [DataMember]
        private IEnumerable<Case> serialEchequier { get; set; }

        [OnSerializing]
        private void OnSerializing(StreamingContext sc = new StreamingContext())
        {
            serialEchequier = FlatBoard2d;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext sc = new StreamingContext())
        {
            echequier = new Case[width, height];
            foreach (Case c in serialEchequier)
            {
                echequier[c.X, c.Y] = c;
            }
        }
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
            set
            {
                if (ligne < 0 || ligne >= echequier.GetLength(0)) throw new MyOutOfRangeException($"la valeur: {ligne} dépasse les limites du tableau");
                if (collone < 0 || collone >= echequier.GetLength(1)) throw new MyOutOfRangeException($"la valeur: {collone} dépasse les limites du tableau");
                echequier[ligne, collone] = value;
                OnPropertyChanged("Plateau");
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
            this.width = echequier.GetLength(0);
            this.height = echequier.GetLength(1);
        }

        /// <summary>
        ///    Fonction renvoyant une liste 1D du plateau
        /// </summary>
        public IEnumerable<Case> FlatBoard2d
        {
            get
            {
                List<Case> flatBoard = new List<Case>();

                if (echequier == null)
                {
                    return flatBoard;
                }
                for(int row=0; row < width; row++)
                {
                    for(int col=0; col < height ; col++)
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

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

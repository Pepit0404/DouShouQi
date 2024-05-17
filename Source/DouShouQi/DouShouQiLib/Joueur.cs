using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Joueur
    {
        public bool appartient(Piece piece)
        {
            if (piece.Proprietaire == this)
            {
                return true;
            }
            return false;
        }
        private string Identifiant { get; init; }
        public Joueur(string identifiant)
        {
            Identifiant = identifiant;
        }

        public override string ToString()
        {
            return $"{Identifiant}";
        }


    }
}

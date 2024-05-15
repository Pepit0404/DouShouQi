using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class Joueur
    {
        private string Identifiant { get; init; }
        private int nbVictoire {  get; set; }
        public Joueur(string identifiant)
        {
            Identifiant = identifiant;
            nbVictoire = 0;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class AppartientEventArgs : EventArgs
    {
        public bool Ok {  get; set; }
        public Joueur Proprietaire { get; set; }
        public AppartientEventArgs(bool ok, Joueur proprietaire)
        {
            Ok = ok;
            Proprietaire = proprietaire;
        }
    }
}

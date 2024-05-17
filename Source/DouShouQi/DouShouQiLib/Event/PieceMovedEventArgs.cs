using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class PieceMovedEventArgs : EventArgs
    {
        public bool Ok { get; set; }

        public Case Depart { get; set; }

        public Case Arrivee { get; set; }

        public PieceMovedEventArgs(bool ok, Case depart, Case arrivee)
        {
            Ok = ok;
            Depart = depart;
            Arrivee = arrivee;
        }
    }
}

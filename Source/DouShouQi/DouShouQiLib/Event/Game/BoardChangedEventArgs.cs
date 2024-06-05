using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class BoardChangedEventArgs : EventArgs
    {
        public Plateau? NewBoard { get; private set; }

        public Case? Depart { get; private set; }

        public Case? Arrivee { get; private set; }

        public BoardChangedEventArgs(Plateau? newBoard, Case? depart, Case? arrivee)
        {
            NewBoard = newBoard;
            Depart = depart;
            Arrivee = arrivee;
        }
    }
}

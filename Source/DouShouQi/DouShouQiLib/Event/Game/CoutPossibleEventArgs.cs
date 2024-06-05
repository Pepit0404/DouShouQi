using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib.Event
{
    public class CoutPossibleEventArgs: EventArgs
    {
        List<Case> possible {  get; set; }

        public CoutPossibleEventArgs(List<Case> possible)
        {
            this.possible = possible;
        }
    }
}

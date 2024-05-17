using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class TalkToPlayerEventArgs : EventArgs
    {
        public string Messsage { get; set; }
        public TalkToPlayerEventArgs(string message)
        {
            Messsage = message;
        }
    }
}

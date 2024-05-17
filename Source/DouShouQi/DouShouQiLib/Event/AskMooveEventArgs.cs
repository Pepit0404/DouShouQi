using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public class AskMooveEventArgs : EventArgs
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public Game Game { get; set; }
        public AskMooveEventArgs(int maxX, int maxY, Game game)
        {
            MaxX = maxX;
            MaxY = maxY;
            Game = game;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class Theseus : Character
    {
        public Theseus(int x, int y) : base(x, y)
        {

        }
        public Boolean IsFinished()
        {
            if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.End))
            {
                Console.WriteLine("Congrats!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

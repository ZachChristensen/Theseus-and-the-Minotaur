using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusMinotaur
{

    class Thing
    {
        public Point Coordinate;
        protected Game myGame;

        public Thing(int x, int y)
        {
            Coordinate = new Point(x, y);
        }

        public void SetGame(Game aGame)
        {
            myGame = aGame;
        }


    }
}
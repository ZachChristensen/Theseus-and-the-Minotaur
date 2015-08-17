using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
   
    class Thing
    {
        public struct Coordinate
        {
            byte x;
            byte y;
            public Coordinate(byte newX, byte newY)
            {
                x = newX;
                y = newY;
            }
        }
    }
}

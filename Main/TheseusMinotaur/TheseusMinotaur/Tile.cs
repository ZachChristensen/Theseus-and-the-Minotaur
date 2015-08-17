using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class Tile : Thing
    {
        public TheWalls MyWalls{get; set;}

        public Tile( TheWalls walls) {
            MyWalls = walls;
        }
    }
}

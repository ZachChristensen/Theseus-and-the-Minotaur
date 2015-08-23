using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class Tile : Thing
    {
        public Tile(int x, int y) : base(x, y)
        {

        }
        public TheWalls MyWalls { get; set; }

    }
}

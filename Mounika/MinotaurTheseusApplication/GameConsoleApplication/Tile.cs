using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinotaurTheseusApplication
{
    class Tile : Thing
    {
        public Tile(int x, int y) : base(x, y)
        {

        }

        public Walls FourWalls { get; set; }
    }
}

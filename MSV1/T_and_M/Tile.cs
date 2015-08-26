using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_and_M
{
    class Tile
    {
        public bool UpWall;
        public bool DownWall;
        public bool LeftWall;
        public bool RightWall;

        public Tile(bool up, bool down, bool left, bool right)
        {
            this.UpWall = up;
            this.DownWall = down;
            this.LeftWall = left;
            this.RightWall = right;
        }
    }
}
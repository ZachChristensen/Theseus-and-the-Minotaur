using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class Theseus : Character
    {
        public Theseus(int x, int y)
            : base(x, y)
        {

        }
        public void MoveLeft()
        {
            this.Coordinate.Offset(-1, 0);
        }
    }
}

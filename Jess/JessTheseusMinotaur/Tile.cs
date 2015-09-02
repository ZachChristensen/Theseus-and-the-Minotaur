using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessTheseusMinotaur
{
    class Tile : Thing
    {
        //public int column;
        //public int row;
        public bool topWall;
        public bool leftWall;

        public Tile(int aColumn, int aRow) : base (aColumn, aRow)
        {
          /*  column = aColumn;
            row = aRow;*/
        }

        public void setWalls(bool aLeftWall, bool aTopWall)
        {
            topWall = aTopWall;
            leftWall = aLeftWall;
        }


    }
}

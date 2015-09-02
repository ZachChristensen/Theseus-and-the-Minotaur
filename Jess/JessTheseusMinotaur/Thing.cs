using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessTheseusMinotaur
{
    class Thing
    {
        public int column;
        public int row;
        public Game myGame;

        public Thing(int aColumn, int aRow)
        {
            column = aColumn;
            row = aRow;
        }

        public void SetGame(Game aGame)
        {
            myGame = aGame;
        }

    }
}

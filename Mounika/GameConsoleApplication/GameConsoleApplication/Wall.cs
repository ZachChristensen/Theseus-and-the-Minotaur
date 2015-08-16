using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleApplication
{
    [Flags]
    enum Walls
    {
        None = 0,
        North = 1,
        South = 2,
        West = 4,
        East = 8,
        AllWalls = North | South | West | East
        //Add exit (?)
    }
}

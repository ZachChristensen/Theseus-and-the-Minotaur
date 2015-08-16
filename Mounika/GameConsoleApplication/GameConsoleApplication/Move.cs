using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameConsoleApplication
{
    public static class Move
    {
        public static Point Up = new Point(0, -1);
        public static Point Down = new Point(0, 1);
        public static Point Left = new Point(-1, 0);
        public static Point Right = new Point(1, 0);
    }
}

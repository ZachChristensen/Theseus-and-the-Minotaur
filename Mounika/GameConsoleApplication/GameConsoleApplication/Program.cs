using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze game = new Maze();
            Thing theseusPosition = new Thing(0, 2);
            Point theseusCurrentPosition = new Point(0, 2);
            game.minotaur = new Minotaur(1, 0);
            game.CreateMaze();
            game.MoveTheseus(game.GetTheseusNextMove());
            Console.ReadLine();
        }
    }
}

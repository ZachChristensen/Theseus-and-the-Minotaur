using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinotaurTheseusApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Thing theseusPosition = new Thing(0, 2);
            Point theseusCurrentPosition = new Point(0, 2);
            game.minotaur = new Minotaur(1, 0);
            game.theseus = new Theseus(2, 0);
            game.CreateMap1();
            game.DrawMap();
            game.MoveCharacter(game.theseus, game.GetTheseusNextMove());
            Console.ReadLine();
        }
    }
}

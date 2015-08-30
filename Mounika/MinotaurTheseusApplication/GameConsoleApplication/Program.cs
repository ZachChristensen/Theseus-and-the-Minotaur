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
            game.Play();
            Console.ReadLine();
        }
    }
}

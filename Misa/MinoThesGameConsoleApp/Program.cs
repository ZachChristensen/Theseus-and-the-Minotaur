using System;

namespace MinoThesGameConsoleApp
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

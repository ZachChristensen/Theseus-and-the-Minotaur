using System;

namespace MinoThesGameConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.CreateMap();
            game.Play();
            Program.Stop();
        }

        static void Stop()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
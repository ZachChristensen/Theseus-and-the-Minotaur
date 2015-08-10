using System;

namespace MinoThesGameConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.theseus = new Theseus(2, 2);
            game.minotaur = new Minotaur(1, 0);

            game.CreateMap();
            game.PrintGridCoordination();

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
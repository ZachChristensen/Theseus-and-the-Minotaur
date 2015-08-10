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

            game.MoveMinotaur();
            Console.WriteLine("Minotaur move 1 {0}", game.minotaur.Position);

            game.MoveMinotaur();
            Console.WriteLine("Minotaur move 2 {0}", game.minotaur.Position);

            Console.ReadLine();
        }
    }
}

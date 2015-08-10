using System;

namespace MinoThesGameConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Thing theseusPosition = new Thing(0, 2);
            game.minotaur = new Minotaur(1, 0);

            game.CreateMap();
            // game.PrintGridCoordination();

            Console.WriteLine(game.minotaur.Position);
            game.MoveMinotaur(theseusPosition.Position);
            Console.WriteLine("Minotaur move 1 {0}", game.minotaur.Position);
            game.MoveMinotaur(theseusPosition.Position);

            Console.WriteLine("Minotaur move 2 {0}", game.minotaur.Position);

            Console.ReadLine();
        }
    }
}

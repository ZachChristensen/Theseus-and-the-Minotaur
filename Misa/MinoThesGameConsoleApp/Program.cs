using System;

namespace MinoThesGameConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Initialise();  // Creates a lv.1 map, put Theseus and Minotaur in the game 
            game.PrintGridCoordination();   // Print the point coordinations for easy visualalisation of the map


            // Test Test Test
            Console.WriteLine("Minotaur default locaion{0}", game.Minotaur.Position);
            Console.WriteLine("Theseus's current locaion{0}\n", game.Theseus.Position);

            game.Play();

/*            Console.WriteLine("Theseus's next locaion {X=2, Y=2}\n");

            Console.WriteLine("Minotaur's expected location {X=2, Y=1}\n");

            game.MoveMinotaur(game.Theseus.Position);
            Console.WriteLine("Minotaur move 1 locaion{0}", game.Minotaur.Position);

            game.MoveMinotaur(game.Theseus.Position);
            Console.WriteLine("Minotaur move 2 locaion{0}", game.Minotaur.Position);*/

            Console.ReadLine();
        }
    }
}

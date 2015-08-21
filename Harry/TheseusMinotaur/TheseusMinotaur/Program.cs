using System;


namespace TheseusMinotaur
{
    class Program
    {
        static void Main(string[] args)
        {
            Game aGame = new Game();
            aGame.MapOne();
            Console.WriteLine(aGame.TestMap(aGame.MapOne()));
            Console.WriteLine(aGame.TestTheseusSurroundings());
            aGame.IsBlockedLeft();
            Console.WriteLine(aGame.TestTheseusSurroundings());

            /*aGame.MoveTheseusLeft();
            Console.WriteLine(aGame.TestTheseusSurroundings());
            aGame.MoveTheseusLeft();
            Console.WriteLine(aGame.TestTheseusSurroundings());*/
            Console.ReadKey();
        }
    }
}

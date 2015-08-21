using System;


namespace TheseusMinotaur
{
    class Program
    {
        static void Main(string[] args)
        {
            Game aGame = new Game();
            aGame.MapOne();
            Console.WriteLine(aGame.TestMap(aGame.GetMapOne()));
            
            aGame.MoveLeft();
            aGame.MoveLeft();
          
            Console.ReadKey();
        }
    }
}

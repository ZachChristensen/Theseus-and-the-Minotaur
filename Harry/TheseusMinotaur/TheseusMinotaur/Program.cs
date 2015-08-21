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
            aGame.MinotaursTurn();
            aGame.MoveUp();
            aGame.MinotaursTurn();
           // aGame.MinotaursTurn();

            /*
            aGame.MoveLeft();
            aGame.MoveUp();
            aGame.MoveDown();
            aGame.MoveRight();
            aGame.MoveDown();*/
          
            Console.ReadKey();
        }
    }
}

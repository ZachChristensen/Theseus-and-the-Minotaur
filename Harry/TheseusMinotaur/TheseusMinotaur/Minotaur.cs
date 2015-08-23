using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class Minotaur : Character
    {
        public Minotaur(int x, int y) : base(x, y)
        {

        }
        //int count;
        public void HuntHorizontal()
        {
            Theseus theseus = myGame.GetTheseus();
            Console.WriteLine("M's position: " + Coordinate);
            Console.WriteLine("T's position: " + theseus.Coordinate);
            // if minotaur is to the right of theseus
            if (Coordinate.X > theseus.Coordinate.X)
            {
                // if no wall to the left
                if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.West) == false)
                {
                    MoveLeft();
                   // count++;
                    Console.WriteLine("M's position: " + Coordinate);
                }
                else
                {
                    HuntVertical();
                }
            }
            // if minotaur is to the left of theseus
            if (Coordinate.X < theseus.Coordinate.X)
            {
                if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.East) == false)
                {
                    MoveRight();
                    //count++;
                    Console.WriteLine("M's position: " + Coordinate);
                }
                else
                {
                    HuntVertical();
                }
            }
        }
        public void HuntVertical()
        {
            Theseus theseus = myGame.GetTheseus();
            Console.WriteLine("M's position: " + Coordinate);
            Console.WriteLine("T's position: " + theseus.Coordinate);
            // if minotaur is below theseus
            if (Coordinate.Y > theseus.Coordinate.Y)
            {
                // if no wall above
                if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.North) == false)
                {
                    MoveUp();
                    //count++;
                    Console.WriteLine("M's position: " + Coordinate);
                }
                else if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.North))
                {
                    Console.WriteLine("BLOCKED");
                   // count = 2;
                }
            }
            // if minotaur is above theseus
            if (Coordinate.Y < theseus.Coordinate.Y)
            {
                // if no wall below
                if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.South) == false)
                {
                    MoveDown();
                   // count++;
                    Console.WriteLine("M's position: " + Coordinate);
                }
                else if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.South))
                {
                    Console.WriteLine("BLOCKED");
                   // count = 2;
                }
            }
        }

        public void HuntThatMofo()
        {
            Theseus theseus = myGame.GetTheseus();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("M turn " + (i + 1));
                // if minotaur's X value isn't the same as theseus'
                if (Coordinate.X != theseus.Coordinate.X)
                {
                    HuntHorizontal();
                }
                else if (Coordinate.X == theseus.Coordinate.X)
                {
                    HuntVertical();
                }
            }
        }
        
    }
}

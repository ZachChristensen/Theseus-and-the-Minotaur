using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TheseusMinotaur
{
    class Character : Thing
    {
        public Character(int x, int y) : base(x, y)
        {

        }
        /*public TheWalls GetSurroundings()
        {
            Tile [,] theMap;
            theMap = myGame.MapOne();
            
        }*/
        public Boolean MoveLeft()
        {
            if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.West) == false)
            {
                Coordinate.Offset(-1, 0);
                return true;
            }
            else 
            {
                Console.WriteLine("Blocked");
                return false;
            }
            
        }
        public Boolean MoveRight()
        {
            if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.East) == false)
            {
                Coordinate.Offset(1, 0);
                return true;
            }
            else
            {
                Console.WriteLine("Blocked");
                return false;
            }
        }
        public Boolean MoveUp()
        {
            if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.North) == false)
            {
                Coordinate.Offset(0, -1);
                return true;
            }
            else
            {
                Console.WriteLine("Blocked");
                return false;
            }
        }
        public Boolean MoveDown()
        {
            if (myGame.GetMapOne()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.South) == false)
            {
                Coordinate.Offset(0, 1);
                return true;
            }
            else
            {
                Console.WriteLine("Blocked");
                return false;
            }
        }
    }
}

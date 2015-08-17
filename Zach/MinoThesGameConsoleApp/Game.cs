using System;
using System.Drawing;

namespace MinoThesGameConsoleApp
{
    class Game
    {
        public Tile[,] Map;
        public Minotaur minotaur;
        public Theseus theseus;

        public void CreateMap()
        {

            Map = new Tile[3,3];
            //Tile(UP, DOWN, LEFT, RIGHT)
            //[x,y]
            Map[0, 0] = new Tile(true, false, true, false);
            Map[1, 0] = new Tile(true, false, false, false);
            Map[2, 0] = new Tile(true, false, false, true);

            Map[0, 1] = new Tile(false, false, true, false);
            Map[1, 1] = new Tile(true, true, false, true);
            Map[2, 1] = new Tile(false, false, false, false);

            Map[0, 2] = new Tile(false, true, true, false);
            Map[1, 2] = new Tile(false, true, false, false);
            Map[2, 2] = new Tile(false, true, false, true);
        }

        void PrintMap()
        {
            int mapWidth = Map.GetLength(0);
            int mapHeight = Map.GetLength(1);

            Console.WriteLine("X:{0} Y:{1} \n", mapWidth, mapHeight);

            for (int row = 0; row < mapWidth; row++)
            {
                for (int column = 0; column < mapHeight; column++)
                {
                    Console.Write("(" + column + "," + row + ") ");
                }
                Console.WriteLine();
                
            }
            Console.WriteLine("Minotaur at {0} Theseus at {1}", minotaur.Position, theseus.Position);
        }

        void PrintMap2()
        {
            int mapWidth = Map.GetLength(0);
            int mapHeight = Map.GetLength(1);
            Console.Clear();
            Console.WriteLine("------------------");
            for (int row = 0; row < mapWidth; row++)
            {
                for (int column = 0; column < mapHeight; column++)
                {
                    Console.Write("(");
                    if (minotaur.Position.X == column && minotaur.Position.Y == row)
                    {
                        Console.Write("M");
                    }
                    if (theseus.Position.X == column && theseus.Position.Y == row)
                    {
                        Console.Write("T");
                    }
                    Console.Write(column + "," + row + ") ");
                }
                Console.WriteLine();

            }
            Console.WriteLine("------------------");
        }

        void updatePosition(ref Minotaur theThing, string direction){
            //switch case statement for each direction
            switch (direction)
            {
                case "up":
                    theThing.Position.Y -= 1;
                    break;
                case "down":
                    theThing.Position.Y += 1;
                    break;
                case "left":
                    theThing.Position.X -= 1;
                    break;
                case "right":
                    theThing.Position.X += 1;
                    break;
            }
            
        }

        bool MinotaurTurn()
        {
            //Console.WriteLine("Minotaur starting at {0}", minotaur.Position);
            PrintMap2();
            for (int i = 0; i < 2; i++)
            {
                
                //If X position is not the same try to move left or right
                if (!(minotaur.Position.X == theseus.Position.X))
                {
                    //If theseus is to the left of minotaur
                    if (minotaur.Position.X > theseus.Position.X)
                    {
                        //Check for a wall to the left
                        if (isNoWallInFront(minotaur.Position, "left"))
                        {
                            //move the minotaur to the left
                            updatePosition(ref minotaur, "left");
                        }
                    }
                    else if (isNoWallInFront(minotaur.Position, "right"))
                    {
                        updatePosition(ref minotaur, "right");
                    }
                }
                else if (!(minotaur.Position.Y == theseus.Position.Y))
                {
                    //If theseus is below of minotaur
                    if (minotaur.Position.Y < theseus.Position.Y)
                    {
                        if (isNoWallInFront(minotaur.Position, "down"))
                        {
                            updatePosition(ref minotaur, "down");
                        }
                    }
                    else if (isNoWallInFront(minotaur.Position, "up"))
                    {
                        updatePosition(ref minotaur, "up");
                    }
                }
                //Console.WriteLine("Minotaur at {0}", minotaur.Position);
                PrintMap2();
                if (theseus.Position == minotaur.Position)
                {
                    TheseusDeath();
                    return false;
                }
            }
            return true;
        }

        bool isNoWallInFront(Point minoPos, string direction)
        {
            //Returns True if there is no wall in the direction they are moving towards on their own tile AND no wall on the direction going to the new tile
            Point inFront;
            switch (direction)
            {
                case "up":
                    inFront = minoPos;
                    inFront.Y -= 1;
                    if (!(Map[inFront.X, inFront.Y].DownWall || Map[minoPos.X, minoPos.Y].UpWall))
                    {
                        return true;
                    }
                    return false;
                case "down":
                    inFront = minoPos;
                    inFront.Y += 1;
                    if (!(Map[inFront.X, inFront.Y].UpWall || Map[minoPos.X, minoPos.Y].DownWall))
                    {
                        return true;
                    }
                    return false;
                case "left":
                    inFront = minoPos;
                    inFront.X -= 1;
                    if (!(Map[inFront.X, inFront.Y].RightWall | Map[minoPos.X, minoPos.Y].LeftWall))
                    {
                        return true;
                    }
                    return false;
                case "right":
                    inFront = minoPos;
                    inFront.X += 1;
                    if (!(Map[inFront.X, inFront.Y].LeftWall || Map[minoPos.X, minoPos.Y].RightWall))
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        bool TheseusTurn()
        {
            Console.WriteLine("*Theseus's turn* (Not working)");
            //loop until valid input
            Console.ReadKey();
                //readkey for input
            //do action(move,reset,delay)
            return false; //return true if he is standing on the goal.
        }

        void TheseusDeath()
        {
            Console.WriteLine("Theseus is dead");
        }

        public void Play()
        {
            bool alive = true;
            bool win = false;
            theseus = new Theseus(0, 2);//these should probably be in the map creation method
            minotaur = new Minotaur(1, 0);

            this.PrintMap2();

            while (alive && !win)
            {
                win = TheseusTurn();
                alive = MinotaurTurn();
            }
        }
    }
}

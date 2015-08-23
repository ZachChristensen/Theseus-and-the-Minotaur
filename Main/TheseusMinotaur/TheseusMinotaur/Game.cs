using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusMinotaur
{
    class Game
    {
        Minotaur minotaur;
        Theseus theseus;
        Tile[,] Map1;

        /***********
         * 
         INTERFACES
         * 
         ***********/

        public void CreateMap1() //UNTESTED -- doesn't work, need to create each tile separately - Harry 
        {
            Map1 = new Tile[4, 3];
            //[x,y] TheWalls.North | TheWalls.South |TheWalls.West | TheWalls.East |TheWalls.End
            Map1[0, 0] = new Tile(0, 0);
            Map1[0, 0].MyWalls.HasFlag(TheWalls.North | TheWalls.West);

            Map1[1, 0] = new Tile(1, 0);
            Map1[1, 0].MyWalls.HasFlag(TheWalls.North);

            Map1[2, 0] = new Tile(2, 0);
            Map1[2, 0].MyWalls.HasFlag(TheWalls.North | TheWalls.East);

            Map1[3, 0] = new Tile(3, 0);
            Map1[3, 0].MyWalls.HasFlag(TheWalls.None);


            Map1[0, 1] = new Tile(0, 1);
            Map1[0, 1].MyWalls.HasFlag(TheWalls.West);

            Map1[1, 1] = new Tile(1, 1);
            Map1[1, 1].MyWalls.HasFlag(TheWalls.North | TheWalls.South | TheWalls.East);

            Map1[2, 1] = new Tile(2, 1);
            Map1[2, 1].MyWalls.HasFlag(TheWalls.None);

            Map1[3, 1] = new Tile(3, 1);
            Map1[3, 1].MyWalls.HasFlag(TheWalls.North | TheWalls.South | TheWalls.East | TheWalls.End);


            Map1[0, 2] = new Tile(0, 2);
            Map1[0, 2].MyWalls.HasFlag(TheWalls.South | TheWalls.West);

            Map1[1, 2] = new Tile(1, 2);
            Map1[1, 2].MyWalls.HasFlag(TheWalls.South);

            Map1[2, 2] = new Tile(2, 2);
            Map1[2, 2].MyWalls.HasFlag(TheWalls.South | TheWalls.East);

            Map1[3, 2] = new Tile(3, 2);
            Map1[3, 2].MyWalls.HasFlag(TheWalls.None);
        }

        public void MoveCharacter(ref Minotaur character, String direction)//Character type doesn't work so I used Minotaur
        {
            //switch case statement for each direction
            switch (direction)
            {
                case "up":
                    character.Coordinate.Y -= 1;
                    break;
                case "down":
                    character.Coordinate.Y += 1;
                    break;
                case "left":
                    character.Coordinate.X -= 1;
                    break;
                case "right":
                    character.Coordinate.X += 1;
                    break;
            }
        }

        public bool TheseusTurn()//return true if he moves to the exit - return true only in this case?? - Yes, this method changes the win variable.
        {
            String input = GetInput();
            if (input == "d")
            {
                return false; //MoveCharacter(theseus, direction);
            }
            else
            {
                return false;
            }
        }

        public string/*placeholder type*/ GetInput()
        {
            return "";
        }

        public bool MinotaurTurn()//return false if it catches theseus
        {
            for (int i = 0; i < 2; i++)
            {
                //If X position is not the same try to move left or right
                if (!(minotaur.Coordinate.X == theseus.Coordinate.X))
                {
                    //If theseus is to the left of minotaur
                    if (minotaur.Coordinate.X > theseus.Coordinate.X)
                    {
                        //Check for a wall to the left
                        if (IsWall(minotaur.Coordinate, "left"))
                        {
                            //move the minotaur to the left
                            MoveCharacter(ref minotaur, "left");
                        }
                    }
                    else if (IsWall(minotaur.Coordinate, "right"))
                    {
                        MoveCharacter(ref minotaur, "right");
                    }
                }
                else if (!(minotaur.Coordinate.Y == theseus.Coordinate.Y))
                {
                    //If theseus is below the minotaur
                    if (minotaur.Coordinate.Y < theseus.Coordinate.Y)
                    {
                        if (IsWall(minotaur.Coordinate, "down"))
                        {
                            MoveCharacter(ref minotaur, "down");
                        }
                    }
                    else if (IsWall(minotaur.Coordinate, "up"))
                    {
                        MoveCharacter(ref minotaur, "up");
                    }
                }
                //Console.WriteLine("Minotaur at {0}", minotaur.Coordinate);
                //Update display for his new position here.
                if (theseus.Coordinate == minotaur.Coordinate)
                {
                    //A method for his death animation/message maybe
                    return false;
                }
            }
            return true;
        }

       public bool IsWall(Point charPos, String direction) // Returns true if not blocked - Untested
        {
            Point inFront;
            inFront = charPos;
            switch (direction)
            {
                case "up":
                    inFront.Y -= 1;
                    if (!(Map1[inFront.X, inFront.Y].MyWalls == TheWalls.South || Map1[charPos.X, charPos.Y].MyWalls == TheWalls.North))
                    {
                        return true;
                    }
                    return false;
                case "down":
                    inFront.Y += 1;
                    if (!(Map1[inFront.X, inFront.Y].MyWalls == TheWalls.North || Map1[charPos.X, charPos.Y].MyWalls == TheWalls.South))
                    {
                        return true;
                    }
                    return false;
                case "left":
                    inFront.X -= 1;
                    if (!(Map1[inFront.X, inFront.Y].MyWalls == TheWalls.East || Map1[charPos.X, charPos.Y].MyWalls == TheWalls.West))
                    {
                        return true;
                    }
                    return false;
                case "right":
                    inFront.X += 1;
                    if (!(Map1[inFront.X, inFront.Y].MyWalls == TheWalls.West || Map1[charPos.X, charPos.Y].MyWalls == TheWalls.East))
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
       }
    
        public void Play()
        {
            CreateMap1();

            bool alive = true;
            bool win = false;

            //display map

            while (alive && !win) //currently an infinite loop
            {
                win = TheseusTurn();//returns true if he moves on the same space as the goal
                alive = MinotaurTurn();//returns false if minotaur move on the same space as theseus
            }
        }
    }
}
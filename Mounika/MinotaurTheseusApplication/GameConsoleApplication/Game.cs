using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinotaurTheseusApplication
{
    class Game
    {
        public Tile[,] map;
        public Minotaur minotaur;
        public Theseus theseus;
        //public Point theseusCurrentPosition;

        public void CreateMap1()
        {
            map = new Tile[3, 3]; // Maze 1 is 3X3

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    map[x, y] = new Tile(x, y);
                }
            }
            map = BuildMaze1(map); //Hardcoded to build maze 1 for now
        }

        Tile[,] BuildMaze1(Tile[,] map)
        {            
            map[0, 0].FourWalls = Walls.North | Walls.West;
            map[1, 0].FourWalls = Walls.North | Walls.South;
            map[2, 0].FourWalls  = Walls.North | Walls.East;
            map[0, 1].FourWalls = Walls.West;
            map[1, 1].FourWalls = Walls.North | Walls.South | Walls.East;
            map[2, 1].FourWalls = Walls.West | Walls.End;
            map[0, 2].FourWalls = Walls.South | Walls.West;
            map[1, 2].FourWalls = Walls.North | Walls.South;
            map[2, 2].FourWalls = Walls.South | Walls.East;
            return map;
        }

        public void DrawMap()
        {
            Console.WriteLine("Size of the map is {0}/{1}", map.GetLength(0), map.GetLength(1));
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.WriteLine("map {0}, {1} - {2} walls", i, j, map[i, j].FourWalls);
                }
            }
        }

        public bool MoveCharacter(Character character, Point direction)
        {
            if (IsBlocked(character, direction))
            {
                return false;
            }
            else
            {
                // Update current position of character
                character.Coordinate.X += direction.X;
                character.Coordinate.Y += direction.Y;
                return true;
            }
        }

        public Point GetTheseusNextMove()
        {
            Console.WriteLine("Theseus next move - Press Up, Down, Right or Left arrows");
            ConsoleKeyInfo theseusMove = Console.ReadKey();

            if (theseusMove.Key == ConsoleKey.UpArrow)
            {
                return new Point(0, -1);
            }
            if (theseusMove.Key == ConsoleKey.DownArrow)
            {
                return new Point(0, 1);
            }
            if (theseusMove.Key == ConsoleKey.LeftArrow)
            {
                return new Point(-1, 0);
            }
            if (theseusMove.Key == ConsoleKey.RightArrow)
            {
                return new Point(1, 0);
            }
            if (theseusMove.Key == ConsoleKey.D)
            {
                return new Point(0, 0);
            }

            return new Point();
        }

        public bool TheseusTurn()//return true if he moves to the exit - return true only in this case??
        {
            Point direction = GetTheseusNextMove();

            if (!direction.IsEmpty)
            {
                bool theseusMoved = MoveCharacter(theseus, direction);
                if (theseusMoved)
                {
                    return IsExit(theseus);
                }
            }
            return false;
        }


        public bool MinotaurTurn()//return false if it catches theseus ??
        {
            return true;
        }

        public bool IsBlocked(Character character, Point direction) //Any other corner cases?
        {
            Point currentPosition = new Point(character.Coordinate.X, character.Coordinate.Y);
            Tile currentTile = map[currentPosition.X, currentPosition.Y];
            Point nextPosition = new Point(character.Coordinate.X + direction.X, character.Coordinate.Y + direction.Y);

            if (nextPosition.X < 0 || nextPosition.X > map.GetLength(0) || nextPosition.Y < 0 || nextPosition.Y > map.GetLength(1)) // Beyond boundaries
            {
                return true;
            }
            else if (currentPosition.X == nextPosition.X && currentPosition.Y == nextPosition.Y) // Stay still - Invalid
            {
                return true;
            }
            else
            {                
                Tile nextTile = map[nextPosition.X, nextPosition.Y];
                if (currentPosition.X > nextPosition.X) // Left
                {
                    return currentTile.FourWalls.HasFlag(Walls.West);
                }
                else if (currentPosition.X < currentPosition.X) // Right
                {
                    return currentTile.FourWalls.HasFlag(Walls.East);
                }
                else
                {
                    if (currentPosition.Y > currentPosition.Y) // Up
                    {
                        return currentTile.FourWalls.HasFlag(Walls.North);
                    }
                    else // Down
                    {
                        return currentTile.FourWalls.HasFlag(Walls.South);
                    }
                }
            }
        }

        public bool IsExit(Character character) // Check if thesesus is at Exit 'after' his every move
        {
            Point currentPosition = new Point(character.Coordinate.X, character.Coordinate.Y);
            Tile currentTile = map[currentPosition.X, currentPosition.Y];

            if (currentTile.FourWalls.HasFlag(Walls.End))
            {
                return true;
            }
            else
            {
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

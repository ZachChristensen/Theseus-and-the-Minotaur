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
        public Point theseusCurrentPosition;

        public void CreateMap1()
        {
            map = new Tile[4, 3]; // Maze 1 is 4X3

            for (int x = 0; x < 4; x++)
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
            map[0, 0].FourWalls.HasFlag(Walls.North | Walls.West);
            map[1, 0].FourWalls.HasFlag(Walls.North);
            map[2, 0].FourWalls.HasFlag(Walls.North | Walls.East);
            map[3, 0].FourWalls.HasFlag(Walls.None);
            map[0, 1].FourWalls.HasFlag(Walls.West);
            map[1, 1].FourWalls.HasFlag(Walls.North | Walls.South | Walls.East);
            map[2, 1].FourWalls.HasFlag(Walls.None);
            map[3, 1].FourWalls.HasFlag(Walls.North | Walls.South | Walls.East | Walls.End);
            map[0, 2].FourWalls.HasFlag(Walls.South | Walls.West);
            map[1, 2].FourWalls.HasFlag(Walls.South);
            map[2, 2].FourWalls.HasFlag(Walls.South | Walls.East);
            map[3, 2].FourWalls.HasFlag(Walls.None);
            return map;
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
                return new Point(theseus.Coordinate.X, theseus.Coordinate.Y - 1);
            }
            if (theseusMove.Key == ConsoleKey.DownArrow)
            {
                return new Point(theseus.Coordinate.X, theseus.Coordinate.Y + 1);
            }
            if (theseusMove.Key == ConsoleKey.LeftArrow)
            {
                return new Point(theseus.Coordinate.X - 1, theseus.Coordinate.Y);
            }
            if (theseusMove.Key == ConsoleKey.RightArrow)
            {
                return new Point(theseus.Coordinate.X + 1, theseus.Coordinate.Y);
            }
            if (theseusMove.Key == ConsoleKey.D)
            {
                return new Point(theseus.Coordinate.X, theseus.Coordinate.Y);
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
            Tile nextTile = map[nextPosition.X, nextPosition.Y];

            // Beyond boundaries
            if (nextPosition.X < 0 || nextPosition.X > map.GetLength(0) || nextPosition.Y < 0 || nextPosition.Y > map.GetLength(1))
            {
                return true;
            }

            // Stay still - Invalid
            if (currentPosition.X == nextPosition.X && currentPosition.Y == nextPosition.Y)
            {
                return true;
            }


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

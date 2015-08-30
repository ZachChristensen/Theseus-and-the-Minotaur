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
            Console.WriteLine("<<<< Theseus next move - Press Up, Down, Right or Left arrows");
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
                    Console.WriteLine(">>> Theseus is now at - {0} {1}", theseus.Coordinate.X, theseus.Coordinate.Y);
                    return IsExit(theseus);
                }
                else
                {
                    Console.WriteLine(">>> That is an invalid move, Please try again!");
                }
            }
            return false;
        }


        public bool MinotaurTurn()//return false if it catches theseus ??
        {
            int minotaurMove = 1;
            bool minotaurMoved = false;

            while (minotaurMove < 3)
            {
                Console.WriteLine(minotaurMove);
                Point newPosition = new Point(0, 0);

                if (minotaurMove == 1)
                {
                    if (minotaur.Coordinate.X - 1 == theseus.Coordinate.X && minotaur.Coordinate.Y == theseus.Coordinate.Y && minotaur.Coordinate.X - 1 >= 0)
                    {
                        newPosition = new Point(-1, 0);
                    }
                    else if (minotaur.Coordinate.X + 1 == theseus.Coordinate.X && minotaur.Coordinate.Y == theseus.Coordinate.Y && minotaur.Coordinate.X - 1 >= 2)
                    {
                        newPosition = new Point(1, 0);
                    }
                    else
                    {
                        if (minotaur.Coordinate.X + 1 <= 2)
                        {
                            newPosition = new Point(1, 0);
                        }

                        else if (minotaur.Coordinate.X - 1 >= 0)
                        {
                            newPosition = new Point(-1, 0);
                        }
                    }

                    minotaurMoved = MoveCharacter(minotaur, newPosition);

                    if (minotaurMoved)
                    {
                        Console.WriteLine("moved....");
                        minotaurMove++;
                    }
                }

                if (minotaurMove == 2)
                {
                    if ((minotaur.Coordinate.X - 1 == theseus.Coordinate.X && minotaur.Coordinate.Y == theseus.Coordinate.Y && minotaur.Coordinate.X - 1 >= 0))//Check x-axis first
                    {
                        newPosition = new Point(-1, 0);

                    }
                    else if (minotaur.Coordinate.X + 1 == theseus.Coordinate.X && minotaur.Coordinate.Y == theseus.Coordinate.Y && minotaur.Coordinate.X + 1 <= 2)
                    {
                        newPosition = new Point(1, 0);
                    }
                    else if ((minotaur.Coordinate.Y - 1 == theseus.Coordinate.Y && minotaur.Coordinate.X == theseus.Coordinate.X && minotaur.Coordinate.Y - 1 >= 0)) //Check y-axis
                    {
                        newPosition = new Point(0, -1);
                    }
                    else if (minotaur.Coordinate.Y + 1 == theseus.Coordinate.Y && minotaur.Coordinate.X == theseus.Coordinate.X && minotaur.Coordinate.Y + 1 <= 2)
                    {
                        newPosition = new Point(0, 1);
                    }
                    else
                    {
                        if (minotaur.Coordinate.Y + 1 <= 2)
                        {
                            newPosition = new Point(0, 1);
                        }

                        else if (minotaur.Coordinate.Y - 1 >= 0)
                        {
                            newPosition = new Point(0, -1);
                        }
                    }
                    minotaurMoved = MoveCharacter(minotaur, newPosition);

                    if (minotaurMoved)
                    {
                        Console.WriteLine("moved....");
                        minotaurMove++;
                    }
                }   
                   
            }
            Console.WriteLine(">>> Minotaur is now at - {0} {1}", minotaur.Coordinate.X, minotaur.Coordinate.Y);
            return true;
        }

        public bool IsBlocked(Character character, Point direction) //Any other corner cases?
        {
            Point currentPosition = new Point(character.Coordinate.X, character.Coordinate.Y);
            Tile currentTile = map[currentPosition.X, currentPosition.Y];
            Point nextPosition = new Point(character.Coordinate.X + direction.X, character.Coordinate.Y + direction.Y);

            if (nextPosition.X < 0 || nextPosition.X > (map.GetLength(0) - 1) || nextPosition.Y < 0 || nextPosition.Y > (map.GetLength(1) - 1)) // Beyond boundaries
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
                else if (currentPosition.X < nextPosition.X) // Right
                {
                    return currentTile.FourWalls.HasFlag(Walls.East);
                }
                else
                {
                    if (currentPosition.Y > nextPosition.Y) // Up
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
            theseus = new Theseus(1, 2);
            minotaur = new Minotaur(1, 0);
            CreateMap1();
            DrawMap();
            bool alive = true;
            bool win = false;

            while (alive && !win)
            {
                win = TheseusTurn();//returns true if he moves on the same space as the goal
                alive = MinotaurTurn();//returns false if minotaur move on the same space as theseus
            }

            Console.WriteLine("Game end");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameConsoleApplication
{
    class Maze
    {
        public Tile[,] map;
        public Minotaur minotaur;
        public Point theseusCurrentPosition;

        public void CreateMaze()
        {
            map = new Tile[3, 3]; // Maze 1 is 3X3
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    map[x, y] = new Tile();
                }
            }
            map = BuildMaze1(map); //Hardcoded to build maze 1 for now
        }

        Tile[,] BuildMaze1(Tile[,] maze)
        {
            maze[0, 0].FourWalls = Walls.North | Walls.West;
            maze[0, 1].FourWalls = Walls.West;
            maze[0, 2].FourWalls = Walls.West | Walls.South;
            maze[1, 0].FourWalls = Walls.North;
            maze[1, 1].FourWalls = Walls.North | Walls.East | Walls.South;
            maze[1, 2].FourWalls = Walls.South;
            maze[2, 0].FourWalls = Walls.North | Walls.East;
            maze[2, 1].FourWalls = Walls.None;
            maze[2, 2].FourWalls = Walls.East | Walls.South;
            return maze;
        }

        public void MoveTheseus(Point nextPosition)
        {
            bool canMove = isWall(nextPosition);
            if (canMove)
            {
                // Update current position
                theseusCurrentPosition.X += nextPosition.X;
                theseusCurrentPosition.Y += nextPosition.Y;
                Console.WriteLine("Theseus is at x={0}, y={1}", theseusCurrentPosition.X, theseusCurrentPosition.Y);
            }
            else
            {
                // Prompt user to choose another move
            }
        }

        public Point GetTheseusNextMove()
        {
            // Get x-axis
            Console.WriteLine("Please provide x axis of next move: Up = 0, Down = 0, Left = -1, Right = 1");
            String xAxis = Console.ReadLine();

            // Get y-axis
            Console.WriteLine("Please provide y axis of next move: Up = -1, Down = 1, Left = 0, Right = 0");
            String yAxis = Console.ReadLine();

            int xPosition = Convert.ToInt32(xAxis);
            int yPosition = Convert.ToInt32(yAxis);

            return new Point(xPosition, yPosition);
        }

        bool isWall(Point position)
        {
            // Figure out a more efficient way to do this check 
            if (position.X == 0 && position.Y == -1)
            {
                if (map[position.X, position.Y].FourWalls == Walls.North)
                {
                    return true;
                }
            }
            else if (position.X == 0 && position.Y == 1)
            {
                if (map[position.X, position.Y].FourWalls == Walls.South)
                {
                    return true;
                }

            }
            else if (position.X == -1 && position.Y == 0)
            {
                if (map[position.X, position.Y].FourWalls == Walls.West)
                {
                    return true;
                }

            }
            else if (position.X == 1 && position.Y == 0)
            {
                if (map[position.X, position.Y].FourWalls == Walls.East)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

using System;
using System.Drawing;

namespace MinoThesGameConsoleApp
{
    class Game
    {
        public Tile[,] Map;
        public Minotaur minotaur;

        public void CreateMap()
        {
            Map = new Tile[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Map[i, j] = new Tile();
                }
            }

            Map[0, 0].FourWalls = Walls.Up | Walls.Left;
            Map[0, 1].FourWalls = Walls.Left;
            Map[0, 2].FourWalls = Walls.Left | Walls.Down;

            Map[1, 0].FourWalls = Walls.Up;
            Map[1, 1].FourWalls = Walls.Up | Walls.Right | Walls.Down;
            Map[1, 2].FourWalls = Walls.Down;

            Map[2, 0].FourWalls = Walls.Up | Walls.Right;
            Map[2, 1].FourWalls = Walls.None;
            Map[2, 2].FourWalls = Walls.Right | Walls.Down;
        }

        public void PrintGridCoordination()
        {
            int mapWidth = Map.GetLength(0);
            int mapHeight = Map.GetLength(1);

            Console.WriteLine("X:{0} Y:{1} \n", mapWidth, mapHeight);

            for (int row = 0; row < mapWidth; row++)
            {
                for (int column = 0; column < mapHeight; column++)
                {
                    Console.Write("(" + row);
                    Console.Write("," + column + ") ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        
        public void MoveMinotaur(Point theseusPos)
        {
            bool hasMovedX = MoveInDirection(true, theseusPos.X, minotaur.Position.X); // use x coords
           
            if (!hasMovedX)
            {
                MoveInDirection(false, theseusPos.Y, minotaur.Position.Y); // use y coords
            }
        }

        public bool MoveInDirection(bool isX, int theseusPos, int minotaurPos)
        {
            Point lessThanDirection = isX ? Direction.Left : Direction.Up;  // +
            Point greaterThanDirection = isX ? Direction.Right : Direction.Down;  // -

            if (theseusPos == minotaurPos)
            {
                return false;
            }

            if (theseusPos < minotaurPos)
            {
                return TryToMoveMinotaur(lessThanDirection);
            }

            return TryToMoveMinotaur(greaterThanDirection);
        }

        public bool TryToMoveMinotaur(Point direction)
        {
            if (IsDirectionWall(direction))
            {
                // increment turn
                return false;
            }
            
            // actually move
            minotaur.Position.X += direction.X;
            minotaur.Position.Y += direction.Y;

            return true;
        }

        public bool IsDirectionWall(Point direction)
        {
            Point nextTile = new Point(minotaur.Position.X + direction.X, 
            minotaur.Position.Y + direction.Y);

            // Validate if the target Tile actually exists. (Not outside the map)
            if (nextTile.X >= Map.GetLength(0) || nextTile.Y >= Map.GetLength(1))
            {
                return true;
            }

            Tile targetTile = Map[nextTile.X, nextTile.Y];

            if (direction.X < 0) // left
            {
                if (targetTile.FourWalls.HasFlag(Walls.Right))
                {
                    return true;
                }
            }
            else if (direction.X > 0) // right
            {
                if (targetTile.FourWalls.HasFlag(Walls.Left))
                {
                    return true;
                }
            }

            if (direction.Y < 0) // up
            {
                if (targetTile.FourWalls.HasFlag(Walls.Down))
                {
                    return true;
                }
            }
            else if (direction.Y > 0)
            {
                if (targetTile.FourWalls.HasFlag(Walls.Up))
                {
                    return true;
                }
            }

            return false;
        }

    }
}

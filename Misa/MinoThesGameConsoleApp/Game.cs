using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MinoThesGameConsoleApp
{
    class Game
    {
        protected Tile[,] Map;
        public Tile[,] AsciiMap;
        public Minotaur Minotaur;
        public Theseus Theseus;
        public ConsoleKeyInfo KeyInfo;
        public bool TheseusAlive = true;
        public bool TheseusEscaped = false;

        public void Initialise()
        {
            CreateMap(); 
            Theseus = new Theseus(1, 2);
            Minotaur = new Minotaur(1, 0);
        }

        public void CreateMap()
        {
            int width = 4;
            int height = 3;
            Map = new Tile[width, height];


            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Map[x, y] = new Tile(x, y);
                }
            }
            AsciiMap = Map;

            Map[0, 0].FourWalls = Walls.Up | Walls.Left;
            Map[0, 1].FourWalls = Walls.Left;
            Map[0, 2].FourWalls = Walls.Down | Walls.Left;

            Map[1, 0].FourWalls = Walls.Up;
            Map[1, 1].FourWalls = Walls.Up | Walls.Right | Walls.Down;
            Map[1, 2].FourWalls = Walls.Down;

            Map[2, 0].FourWalls = Walls.Up | Walls.Right;
            Map[2, 1].FourWalls = Walls.None;
            Map[2, 2].FourWalls = Walls.Down | Walls.Right;

            Map[3, 0].FourWalls = Walls.None;
            Map[3, 1].FourWalls = Walls.Up | Walls.Down | Walls.Goal;
            Map[3, 2].FourWalls = Walls.None;
        }

        public void PrintMap()
        {
            int mapWidth = Map.GetLength(0);
            int mapHeight = Map.GetLength(1);
            
            string ascii = "";
            string asciiBottomLine = "";
            
            for (int row = 0; row < mapHeight; row++)
            {
                if ((row != mapHeight-1))
                {
                    for (int column = 0; column < mapWidth; column++)
                    {
                        if ((row == 0 && column == 0) || (column < mapWidth))
                        {
                            ascii += ".";
                        }
                        if (Map[column, row].FourWalls.HasFlag(Walls.Up))
                        {
                            ascii += "___";
                        }
                        if (!(Map[column, row].FourWalls.HasFlag(Walls.Up) || Map[column, row].FourWalls.HasFlag(Walls.Down)) &&
                            (Map[column, row].FourWalls.HasFlag(Walls.Left) || Map[column, row].FourWalls.HasFlag(Walls.Right)))
                        {
                            ascii += "   ";
                        }
                        if (!(Map[column, row].FourWalls.HasFlag(Walls.Up) || Map[column, row].FourWalls.HasFlag(Walls.Down) ||
                            Map[column, row].FourWalls.HasFlag(Walls.Left) || Map[column, row].FourWalls.HasFlag(Walls.Right)))
                        {
                            ascii += "   ";
                        }
                    }
                }
                
                ascii += "\n";

                for (int column = 0; column < mapWidth; column++)
                {
                    if ( ((Map[column, row].FourWalls.HasFlag(Walls.Up) || Map[column, row].FourWalls.HasFlag(Walls.Down)) &&
                        !(Map[column, row].FourWalls.HasFlag(Walls.Left) || Map[column, row].FourWalls.HasFlag(Walls.Right))) )
                    {
                        ascii += "     ";
                    }
                    if (Map[column, row].FourWalls.HasFlag(Walls.Left))
                    {
                        ascii += "|   ";
                    }
                    if (Map[column, row].FourWalls.HasFlag(Walls.Right))
                    {
                        ascii += "   |";
                    }
                    if (!(Map[column, row].FourWalls.HasFlag(Walls.Up) || Map[column, row].FourWalls.HasFlag(Walls.Down) ||
                        Map[column, row].FourWalls.HasFlag(Walls.Left) || Map[column, row].FourWalls.HasFlag(Walls.Right)))
                    {
                        ascii += "     ";
                    }
                    if (column == Minotaur.Position.X && row == Minotaur.Position.Y)
                    {
                        StringBuilder newAscii = new StringBuilder(ascii);
                        newAscii[ascii.Length - 3] = 'M';
                        ascii = newAscii.ToString();
                    }
                    if (column == Theseus.Position.X && row == Theseus.Position.Y)
                    {
                        StringBuilder newAscii = new StringBuilder(ascii);
                        newAscii[ascii.Length - 3] = 'T';
                        ascii = newAscii.ToString();
                    }
                }
                ascii += "\n";

                if (row != 0 )
                {
                    for (int column = 0; column < mapWidth; column++)
                    {
                        if ((row == mapHeight - 1 && column == 0) || (column < mapWidth))
                        {
                            ascii += ".";
                        }
                        if (Map[column, row].FourWalls.HasFlag(Walls.Down))
                        {
                            ascii += "___";
                        }
                        if (!(Map[column, row].FourWalls.HasFlag(Walls.Up) || Map[column, row].FourWalls.HasFlag(Walls.Down)) &&
                            (Map[column, row].FourWalls.HasFlag(Walls.Left) || Map[column, row].FourWalls.HasFlag(Walls.Right)))
                        {
                            ascii += "   ";
                        }
                        if (!(Map[column, row].FourWalls.HasFlag(Walls.Up) || Map[column, row].FourWalls.HasFlag(Walls.Down) ||
                            Map[column, row].FourWalls.HasFlag(Walls.Left) || Map[column, row].FourWalls.HasFlag(Walls.Right)))
                        {
                            ascii += "   ";
                        }
                    }
                }
            }
            Console.WriteLine(ascii);
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
                    Console.Write("(" + column);
                    Console.Write("," + row + ") ");
                }
                Console.WriteLine();
            }
        }

        public void Play()
        {
            Initialise();
            PrintMap();
            while (TheseusAlive || !TheseusEscaped)
            {
                Console.WriteLine("\nEnter Arrow keys or WASD keys to move Theseus.\n");
                while (!MoveTheseus())
                {
                    Console.WriteLine("\nTheseus can't move that way");
                }
                Console.Clear();
                MoveMinotaur(Theseus.Position); // 1st move
                MoveMinotaur(Theseus.Position); // 2nd move

                if (IsMinotaurNextToTheseus())
                {
                    TheseusAlive = false;
                    PrintMap();
                    Console.WriteLine("\nMinotaur killed Theseus...");
                    break;
                }
                if (Map[Theseus.Position.X, Theseus.Position.Y].FourWalls.HasFlag(Walls.Goal))
                {
                    TheseusEscaped = true;
                    PrintMap();
                    Console.WriteLine("\nTheseus escaped safely!!!");
                    break;
                }
                PrintMap();
            }
        }

        public bool IsMinotaurNextToTheseus()
        {
            if (Minotaur.Position == Theseus.Position)
            {
                return true;
            }
            return false;
        }

        public bool MoveTheseus()
        {
            Point direction = ReadKeyboardControll();
            if (!direction.IsEmpty)
            {
                return TryToMoveTheCharacter(Theseus, direction);
            }
            return false;
        }

        public Point ReadKeyboardControll()
        {
            KeyInfo = Console.ReadKey();

            if (KeyInfo.Key == ConsoleKey.UpArrow || KeyInfo.Key == ConsoleKey.W)
            {
                return Direction.Up;
            }
            if (KeyInfo.Key == ConsoleKey.DownArrow || KeyInfo.Key == ConsoleKey.S)
            {
                return Direction.Down;
            }
            if (KeyInfo.Key == ConsoleKey.LeftArrow || KeyInfo.Key == ConsoleKey.A)
            {
                return Direction.Left;
            }
            if (KeyInfo.Key == ConsoleKey.RightArrow || KeyInfo.Key == ConsoleKey.D)
            {
                return Direction.Right;
            }
            return new Point(); // return nothing
        }

        public void MoveMinotaur(Point theseusPos)
        {
            bool hasMovedX = MoveMinotaurInDirection(true, theseusPos.X, Minotaur.Position.X); // X coords
           
            if (!hasMovedX)
            {
                MoveMinotaurInDirection(false, theseusPos.Y, Minotaur.Position.Y); // Y coords
            }
        }

        // Move Minotaur by referencing Theseus's position
        public bool MoveMinotaurInDirection(bool isX, int theseusPos, int minotaurPos)
        {
            Point lessThanDirection = isX ? Direction.Left : Direction.Up;  // +1 coords
            Point greaterThanDirection = isX ? Direction.Right : Direction.Down;  // -1 coords

            if (theseusPos == minotaurPos)
            {
                return false;
            }

            if (theseusPos < minotaurPos)
            {
                return TryToMoveTheCharacter(Minotaur, lessThanDirection);
            }
            return TryToMoveTheCharacter(Minotaur, greaterThanDirection);
        }

        // Checks if the character can move. If it can, set the new position to the character.
        public bool TryToMoveTheCharacter(Character character, Point direction)
        {
            if (IsDirectionWall(character, direction))
            {
                return false;
            }

            // New new position(moves)
            character.Position.X += direction.X;
            character.Position.Y += direction.Y;

            return true;
        }

        // Checks if the given character's moving direction is wall or not
        public bool IsDirectionWall(Character character, Point direction)
        {
            Point targetPoint = new Point(character.Position.X + direction.X, character.Position.Y + direction.Y);
            Point currentPoint = new Point(character.Position.X, character.Position.Y);

            // Validate if the target Tile actually exists. (Not outside the map)
            if (targetPoint.X >= Map.GetLength(0) || targetPoint.Y >= Map.GetLength(1))
            {
                return true;
            }

            Tile targetTile = Map[targetPoint.X, targetPoint.Y];
            Tile currentTile = Map[currentPoint.X, currentPoint.Y];

            if (direction.Y < 0) // Up
            {
                if (targetTile.FourWalls.HasFlag(Walls.Down) || currentTile.FourWalls.HasFlag(Walls.Up))
                {
                    return true;
                }
            }
            else if (direction.Y > 0)   // Down
            {
                if (targetTile.FourWalls.HasFlag(Walls.Up) || currentTile.FourWalls.HasFlag(Walls.Down))
                {
                    return true;
                }
            }
            if (direction.X < 0) // Left
            {
                if (targetTile.FourWalls.HasFlag(Walls.Right) || currentTile.FourWalls.HasFlag(Walls.Left))
                {
                    return true;
                }
            }
            else if (direction.X > 0) // Right
            {
                if (targetTile.FourWalls.HasFlag(Walls.Left) || currentTile.FourWalls.HasFlag(Walls.Right))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

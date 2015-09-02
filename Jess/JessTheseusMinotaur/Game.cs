using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessTheseusMinotaur
{
    class Game
    {
        Tile[,] mapOne;
        Theseus theseus;
        Minotaur minotaur;
        Exit exit;

        /*Map Constructor*/
        public Tile[,] CreateMap(int newColumn, int newRow)
        {
            Tile[,] Map;
            int column = newColumn, row = newRow;
            Map = new Tile[column, row];

            for (int x = 0; x < column; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    Map[x, y] = new Tile(x, y);
                }
            }
            return Map;
        }

        public Theseus SetTheseus(int newColumn, int newRow)
        {
            theseus = new Theseus(newColumn, newRow);
            theseus.SetGame(this);
            return theseus;
        }

        public Minotaur SetMinotaur(int newColumn, int newRow)
        {
            minotaur = new Minotaur(newColumn, newRow);
            minotaur.SetGame(this);
            return minotaur;
        }

        public Exit SetExit(int newColumn, int newRow)
        {
            exit = new Exit(newColumn, newRow);
            exit.SetGame(this);
            return exit;
        }

        public void MapOne()
        {
            // create the map
            //Tile[,] 
            mapOne = CreateMap(4, 4);
            mapOne[0, 0].setWalls(true,true);
            mapOne[0, 1].setWalls(true, false);
            mapOne[0, 2].setWalls(true, false);
            mapOne[0, 3].setWalls(false, true);

            mapOne[1, 0].setWalls(false, true);
            mapOne[1, 1].setWalls(false, true);
            mapOne[1, 2].setWalls(false, true);
            mapOne[1, 3].setWalls(false, true);

            mapOne[2, 0].setWalls(false, true);
            mapOne[2, 1].setWalls(true, false);
            mapOne[2, 2].setWalls(false, false);
            mapOne[2, 3].setWalls(false, true);

            mapOne[3, 0].setWalls(true, false);
            mapOne[3, 1].setWalls(false, true);
            mapOne[3, 2].setWalls(true, true);
            mapOne[3, 3].setWalls(false, false);

            //character's initial positions
            theseus = SetTheseus(1,2);
            minotaur = SetMinotaur(1,0);
            exit = SetExit(3,1);
        }



        public Tile[,] GetMapOne()
        {
            return mapOne;
        }

        public Theseus GetTheseus()
        {
            return theseus;
        }

        public Exit GetExit()
        {
            return exit;
        }

        public String TestMap(Tile[,] aMap)
        {
            string output = "";
            foreach (Tile tile in aMap)
            {
                output += "(" + tile.column + "," + tile.row + ") ";
                if (tile.leftWall == true)
                {
                    output += " leftWall ";
                }
                else
                {
                    output += " noLeftWall ";
                }
                if (tile.topWall == true)
                {
                    output += " topWall ";
                }
                else
                {
                    output += " noTopWall ";
                }                
                output += Environment.NewLine;
            }
            //output += "minotaur " + minotaur.Coordinate + "\n" + "theseus " + theseus.Coordinate;
            return output;
        }

        /*Movement*/
        public void MoveLeft()
        {
            Console.WriteLine("move left");
            theseus.MoveLeft();
            Console.WriteLine("T is NOW at ("+ theseus.column + "," + theseus.row + ")");
            Console.WriteLine("Exit is NOW at (" + exit.column + "," + exit.row + ")");
        }

        public void MoveRight()
        {
            Console.WriteLine("move right");
            theseus.MoveRight();
            Console.WriteLine("T is NOW at (" + theseus.column + "," + theseus.row + ")");
            Console.WriteLine("Exit is NOW at (" + exit.column + "," + exit.row + ")");
        }

        public void MoveUp()
        {
            Console.WriteLine("move up");
            theseus.MoveUp();
            Console.WriteLine("T is NOW at (" + theseus.column + "," + theseus.row + ")");
            Console.WriteLine("Exit is NOW at (" + exit.column + "," + exit.row + ")");
        }

        public void MoveDown()
        {
            Console.WriteLine("move down");
            theseus.MoveDown();
            Console.WriteLine("T is NOW at " + theseus.column + "," + theseus.row + ")");
            Console.WriteLine("Exit is NOW at (" + exit.column + "," + exit.row + ")");
        }

        /*Turn*/
        public void MinotaursTurn()
        { 
            if ((minotaur.column == theseus.column) && (minotaur.row == theseus.row))
            {
                Console.WriteLine("Game Over!");
            }
            else
            {
                minotaur.HuntTheseus();
            }
        }

        public void TheseusTurn()
        {
            Console.WriteLine("Your turn. W = Up, A = left, S = Down, D = Right");
            if (Console.ReadKey(true).Key == ConsoleKey.A)
            {
                MoveLeft();
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.D)
            {
                MoveRight();
            }

            else if (Console.ReadKey(true).Key == ConsoleKey.W)
            {
                MoveUp();
            }

            else if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                MoveDown();
            }
            else
            {
                Console.WriteLine("Invalid letter");
            }
        }

        /*Starting the game*/
        public void Go()
        {
            /*if ((exit.column != theseus.column) && (exit.row != theseus.row))
            */
            TheseusTurn();
            if (theseus.IsAtExit() == false)
            {
                MinotaursTurn();
            }
            else
            {
                Console.WriteLine("Congrats!");
            }
        }
    }
}

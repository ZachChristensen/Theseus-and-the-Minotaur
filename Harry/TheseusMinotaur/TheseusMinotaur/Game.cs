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
        Tile[,] mapOne;

        /**** Map Constructor */
        public Tile[,] CreateMap(int newWidth, int newHeight) 
        {
            Tile[,] Map;
            int width = newWidth, height = newHeight;
            Map = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Map[x, y] = new Tile(x, y);
                }
            }
            return Map;
        }
        public Theseus SetTheseus(int newX, int newY)
        {
            theseus = new Theseus(newX, newY);
            theseus.SetGame(this);
            return theseus;
        }
        public Minotaur SetMinotaur(int newX, int newY)
        {
            minotaur = new Minotaur(newX, newY);
            minotaur.SetGame(this);
            return minotaur;
        }

        public void MapOne()
        {
            // create the map
            //Tile[,] 
            mapOne = CreateMap(4, 3);
            mapOne[0, 0].MyWalls = TheWalls.North | TheWalls.West;
            mapOne[1, 0].MyWalls = TheWalls.North | TheWalls.South;
            mapOne[2, 0].MyWalls = TheWalls.North | TheWalls.East;

            mapOne[0, 1].MyWalls = TheWalls.West;
            mapOne[1, 1].MyWalls = TheWalls.North | TheWalls.East | TheWalls.South;
            mapOne[2, 1].MyWalls = TheWalls.West;
            mapOne[3, 1].MyWalls = TheWalls.North | TheWalls.South | TheWalls.End;

            mapOne[0, 2].MyWalls = TheWalls.West | TheWalls.South;
            mapOne[1, 2].MyWalls = TheWalls.South | TheWalls.North;
            mapOne[2, 2].MyWalls = TheWalls.South | TheWalls.East;

            // set positions of characters
            minotaur = SetMinotaur(1, 0);
            theseus = SetTheseus(1, 2);
        }

        /**** Get functions for Thing class */
        public Tile[,] GetMapOne()
        {
            return mapOne;
        }
        public Theseus GetTheseus()
        {
            return theseus;
        }

        /**** Test functions */
        public String TestMap(Tile[,] aMap)
        {
            string output = "";
            foreach (Tile tile in aMap)
            {
                output += tile.Coordinate + " " + tile.MyWalls + "\n";
            }
            output += "minotaur " + minotaur.Coordinate + "\n" + "theseus " + theseus.Coordinate;
            return output;
        }

  
        /**** Game functions */
            /* Movement*/
        public void MoveLeft()
        {
            Console.WriteLine("left");
            theseus.MoveLeft();
            Console.WriteLine(theseus.Coordinate);            
        }
        public void MoveRight()
        {
            Console.WriteLine("right");
            theseus.MoveRight();
            Console.WriteLine(theseus.Coordinate);
        }
        public void MoveUp()
        {
            Console.WriteLine("up");
            theseus.MoveUp();
            Console.WriteLine(theseus.Coordinate);
        }
        public void MoveDown()
        {
            Console.WriteLine("down");
            theseus.MoveDown();
            Console.WriteLine(theseus.Coordinate);
        }

            /*Ordering*/
        public void MinotaursTurn()
        {
            if (minotaur.Coordinate == theseus.Coordinate)
            {
                Console.WriteLine("tastes like chicken");
            }
            else
            {
                minotaur.HuntThatMofo();
            }
        }
        public void PlayersTurn()
        {
            Console.WriteLine("Your turn");
            if (Console.ReadKey().Key == ConsoleKey.UpArrow)
            {
                MoveUp();
            }
            if (Console.ReadKey().Key == ConsoleKey.DownArrow)
            {
                MoveDown();
            }
            if (Console.ReadKey().Key == ConsoleKey.RightArrow)
            {
                MoveRight();
            }
            if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
            {
                MoveLeft();
            }
        }
            /* The go button */
        public void Run()
        {
            if (theseus.IsFinished() == false)
            {
                while (theseus.Coordinate != minotaur.Coordinate)
                {
                    PlayersTurn();
                    MinotaursTurn();
                }
                Console.WriteLine("Game Over!");
            }
            else if(theseus.IsFinished())
            {
                Console.WriteLine("Congrats!");
            }
        }

    }
}

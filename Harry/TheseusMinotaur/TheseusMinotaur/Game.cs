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
        //Tile[,] Map;
        Tile[,] mapOne;

        /****
         * Map Constructor
         * 
         ****/
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
            //return mapOne;
        }

        public Tile[,] GetMapOne()
        {
            return mapOne;
        }

        /******* 
                TESTS 
                        **********/

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

        public String TestTheseusSurroundings()
        {
            //Tile[,] aMap = MapOne();
            string output = "";
            int x, y;
            x = theseus.Coordinate.X;
            y = theseus.Coordinate.Y;
            output += "Theseus is on tile " + theseus.Coordinate + "and he is blocked " + mapOne[x, y].MyWalls;
            return output;
        }

        public Tile GetTheseusSurroundings()
        {
            return mapOne[theseus.Coordinate.X, theseus.Coordinate.Y];
        }
        /*public void MoveLeft()
        {
            Tile[,] theMap = MapOne();
            Tile currentTile = theMap[theseus.Coordinate.X, theseus.Coordinate.Y];
            if (currentTile.MyWalls.HasFlag(TheWalls.West))
            {
                Console.WriteLine("blocked");
            }
            else if (currentTile.MyWalls.HasFlag(TheWalls.West) == false)
            {
                theseus.MoveLeft();
                Console.WriteLine(theseus.Coordinate);
            }
        }*/
        public void MoveLeft()
        {
            theseus.MoveLeft();
            Console.WriteLine(theseus.Coordinate);
           /*/ if (mapOne[theseus.Coordinate.X, theseus.Coordinate.Y].MyWalls.HasFlag(TheWalls.West) == false)
            {
                theseus.MoveLeft();
            }
            else
            {
                Console.WriteLine("blocked");
            }
            
            Console.WriteLine(theseus.Coordinate);*/
            
        }

    }
}

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
        Tile[,] Map;

        public Tile[,] CreateMap(int newWidth, int newHeight) // Map constructor
        {
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
            return theseus;
        }
        public Minotaur SetMinotaur(int newX, int newY)
        {
            minotaur = new Minotaur(newX, newY);
            return minotaur;
        }

        public Tile[,] MapOne()
        {
            // create the map
            Tile[,] mapOne = CreateMap(4, 3);
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
            Tile[,] aMap = MapOne();
            string output = "";
            int x, y;
            x = theseus.Coordinate.X;
            y = theseus.Coordinate.Y;
            output += "Theseus is on tile " + theseus.Coordinate + "and he is blocked " + aMap[x, y].MyWalls;
            return output;
        }

        public Tile GetTheseusSurroundings()
        {
            Tile[,] theMap = MapOne();
            return theMap[theseus.Coordinate.X, theseus.Coordinate.Y];
        }
        public void IsBlockedLeft()
        {
            //Tile[,] theMap = MapOne();
            Tile currentTile = GetTheseusSurroundings();
            if (currentTile.MyWalls.HasFlag(TheWalls.West))
            {
                Console.WriteLine("blocked");
            }
            else
            {
                theseus.Coordinate.X = theseus.Coordinate.X - 1;
            }

        }

        /*public bool MoveTheseusLeft()
        {
            Tile currentTile = GetTheseusSurroundings();
            if (currentTile.MyWalls.HasFlag(TheWalls.West) == false)
            {
                theseus.Coordinate.X -= 1;
                return true;
            }
            else //if (currentTile.MyWalls.HasFlag(TheWalls.West) == true)
            {
                Console.WriteLine("BLOCKED");
                return false;
            }
        }*/


    }
}

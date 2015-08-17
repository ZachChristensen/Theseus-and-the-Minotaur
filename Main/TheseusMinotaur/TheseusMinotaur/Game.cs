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
        Tile[,] Map1;

        public void CreateMap1() //UNTESTED
        {
            Map1 = new Tile[4, 3];
            //[x,y] TheWalls.North | TheWalls.South |TheWalls.West | TheWalls.East |TheWalls.End
            Map1[0, 0] = new Tile(TheWalls.North | TheWalls.West);
            Map1[1, 0] = new Tile(TheWalls.North);
            Map1[2, 0] = new Tile(TheWalls.North | TheWalls.East);
            Map1[3, 0] = new Tile(TheWalls.None);

            Map1[0, 1] = new Tile(TheWalls.West);
            Map1[1, 1] = new Tile(TheWalls.North | TheWalls.South | TheWalls.East);
            Map1[2, 1] = new Tile(TheWalls.None);
            Map1[3, 1] = new Tile(TheWalls.North | TheWalls.South | TheWalls.East | TheWalls.End);

            Map1[0, 2] = new Tile(TheWalls.South | TheWalls.West);
            Map1[1, 2] = new Tile(TheWalls.South);
            Map1[2, 2] = new Tile(TheWalls.South | TheWalls.East);
            Map1[3, 2] = new Tile(TheWalls.None);
        }

        public bool TheseusTurn()//return true if he moves to the exit
        {

            return false;
        }

        public bool MinotaurTurn()//return false if it catches theseus
        {

            return true;
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

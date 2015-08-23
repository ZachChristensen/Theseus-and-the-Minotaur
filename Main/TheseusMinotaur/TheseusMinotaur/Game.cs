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

        public void CreateMap1() //UNTESTED -- doesn't work, need to create each tile separately - Harry 
        {
            Map1 = new Tile[4, 3];
            //[x,y] TheWalls.North | TheWalls.South |TheWalls.West | TheWalls.East |TheWalls.End
            Map1[0, 0] = new Tile(0, 0);
            Map1[0, 0].MyWalls.HasFlag(TheWalls.North | TheWalls.West);

            Map1[1, 0] = new Tile(1, 0);
            Map1[1, 0].MyWalls.HasFlag(TheWalls.North);

            Map1[2, 0] = new Tile(2, 0);
            Map1[2, 0].MyWalls.HasFlag(TheWalls.North | TheWalls.East);

            Map1[3, 0] = new Tile(3, 0);
            Map1[3, 0].MyWalls.HasFlag(TheWalls.None);

            Map1[0, 1] = new Tile(0, 1);
            Map1[0, 1].MyWalls.HasFlag(TheWalls.West);

            Map1[1, 1] = new Tile(1, 1);
            Map1[1, 1].MyWalls.HasFlag(TheWalls.North | TheWalls.South | TheWalls.East);

            Map1[2, 1] = new Tile(2, 1);
            Map1[2, 1].MyWalls.HasFlag(TheWalls.None);

            Map1[3, 1] = new Tile(3, 1);
            Map1[3, 1].MyWalls.HasFlag(TheWalls.North | TheWalls.South | TheWalls.East | TheWalls.End);

            Map1[0, 2] = new Tile(0, 2);
            Map1[0, 2].MyWalls.HasFlag(TheWalls.South | TheWalls.West);

            Map1[1, 2] = new Tile(1, 2);
            Map1[1, 2].MyWalls.HasFlag(TheWalls.South);

            Map1[2, 2] = new Tile(2, 2);
            Map1[2, 2].MyWalls.HasFlag(TheWalls.South | TheWalls.East);

            Map1[3, 2] = new Tile(3, 2);
            Map1[3, 2].MyWalls.HasFlag(TheWalls.None);
        }

        public bool MoveCharacter(Character character, Point direction)
        {
            if (IsWall(character, direction))
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

        public bool TheseusTurn(Point direction)//return true if he moves to the exit - return true only in this case??
        {
            if (!direction.IsEmpty)
            {
                return MoveCharacter(theseus, direction);
            }
            else
            {
                return false;
            }
        }


        public bool MinotaurTurn()//return false if it catches theseus
        {
            return true;
        }
        public bool IsWall(Character character, Point direction) // TODO:
        {
            return false;
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

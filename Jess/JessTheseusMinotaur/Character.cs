using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessTheseusMinotaur
{
    class Character : Thing
    {
        public Character(int aColumn, int aRow) : base (aColumn, aRow)
        {
            
        }

        public Boolean MoveLeft()
        {
            if (myGame.GetMapOne()[column, row].leftWall == false)
            {
                this.column -= 1;
               // Console.WriteLine("Moved Left");
                return true;
            }
            else
            {
                Console.WriteLine("Blocked");
                return false;
            }
        }
        
        public Boolean MoveRight()
        {
            if (myGame.GetMapOne()[column+1, row].leftWall == false)
            {
                this.column += 1;
                return true;
            }
            else
            {
                Console.WriteLine("Blocked");
                return false;
            }
        }

        public Boolean MoveUp()
        {
            if (myGame.GetMapOne()[column, row].topWall == false)
            {
                this.row -= 1;
                return true;
            }
            else
            {
                Console.WriteLine("Blocked");
                return false;
            }
        }

        public Boolean MoveDown()
        {
            if (myGame.GetMapOne()[column, row+1].topWall == false)
            {
                this.row += 1;
                return true;
            }
            else
            {
                Console.WriteLine("Blocked");
                return false;
            }
        }

    }
}

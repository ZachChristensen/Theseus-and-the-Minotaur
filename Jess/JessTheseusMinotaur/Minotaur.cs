using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessTheseusMinotaur
{
    class Minotaur : Character
    {
        

        public Minotaur(int aColumn, int aRow) : base (aColumn, aRow)
        {

        }

        public void HuntHorizontal()
        {
            Theseus theseus = myGame.GetTheseus();
            Console.WriteLine("M initital position: (" + column + "," + row + ")");
            Console.WriteLine("T is at: (" + theseus.column + "," + theseus.row + ")");

            if (theseus.column < column)
            {
                MoveLeft();
                Console.WriteLine("M position: (" + column + "," + row + ")");
            }
            else if (theseus.column > column)
            {
                MoveRight();
                Console.WriteLine("M position: (" + column + "," + row + ")");
            }
        }

        public void HuntVertical()
        {
            Theseus theseus = myGame.GetTheseus();
            Console.WriteLine("M initital position: (" + column + "," + row + ")");
            Console.WriteLine("T is at: (" + theseus.column + "," + theseus.row + ")");

            if (theseus.row > row)
            {
                MoveDown();
                Console.WriteLine("M position: (" + column + "," + row + ")");
            }
            else if (theseus.row < row)
            {
                MoveUp();
                Console.WriteLine("M position: (" + column + "," + row + ")");
            }
        }

        public void HuntTheseus()
        {
            Theseus theseus = myGame.GetTheseus();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("M's turn " + (i + 1));
                //M's X is not equal T's X
                if (column != theseus.column)
                {
                    HuntHorizontal();
                }
                else if (column == theseus.column)
                {
                    HuntVertical();
                }
            }
        }






    }
}

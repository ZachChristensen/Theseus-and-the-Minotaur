using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessTheseusMinotaur
{
    class Theseus : Character
    {
        public Theseus(int aColumn, int aRow) : base (aColumn, aRow)
        {
            
        }
        
        public Boolean IsAtExit()
        {
            //if ((aGame.GetTheseus().column == aGame.GetExit().column) && (aGame.GetTheseus().row == aGame.GetExit().row))
            if ((myGame.GetTheseus().column == myGame.GetExit().column) && (myGame.GetTheseus().row == myGame.GetExit().row))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

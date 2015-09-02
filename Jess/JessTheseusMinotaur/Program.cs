using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessTheseusMinotaur
{
    class Program
    {
        static void Main(string[] args)
        {
            Game aGame = new Game();
            aGame.MapOne();
            Console.WriteLine(aGame.TestMap(aGame.GetMapOne()));
            // Console.WriteLine(aGame.CreateMap(4, 3));
            //aGame.Go();
            
            while (aGame.GetTheseus().IsAtExit() == false)
            
            {
                aGame.Go();

            }
            //aGame.Go();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

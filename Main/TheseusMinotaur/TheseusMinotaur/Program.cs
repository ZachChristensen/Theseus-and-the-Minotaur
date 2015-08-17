using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class Program
    {
        static void Main(string[] args)
        {
            new Game().Play();
            Stop();
        }

        static void Stop()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

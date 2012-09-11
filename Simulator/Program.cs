using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            BanditSimulator sim = new BanditSimulator();
            sim.Run();

            Console.WriteLine("\n...press any key to exit.");
            Console.ReadKey();
        }
    }
}

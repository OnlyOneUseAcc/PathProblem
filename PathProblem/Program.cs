using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose graph type :");
            Console.WriteLine("\t1 - directive"); // true
            Console.WriteLine("\t2 - non directive"); // false
            string type = Console.ReadLine();
            bool gType;
            if (type == "1")
            {
                gType = true;
            } else
            {
                gType = false;
            }


            Graph ex = Reader.getGraph(@"D:\kejual projects\Practice\info.xlsx", gType);

            int max = ex.g.Count;
            Console.WriteLine("Choose edges from 1 to " + max);
            Console.WriteLine("Enter first stock");
            string first = Console.ReadLine();
            Console.WriteLine("Enter second stock");
            string second = Console.ReadLine();

            Dijkstra.findCoast(ex, Int32.Parse(first), Int32.Parse(second));

            Console.ReadKey();
        }
    }
}

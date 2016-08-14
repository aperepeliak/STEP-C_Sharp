using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace cs_5._2_generics_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> test = new MyList<int>();

            test.Add(5);
            test.Add(6);
            test.Add(1);
            test.Add(8);

            Write("My List:\t");
            foreach (var element in test)
            {
                Write($"{element} ");
            }

            Write("\nSize:\t\t");
            WriteLine($"{test.Size}");
        }
    }
}

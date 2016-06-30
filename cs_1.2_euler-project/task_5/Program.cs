using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
            int result = 20;
            while (result % 2 != 0 || result % 3 != 0 || result % 4 != 0 ||
                   result % 5 != 0 || result % 6 != 0 || result % 7 != 0 ||
                   result % 8 != 0 || result % 9 != 0 || result % 10 != 0 ||
                   result % 11 != 0 || result % 12 != 0 || result % 13 != 0 ||
                   result % 14 != 0 || result % 15 != 0 || result % 16 != 0 ||
                   result % 17 != 0 || result % 18 != 0 || result % 19 != 0 ||
                   result % 20 != 0)
            {
                result += 20;
            }
            Console.WriteLine("Result : {0}", result);
        }
    }
}

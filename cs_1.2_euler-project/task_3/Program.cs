using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // What is the largest prime factor of the number 600851475143 ?
            const long INIT_NUM = 600851475143;
            long number = INIT_NUM;
            int curDiv = 2;
            int maxDiv = 0;
            while (curDiv < (number / 2))
            {
                if ((number % curDiv) == 0)
                {
                    if (curDiv > maxDiv)
                    {
                        maxDiv = curDiv;
                    }
                    number = number / curDiv;
                    curDiv = 2;
                }
                else
                {
                    curDiv++;
                }
            }
            Console.WriteLine("The largest prime factor of the number {0} is : {1}", INIT_NUM, maxDiv);
        }
    }
}

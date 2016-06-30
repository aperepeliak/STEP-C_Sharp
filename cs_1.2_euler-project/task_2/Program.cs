using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // By starting with 1 and 2, the first 10 terms will be:  1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            // By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.

            int MAX_FIBO = 4000000;
            List<int> fibo = new List<int>();

            int a = 1, b = 1, c = 1;
            while (c < MAX_FIBO)
            {
                fibo.Add(b);
                c = a + b;
                a = b;
                b = c;
            }

            Console.WriteLine("fibo sequence up to 4 000 000: ");
            for (int i = 0; i < fibo.Count; i++)
            {
                Console.WriteLine("fibo[{0}] = {1}", i, fibo[i]);
            }
            Console.WriteLine("-------------------------------");

            int fiboSumEven = 0;
            for (int i = 0; i < fibo.Count; i++)
            {
                if ((fibo[i] % 2) == 0)
                {
                    fiboSumEven += fibo[i];
                }
            }
            Console.WriteLine("Sum of the even-valued terms : {0}", fiboSumEven);
        }
    }
}

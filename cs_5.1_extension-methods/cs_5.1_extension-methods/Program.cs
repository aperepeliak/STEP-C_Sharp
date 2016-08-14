using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace cs_5._1_extension_methods
{
    static class MyExtension
    {
        public static void MySort(this int[] arr)
        {
            int temp;
            // Bubble sort
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] testArr = { 2, 5, 7, 1 };

            Write("Before sort:\t");
            foreach(var el in testArr)
            {
                Write($"{el} ");
            }

            testArr.MySort();

            Write("\nAfter sort:\t");
            foreach (var el in testArr)
            {
                Write($"{el} ");
            }

            ReadKey();
        }
    }
}

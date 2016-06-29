using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrSize = 0;
            Console.Write("Введите размер массива -> ");
            var input = Console.ReadLine();
            arrSize = int.Parse(input);

            Console.WriteLine("Пользователь ввел размер массива {0}", arrSize);

            int rangeMin = 0;
            int rangeMax = 0;

            Console.Write("Введите минимальную границу значений массива -> ");
            input = Console.ReadLine();
            rangeMin = int.Parse(input);


            Console.Write("Введите максимальную границу значений массива -> ");
            input = Console.ReadLine();
            rangeMax = int.Parse(input);

            Console.WriteLine("Пользователь ввел диапазон значений массива от {0} до {1}", rangeMin, rangeMax);

            int[] arr = new int[arrSize];

            Random r = new Random();

            for (int i = 0; i < arrSize; i++)
            {
                arr[i] = r.Next(rangeMin, rangeMax);
            }

            for (int i = 0; i < arrSize; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }

            int arrMax = arr.Max();
            Console.WriteLine("Максимальное число в массиве = {0}", arrMax);

            int arrMin = arr.Min();
            Console.WriteLine("Минимальное число в массиве = {0}", arrMin);

            int positionMax = 0;
            int positionMin = 0;

            for (int i = 0; i < arrSize; i++)
            {
                if (arr[i] == arrMax)
                {
                    positionMax = i;
                }
                if (arr[i] == arrMin)
                {
                    positionMin = i;
                }
            }

            int newArrSize = Math.Abs(positionMax - positionMin) + 1;
            Console.WriteLine("Размер нового массива = {0}", newArrSize);

            int[] newArr = new int[newArrSize];

            if (positionMax > positionMin)
            {
                for (int i = positionMin, j = 0; i <= positionMax; i++, j++)
                {
                    newArr[j] = arr[i];
                }
            }
            else
            {
                for (int i = positionMax, j = 0; i <= positionMin; i++, j++)
                {
                    newArr[j] = arr[i];
                }
            }

            for (int i = 0; i < newArrSize; i++)
            {
                Console.WriteLine("newArr[{0}] = {1}", i, newArr[i]);
            }

            double arrAverage = arr.Average();
            Console.WriteLine("Среднее арифметическое первого массива = {0}", arrAverage);

            Console.Write("Вывод в консоль : ");
            for (int i = 0; i < newArrSize; i++)
            {
                if (newArr[i] > arrAverage)
                {
                    Console.Write("{0}  ", newArr[i]);
                }
            }
            Console.WriteLine("\n", arrAverage);
        }
    }
}

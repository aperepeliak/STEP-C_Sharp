using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_1._3_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string userString;
            Console.Write("Введите строку -> ");
            userString = Console.ReadLine();
            Console.WriteLine("Вы ввели : {0}", userString);
            Console.WriteLine("-----");

            // a)
            Console.WriteLine("а) Количество символов в строке: {0}", userString.Length);
            Console.WriteLine("-----");
            //-----------------------------------------

            // б)
            char mostOccurSymbol = '\0';
            int numOccur = 0;

            for (int i = 0; i < userString.Length; i++)
            {
                int counter = 0;
                for (int j = i; j < userString.Length; j++)
                {
                    if (userString[i] == userString[j])
                    {
                        counter++;
                    }
                }
                if (numOccur < counter)
                {
                    numOccur = counter;
                    mostOccurSymbol = userString[i];
                }
                counter = 0;
            }
            Console.WriteLine("Самый повторяющийся символ в строке : " + mostOccurSymbol + " он встречается {0} раз(-а)", numOccur);
            Console.WriteLine("-----");
        }
    }
}

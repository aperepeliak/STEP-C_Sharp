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
            StringAnalyzer(userString);
            Console.WriteLine("-----");

            

        }

        static void StringAnalyzer(string userString)
        {
            // a)
            Console.WriteLine("а) Количество символов в строке: {0}", userString.Length);
           
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
            Console.WriteLine("б) Самый повторяющийся символ в строке : " + mostOccurSymbol + " он встречается {0} раз(-а)", numOccur);
            

            // в)
            Console.WriteLine("в) Количество цифр в строке : {0}", userString.Count(char.IsDigit));
           
            // г)
            Console.WriteLine("г) Количество букв в верхнем регистре : {0}", userString.Count(char.IsUpper));
            
            // д)
            Console.WriteLine("д) Количество букв в нижнем регистре : {0}", userString.Count(char.IsLower));
            
            // e)
            int numSentences = (userString.Split('.').Length - 1) + (userString.Split('!').Length - 1) + (userString.Split('?').Length - 1);
            Console.WriteLine("е) Количество предложений : {0}", numSentences);
            
            // ж) 
            string[] words = userString.Split(' ');
            int counterNumbers = 0;
            foreach (var word in words)
            {
                double tmp = 0;
                bool isNumeric = double.TryParse(word, out tmp);
                if (isNumeric)
                {
                    counterNumbers++;
                }
            }
            Console.WriteLine("ж) Количество чисел в строке : {0}", counterNumbers);
            
        }
    }
}

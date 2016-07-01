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

            // 1)
            StringAnalyzer(userString);
            Console.WriteLine("\n-----\n");

            // 2)
            Console.Write("Введите символ для перевода его в верхний регистр в строке -> ");
            char symb = Console.ReadKey().KeyChar;
            Console.Write("\n");
            ChangeAndCountSymbol(ref userString, symb);
            Console.WriteLine("\n-----\n");

            // 3)
            ParseToArrayAndSort(userString);
            Console.WriteLine("\n-----\n");

            // 4)
            Console.Write("Введите пароль -> ");
            string password = Console.ReadLine();
            if (CheckPassword(password))
            {
                Console.Write("Пароль защищенный!\n");
            }
            else
            {
                Console.Write("Ошибка! Пароль недостаточно защищенный.\n");
            }
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

        static void ChangeAndCountSymbol(ref string userString, char symb)
        {
            // а)
            int counter = 0;
            char[] arrayChar = userString.ToCharArray();
            for (int i = 0; i < arrayChar.Length; i++)
            {
                if (arrayChar[i] == symb)
                {
                    arrayChar[i] = char.ToUpper(userString[i]);
                    counter++;
                }
            }
            userString = new string(arrayChar);
            Console.WriteLine("a) Символ '" + symb + "' встречается в строке {0} раз(-а)", counter);
            Console.WriteLine("Измененная строка : " + userString);

            // б)
            string[] words = userString.Split(' ');
            int countBeginWord = 0;
            foreach (var word in words)
            {
                if (word[0] == char.ToUpper(symb))
                {
                    countBeginWord++;
                }
            }
            Console.WriteLine("б) Символ '" + char.ToUpper(symb) + "' располагается в начале слова {0} раз(-а)", countBeginWord);
        }

        static void ParseToArrayAndSort(string userString)
        {
            // а)
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string[] words = userString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            Console.Write("а) Полученный массив слов в обратном порядке : \n");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("\t[{0}]:\t{1}", i, words[i]);
            }

            // б)
            Array.Sort(words);
            Console.Write("б) Сортировка по алфавиту : \n");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("\t[{0}]:\t{1}", i, words[i]);
            }
            int numWordsToDelete = 4;
            if (words.Length > numWordsToDelete)
            {
                words = words.Except(new string[] { words[0], words[1], words[words.Length - 2], words[words.Length - 1] }).ToArray();
                Console.Write("б) Без первых и последних двух слов : \n");
                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine("\t[{0}]:\t{1}", i, words[i]);
                }
            }
            else
            {
                Console.Write("Недостаточно слов в строке для удаления 4 слов \n");
            }

        }

        static bool CheckPassword(string password)
        {
            if (password.Length >= 8 && password.Any(char.IsLower) && password.Any(char.IsUpper) && password.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }
    }
}

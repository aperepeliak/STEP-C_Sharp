using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_4._2_delegates
{
    public delegate void DelegateStringProccesing(string input);

    class Menu
    {
        private string remove = "Удалить";
        private string add = "Добавить";

        public bool addCharCount = true;
        public bool addNumCount = true;
        public bool addWordCount = true;

        public string Str { get; set; }

        public void BeginInput()
        {
            Console.Write("Введите строку -> ");
            Str = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine("Menu :");
            if (addCharCount)
            {
                Console.WriteLine("1. " + add + " счетчик символов");
            }
            else
            {
                Console.WriteLine("1. " + remove + " счетчик символов");
            }

            if (addNumCount)
            {
                Console.WriteLine("2. " + add + " счетчик чисел");
            }
            else
            {
                Console.WriteLine("2. " + remove + " счетчик чисел");
            }

            if (addWordCount)
            {
                Console.WriteLine("3. " + add + " счетчик слов");
            }
            else
            {
                Console.WriteLine("3. " + remove + " счетчик слов");
            }

            Console.WriteLine("4. Начать ввод текста");
            Console.WriteLine("0. Выход");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DelegateStringProccesing summary = null;

            DelegateStringProccesing charCount = str => Console.WriteLine("Символов : {0}", str.Length);
            DelegateStringProccesing numCount = str =>
            {
                string[] words = str.Split(' ');
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
                Console.WriteLine("Чисел : {0}", counterNumbers);
            };
            DelegateStringProccesing wordCount = str => Console.WriteLine("Слов : {0}", str.Split(' ').Length);

            Menu m = new Menu();

            bool f = true;
            while (f)
            {
                m.Show();
                Console.Write("Выберите пункт меню -> ");
                int key;
                int.TryParse(Console.ReadLine(), out key);
                switch (key)
                {
                    case 1:
                        m.addCharCount = !m.addCharCount;
                        if (m.addCharCount)
                        {
                            summary -= charCount;
                        }
                        else
                        {
                            summary += charCount;
                        }
                        break;

                    case 2:
                        m.addNumCount = !m.addNumCount;
                        if (m.addNumCount)
                        {
                            summary -= numCount;
                        }
                        else
                        {
                            summary += numCount;
                        }
                        break;

                    case 3:
                        m.addWordCount = !m.addWordCount;
                        if (m.addWordCount)
                        {
                            summary -= wordCount;
                        }
                        else
                        {
                            summary += wordCount;
                        }
                        break;

                    case 4:
                        m.BeginInput();
                        summary(m.Str);
                        break;

                    case 0:
                        f = false;
                        Console.WriteLine("Завершение программы");
                        break;
                }
                //delay
                Console.Write("продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

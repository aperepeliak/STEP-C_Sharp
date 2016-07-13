using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs_3._3_abstract
{
    class Program
    {
        private static readonly int maxLosses = 3;

        abstract class Item
        {
            public abstract string Draw();
        }
        class A : Item
        {
            public override string Draw()
            {
                return "A";
            }
        }
        class B : Item
        {
            public override string Draw()
            {
                return "B";
            }
        }
        class C : Item
        {
            public override string Draw()
            {
                return "C";
            }
        }
        class Hero : Item
        {
            public override string Draw()
            {
                return "X";
            }
        }

        class Menu
        {
            public static int hero_x = 3;
            public static int hero_y = 3;
            static readonly int SIZE = 7;
            Item[,] _arr = new Item[SIZE, SIZE];
            public void Add(Item it, int x, int y)
            {
                _arr[x, y] = it;
            }
            public void Remove(int x, int y)
            {
                _arr[x, y] = null;
            }

            public void GenerateItems()
            {
                Random r = new Random();
                int letter = r.Next(1, 4);
                int probability = r.Next(0, 10);

                switch (letter)
                {
                    case 1:
                        _arr[r.Next(0, SIZE), 0] = new A();
                        break;
                    case 2:
                        _arr[r.Next(0, SIZE), 0] = new B();
                        break;
                    case 3:
                        _arr[r.Next(0, SIZE), 0] = new C();
                        break;
                }
                if (probability < 4)
                {
                    letter = r.Next(1, 4);
                    switch (letter)
                    {
                        case 1:
                            _arr[r.Next(0, SIZE), 0] = new A();
                            break;
                        case 2:
                            _arr[r.Next(0, SIZE), 0] = new B();
                            break;
                        case 3:
                            _arr[r.Next(0, SIZE), 0] = new C();
                            break;
                    }
                }
            }

            public void MoveLeft()
            {

            }
            public void MoveRight()
            {
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = SIZE - 1; j > 0; j--)
                    {
                        if (_arr[i, j] is Hero)
                        { }
                        else
                        {
                            _arr[i, j] = _arr[i, j - 1];
                            if (j == 1)
                            {
                                _arr[i, j - 1] = null;
                            }
                        }
                    }
                }
            }
            public void MoveUp()
            {
                hero_y = hero_y > 0 ? hero_y - 1 : hero_y;
                _arr[hero_y, 6] = new Hero();
                _arr[hero_y + 1, 6] = null;
            }
            public void MoveDown()
            {
                hero_y = hero_y < SIZE - 1 ? hero_y + 1 : hero_y;
                _arr[hero_y, 6] = new Hero();
                _arr[hero_y - 1, 6] = null;
            }

            public void Show()
            {
                for (int i = 0; i < SIZE; i++)
                {
                    Console.Write(" " + i);
                }
                Console.WriteLine();
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        Console.Write('|');
                        if (_arr[i, j] != null)
                            Console.Write(_arr[i, j].Draw());
                        else Console.Write(" ");
                    }
                    Console.WriteLine("|");
                }

            }
        }
        static void Main(string[] args)
        {
            Menu m = new Menu();
            m.Add(new Hero(), 3, 6);
            int losses = 0;

            while (losses < maxLosses)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            m.MoveDown();
                            break;
                        case ConsoleKey.UpArrow:
                            m.MoveUp();
                            break;
                        default:
                            break;
                    }
                }
                m.MoveRight();
                m.GenerateItems();
                Console.SetCursorPosition(0, 0);
                m.Show();
                Thread.Sleep(200);
            }
        }
    }
}

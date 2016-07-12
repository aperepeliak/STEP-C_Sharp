using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._3_abstract
{
    class Program
    {

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
        class Menu
        {
            Item[] _arr = new Item[7];
            public void Add(Item it, int position)
            {
                _arr[position] = it;
            }
            public void Remove(int position)
            {
                _arr[position] = null;
            }
            public void Show()
            {
                for (int i = 0; i < _arr.Length; i++)
                {
                    Console.Write(" " + i);
                }
                Console.WriteLine();
                for (int i = 0; i < _arr.Length; i++)
                {
                    Console.Write('|');
                    if (_arr[i] != null)
                        Console.Write(_arr[i].Draw());
                    else Console.Write(" ");
                }
                Console.Write("|");
            }
        }
        static void Main(string[] args)
        {
            Menu m = new Menu();
            m.Add(new A(), 2);
            m.Add(new A(), 5);
            m.Add(new A(), 6);
            m.Add(new B(), 1);
            m.Add(new B(), 4);
            m.Add(new C(), 0);
            m.Show();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_4._2_events
{
    class Program
    {
        //static private void Run()
        //{
           
        //}

        static void Main(string[] args)
        {
            Bug b = new Bug();

            b.danger += new DelegateDanger(b.Run);

            Console.WriteLine("Bug pos: {0}, {1}", b.x++, b.y++);
            Console.WriteLine("Bug pos: {0}, {1}", b.x++, b.y++);
            Console.WriteLine("Bug pos: {0}, {1}", b.x++, b.y++);
            Console.WriteLine("Bug pos: {0}, {1}", b.x++, b.y++);
            b.InvokeEvent();
            b.InvokeEvent();
            b.InvokeEvent();
            b.InvokeEvent();

            //test repo git

            Console.WriteLine("---------------------");
            Console.WriteLine("Bug pos: {0}, {1}", b.x++, b.y++);
            Console.WriteLine("Bug pos: {0}, {1}", b.x++, b.y++);
        }
    }
}

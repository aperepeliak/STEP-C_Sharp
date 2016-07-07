using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_2._3_operators_overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction("3/4");
            Fraction b = new Fraction("1/2");

            Console.WriteLine("Fraction a : " + a.Numerator.ToString() + "/" + a.Denominator.ToString());
            Console.WriteLine("Fraction b : " + b.Numerator.ToString() + "/" + b.Denominator.ToString());


            Fraction c = a + b;
            Console.WriteLine("Sum              : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            try
            {
                double d = 1.5d;
                c = a + d;
                Console.WriteLine("a + {0}          : " + c.Numerator.ToString() + "/" + c.Denominator.ToString(), d);
                c.Reduce();
                Console.WriteLine("a + {0} reduced  : " + c.Numerator.ToString() + "/" + c.Denominator.ToString(), d);
            }
            catch
            {
                Console.WriteLine("Введено не десятичное число.");
            }

            c = a - b;
            Console.WriteLine("Deduction        : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            c = a * b;
            Console.WriteLine("Multiplication   : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            c = a * 10;
            Console.WriteLine("a * 10           : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            c = 10 * a;
            Console.WriteLine("10 * a           : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            c = a / b;
            Console.WriteLine("Division         : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            c.Reduce();
            Console.WriteLine("Reduction        : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            Console.WriteLine("a < b            : " + (a < b).ToString());
            Console.WriteLine("a > b            : " + (a > b).ToString());
            Console.WriteLine("a <= b           : " + (a <= b).ToString());
            Console.WriteLine("a >= b           : " + (a >= b).ToString());
            Console.WriteLine("a == b           : " + (a == b).ToString());
            Console.WriteLine("a != b           : " + (a != b).ToString());




        }
    }
}

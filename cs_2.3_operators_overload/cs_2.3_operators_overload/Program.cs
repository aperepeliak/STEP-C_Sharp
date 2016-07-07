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
            Console.WriteLine("Sum       : " + c.Numerator.ToString() + "/" + c.Denominator.ToString());

            Fraction d = a - b;
            Console.WriteLine("Deduction : " + d.Numerator.ToString() + "/" + d.Denominator.ToString());

        }
    }
}

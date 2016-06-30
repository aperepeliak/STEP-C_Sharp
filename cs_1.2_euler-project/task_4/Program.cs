using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the largest palindrome made from the product of two 3-digit numbers.
            int largestPoLiThreeDigits = 0;
            for (int i = 999; i > 100; i--)
            {
                for (int j = 999; j > 100; j--)
                {
                    if (isPolindrome(i * j))
                    {
                        largestPoLiThreeDigits = ((i * j) > largestPoLiThreeDigits) ? (i * j) : largestPoLiThreeDigits;
                    }
                }
            }

            if (largestPoLiThreeDigits != 0)
            {
                Console.WriteLine("the largest palindrome made from the product of two 3-digit numbers : {0}", largestPoLiThreeDigits);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        static bool isPolindrome(int n)
        {
            string NumToString = n.ToString();
            char[] NumReverse = NumToString.Reverse().ToArray();
            for (int i = 0; i < NumToString.Length; i++)
            {
                if (NumToString[i] != NumReverse[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

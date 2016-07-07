using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_2._3_operators_overload
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        // Наименьший общий знаменатель
        private static int LCD(int a, int b)
        {
            int max = a > b ? a : b;
            for (int i = max; i < a * b; i += max)
            {
                if (i % a == 0 && i % b == 0)
                    return i;
            }
            return 1;
        }

        // Наибольший общий делитель
        private int GCD(int a, int b)
        {
            while (a>0 && b>0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a + b;
        }

        // Перегрузка конструкторов
        public Fraction(int n)
        {
            numerator = n;
            denominator = n > 0 ? n : 1;
        }
        public Fraction(int n, int d)
        {
            numerator = n;
            denominator = (d > 0) ? d : 1;
        }
        public Fraction (string fr)
        {
            numerator = Convert.ToInt32(fr.Split('/')[0]);
            denominator = Convert.ToInt32(fr.Split('/')[1]);
        }

        // Свойства
        public int Numerator
        {
            set
            {
                numerator = value;
            }
            get
            {
                return numerator;
            }
        }
        public int Denominator
        {
            set
            {
                denominator = value > 0 ? value : 1;
            }
            get
            {
                return denominator;
            }
        }

        // Сокращение дроби
        public void Reduce()
        {
            int div = GCD(numerator, denominator);
            numerator /= div;
            denominator /= div;
        }

        // Перегрузка опетаров
        public static Fraction operator + (Fraction a, Fraction b)
        {
            int tmpNum_1 = a.numerator * (LCD(a.denominator, b.denominator) / a.denominator);
            int tmpNum_2 = b.numerator * (LCD(a.denominator, b.denominator) / b.denominator);
            int newNum = tmpNum_1 + tmpNum_2;
            int newDen = LCD(a.denominator, b.denominator);
            return new Fraction(newNum, newDen);
        }
        public static Fraction operator - (Fraction a, Fraction b)
        {
            int tmpNum_1 = a.numerator * (LCD(a.denominator, b.denominator) / a.denominator);
            int tmpNum_2 = b.numerator * (LCD(a.denominator, b.denominator) / b.denominator);
            int newNum = tmpNum_1 - tmpNum_2;
            int newDen = LCD(a.denominator, b.denominator);
            return new Fraction(newNum, newDen);
        }



    }
}

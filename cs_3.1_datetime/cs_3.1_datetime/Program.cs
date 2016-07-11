using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._1_datetime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Количество воскресений, выпадающих на первое число месяца в XX веке : {0}", MonthFirstSundaysXXCentury());
            Console.WriteLine("Ближайшая пятница 13-го : {0:d}", NearestFriday13());
        }

        static int MonthFirstSundaysXXCentury()
        {
            DateTime start = new DateTime(1901, 1, 1);
            DateTime end = new DateTime(2000, 12, 1);
            int count = 0;
            int k = 1;
            while (start.AddMonths(k) < end)
            {
                if (start.AddMonths(k).DayOfWeek == DayOfWeek.Sunday)
                    count++;
                k++;
            }
            return count;
        }

        static DateTime NearestFriday13()
        {
            DateTime now = DateTime.Now;
            DateTime friday13 = DateTime.Now;
            while (now.DayOfWeek != DayOfWeek.Friday)
            {
                now = now.AddDays(1);
            }
            while (now.Day != 13)
            {
                now = now.AddDays(7);
            }
            return now;
        }

    }
}

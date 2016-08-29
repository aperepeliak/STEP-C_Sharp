using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Console;

namespace cs_7._1_XML
{
    struct ForecastDay
    {
        public string day;
        public string min;
        public string max;
        public string description;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ForecastDay[] forecast = new ForecastDay[7];
            string URLString = "http://api.pogoda.com/index.php?api_lang=ru&localidad=13088&affiliate_id=4v7j6at7rkya";

            var document = new XPathDocument(URLString);
            XPathNavigator navigator = document.CreateNavigator();

            XPathExpression expr = navigator.Compile("report/location/var[5]/data/forecast/@value");
            XPathNodeIterator iterator = navigator.Select(expr);

            var days = new List<string>();
            foreach (XPathNavigator day in iterator) { days.Add(day.Value); }

            expr = navigator.Compile("report/location/var[1]/data/forecast/@value");
            iterator = navigator.Select(expr);

            var minRange = new List<string>();
            foreach (XPathNavigator min in iterator) { minRange.Add(min.Value); }

            expr = navigator.Compile("report/location/var[2]/data/forecast/@value");
            iterator = navigator.Select(expr);

            var maxRange = new List<string>();
            foreach (XPathNavigator max in iterator) { maxRange.Add(max.Value); }

            expr = navigator.Compile("report/location/var[4]/data/forecast/@value");
            iterator = navigator.Select(expr);

            var description = new List<string>();
            foreach (XPathNavigator desc in iterator) { description.Add(desc.Value); }

            for (int i = 0; i < forecast.Length; i++)
            {
                forecast[i].day = days[i];
                forecast[i].min = minRange[i];
                forecast[i].max = maxRange[i];
                forecast[i].description = description[i];
            }
            DateTime now = DateTime.Now;
            WriteLine("Прогноз на ближайшую неделю:\n");
            foreach (var day in forecast)
            {
                WriteLine($"{now.ToShortDateString()}, {day.day}:{((day.day == "понедельник") || (day.day == "воскресенье") ? "" : "\t")} {day.min}-{day.max} °C {day.description}");
                now = now.AddDays(1);
            }

            WriteLine("\n\n");
        }
    }
}

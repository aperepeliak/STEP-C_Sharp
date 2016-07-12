using cs_3._2_inheritance.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //House projectOne = new House();
            //projectOne.parts.Add(new Basement());
            //projectOne.parts.Add(new Wall());
            //projectOne.parts.Add(new Wall());
            //projectOne.parts.Add(new Wall());
            //projectOne.parts.Add(new Wall());
            //projectOne.parts.Add(new Window());
            //projectOne.parts.Add(new Window());
            //projectOne.parts.Add(new Window());
            //projectOne.parts.Add(new Window());
            //projectOne.parts.Add(new Door());
            //projectOne.parts.Add(new Roof());

            House projectOne = new House(1, 4, 4, 1, 1);

            Team team1 = new Team();

            int ConstructionPeriod = 1;

            while (!projectOne.HouseIsReady())
            {
                Console.WriteLine("Start of the Day {0}", ConstructionPeriod);
                for (int i = 0; i < team1.workers.Count; i++)
                {
                    Console.Write("Worker {0} : ", i + 1);
                    team1.workers[i].Work(projectOne);
                }
                Console.WriteLine("\n------\n");
                ConstructionPeriod++;
                // Delay
                Console.WriteLine("Press Enter for the next day to start...");
                Console.ReadKey();
                Console.Clear();
            }


        }
    }
}

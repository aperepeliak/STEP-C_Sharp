using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class TeamLeader : IWorker
    {
        public void Work(House obj)
        {
            if (obj.HouseIsReady())
            {
                Console.WriteLine("We have finished the house!");
            }
            else
            {
                int i = 0;
                Console.Write("By now we have built: ");
                bool f = true;
                while (obj.parts[i].isBuilt)
                {
                    f = false;
                    string[] elements = obj.parts[i].ToString().Split('.');
                    Console.Write(elements[elements.Length - 1] + " ");
                    i++;
                }
                if (f)
                {
                    Console.Write("Nothing is yet finished.");
                }
            }
        }
    }
}

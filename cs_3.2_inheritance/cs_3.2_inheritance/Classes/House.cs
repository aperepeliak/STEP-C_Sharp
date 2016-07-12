using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class House
    {
        public List<IPart> parts;

        public bool houseIsBuilt { get; set; }
        public House()
        {
            parts = new List<IPart>();
            houseIsBuilt = false;
        }
        public House(int numBasements, int numWalls, int numWindows, int numDoors, int numRoofs)
        {
            parts = new List<IPart>();

            for (int i = 0; i < numBasements; i++)
            {
                parts.Add(new Basement());
            }

            for (int i = 0; i < numWalls; i++)
            {
                parts.Add(new Wall());
            }

            for (int i = 0; i < numWindows; i++)
            {
                parts.Add(new Window());
            }
            for (int i = 0; i < numDoors; i++)
            {
                parts.Add(new Door());
            }
            for (int i = 0; i < numRoofs; i++)
            {
                parts.Add(new Roof());
            }

            houseIsBuilt = false;
        }

        public bool HouseIsReady()
        {
            for (int i = 0; i < parts.Count; i++)
            {
                if (!parts[i].isBuilt)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

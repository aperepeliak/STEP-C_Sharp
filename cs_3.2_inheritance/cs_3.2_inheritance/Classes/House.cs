using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class House
    {
        private List<IPart> _parts;
        private bool _houseIsBuilt;

        public List<IPart> parts { get; set; }
        public bool houseIsBuilt { get; set; }
        public House()
        {
            _parts = new List<IPart>();
            _houseIsBuilt = false;
        }
        public House(int numBasements, int numWalls, int numWindows, int numDoors, int numRoofs)
        {
            _parts = new List<IPart>();

            for (int i = 0; i < numBasements + 1; i++)
            {
                parts.Add(new Basement());
            }

            for (int i = 0; i < numWalls + 1; i++)
            {
                parts.Add(new Walls());
            }

            for (int i = 0; i < numWindows + 1; i++)
            {
                parts.Add(new Window());
            }
            for (int i = 0; i < numDoors + 1; i++)
            {
                parts.Add(new Door());
            }
            for (int i = 0; i < numRoofs + 1; i++)
            {
                parts.Add(new Roof());
            }

            _houseIsBuilt = false;
        }
    }
}

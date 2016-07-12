using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class Roof : IPart
    {
        public bool isBuilt { get; set; }
        public int requiredTime { get; }
        public int buildingStatus { get; set; }

        public Roof()
        {
            isBuilt = false;
            requiredTime = 5;
            buildingStatus = 0;
        }
    }
}

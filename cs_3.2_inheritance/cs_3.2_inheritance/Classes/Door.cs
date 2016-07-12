using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class Door : IPart
    {
        public bool isBuilt { get; set; }
        public int requiredTime { get; }
        public int buildingStatus { get; set; }

        public Door()
        {
            isBuilt = false;
            requiredTime = 1;
            buildingStatus = 0;
        }
    }
}

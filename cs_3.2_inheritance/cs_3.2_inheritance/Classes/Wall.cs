using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class Wall : IPart
    {
        public bool isBuilt { get; set; }
        public int requiredTime { get; }
        public int buildingStatus { get; set; }

        public Wall()
        {
            isBuilt = false;
            requiredTime = 2;
            buildingStatus = 0;
        }
    }
}

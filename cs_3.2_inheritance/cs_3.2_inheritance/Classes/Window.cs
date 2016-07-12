using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance.Classes
{
    class Window
    {
        private bool _isBuilt = false;
        private int _requiredTime = 1;
        private int _buildingStatus = 0;

        public bool isBuilt { get; set; }
        public int requiredTime { get; }
        public int buildingStatus { get; set; }
    }
}

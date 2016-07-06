using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_2._1_classes
{
     partial class Laptop
    {
        private int memoryBanks;

        public int MemoryBanks
        {
            set
            {
                if (value < 0)
                    throw new Exception("Количество банков памяти не может отрицательным.");
                else
                    memoryBanks = value;
            }
            get
            {
                return memoryBanks;
            }
        }

        public void IncreaseMemory(int addons = 1)
        {
            memoryBanks += addons;
        }

        public void PullAllMemory()
        {
            memoryBanks = 0;
        }

    }
}

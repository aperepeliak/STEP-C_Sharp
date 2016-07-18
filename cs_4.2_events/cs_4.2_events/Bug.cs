using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_4._2_events
{
    public delegate void DelegateDanger();

    class Bug
    {
        public event DelegateDanger danger = null;

        public int x;
        public int y;

        //public int X { get; set; }
        //public int Y { get; set; }
        public string Name { get; set; }

        public void Move()
        {
            Random r = new Random();
            x = r.Next(2);
            y = r.Next(2);
        }

        public void Run()
        {
            x = x == 0 ? 0 : x-1;
            y = y == 0 ? 0 : y-1;
        }

        public void InvokeEvent()
        {
            danger.Invoke();
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs_4._2_events
{
    public delegate void DelegateDanger();

    class Bug
    {
        public event DelegateDanger danger = null;

        public int x;
        public int y;

        public string Name { get; set; }

        public void Move()
        {
            Random r = new Random();
            x += r.Next(0, 2);
            Thread.Sleep(10);
            y += r.Next(0, 2);
        }

        public void GoHome()
        {
            x = x == 0 ? 0 : x - 1;
            y = y == 0 ? 0 : y - 1;
        }

        public void InvokeEvent()
        {
            danger.Invoke();
        }

        public Bug(Cloud home)
        {
            x = y = 0;
            danger += new DelegateDanger(home.ScaredBug);
        }
    }
}

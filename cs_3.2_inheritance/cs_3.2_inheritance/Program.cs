using cs_3._2_inheritance.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_3._2_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            House projectOne = new House();
            projectOne.parts.Add(new Basement());
            projectOne.parts.Add(new Walls());
            projectOne.parts.Add(new Walls());
            projectOne.parts.Add(new Walls());
            projectOne.parts.Add(new Walls());
            projectOne.parts.Add(new Window());
            projectOne.parts.Add(new Window());
            projectOne.parts.Add(new Window());
            projectOne.parts.Add(new Window());
            projectOne.parts.Add(new Door());
            projectOne.parts.Add(new Roof());




        }
    }
}

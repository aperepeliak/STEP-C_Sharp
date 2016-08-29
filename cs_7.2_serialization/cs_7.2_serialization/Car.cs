using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_7._2_serialization
{
    public enum Color { Black, Green, Red, Navy, Olive, White, Pink };

    public enum Model { BMW, ZAZ, Mercedes, Mazda, VAZ, Nissan, Honda, Subaru, Toyota, VW};

    [Serializable]
    public class Car
    {
        static int ID = 1;
        public int Number { get; set; }
        public Color CarColor { get; set; }
        public Model CarModel { get; set; }

        public Car()
        {
            Number = ID++;
        }

        public Car(Color col, Model mod)
            : this()
        {
            CarColor = col;
            CarModel = mod;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_7._2_serialization
{
    [Serializable]
    public class AllCars
    {
        List<Car> availableCars;
        List<Car> parkedCars;
        List<Car> brokenCars;

        public AllCars()
        {
            availableCars = new List<Car>();
            parkedCars = new List<Car>();
            brokenCars = new List<Car>();
        }

        public void AddCar(Color col, Model mod)
        {
            availableCars.Add(new Car(col, mod));
        }

        public void RemoveCar(int index)
        {
            availableCars.RemoveAt(index);
        }

        public void AddParkedCar(Car carToPark)
        {
            parkedCars.Add(carToPark);
        }

        public void RemoveParkedCar(int index)
        {
            parkedCars.RemoveAt(index);
        }

        public void AddBrokenCar(Car brokenCar)
        {
            brokenCars.Add(brokenCar);
        }

        public void RemoveBrokenCar(int index)
        {
            brokenCars.RemoveAt(index);
        }
    }
}

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
            availableCars.Remove(carToPark);
        }

        public void RemoveParkedCar(int index)
        {
            parkedCars.RemoveAt(index);
        }

        public void AddBrokenCar(Car brokenCar)
        {
            brokenCars.Add(brokenCar);
            availableCars.Remove(brokenCar);
        }

        public void RemoveBrokenCar(int index)
        {
            brokenCars.RemoveAt(index);
        }

        public Car GetAvailableCar(int index)
        {
            return availableCars[index];
        }

        public Car GetBrokenCar(int index)
        {
            return brokenCars[index];
        }

        public Car GetParkedCar(int index)
        {
            return parkedCars[index];
        }

        public int GetNumberOfAvailableCars()
        {
            return availableCars.Count;
        }

        public int GetNumberOfBrokenCars()
        {
            return brokenCars.Count;
        }

        public int GetNumberOfParkedCars()
        {
            return parkedCars.Count;
        }

        public void FromParkedToService(Car toMove)
        {
            parkedCars.Add(toMove);
            brokenCars.Remove(toMove);
        }

        public void FromServiceToParked(Car toMove)
        {
            brokenCars.Add(toMove);
            parkedCars.Remove(toMove);
        }
    }
}

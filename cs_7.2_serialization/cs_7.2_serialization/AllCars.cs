using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_7._2_serialization
{
    /// <summary>
    /// Encapsulating class for all cars
    /// </summary>
    [Serializable]
    public class AllCars
    {
        public List<Car> availableCars;
        public List<Car> parkedCars;
        public List<Car> brokenCars;

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

        public void AddParkedCar(Car carToPark)
        {
            parkedCars.Add(carToPark);
            availableCars.Remove(carToPark);
        }

        public void AddBrokenCar(Car brokenCar)
        {
            brokenCars.Add(brokenCar);
            availableCars.Remove(brokenCar);
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

        public void FromServiceToParked(Car toMove)
        {
            parkedCars.Add(toMove);
            brokenCars.Remove(toMove); 
        }

        public void FromParkedToService(Car toMove)
        {
            brokenCars.Add(toMove);
            parkedCars.Remove(toMove);
        }

        public void RemoveByNumber(int index)
        {
            availableCars.RemoveAll(item => item.Number == index);
            brokenCars.RemoveAll(item => item.Number == index);
            parkedCars.RemoveAll(item => item.Number == index);
        }

        public void ShowRed()
        {
            foreach (var car in availableCars)
            {
                if (car.CarColor == Color.Red)
                {
                    car.Show();
                }
            }
            foreach (var car in brokenCars)
            {
                if (car.CarColor == Color.Red)
                {
                    car.Show();
                }
            }
            foreach (var car in parkedCars)
            {
                if (car.CarColor == Color.Red)
                {
                    car.Show();
                }
            }
        }

        public void ShowParkedAndServicedModels()
        {
            foreach (var parkedCar in parkedCars)
            {
                foreach (var brokenCar in brokenCars)
                {
                    if (parkedCar.CarModel == brokenCar.CarModel)
                    {
                        parkedCar.ShowModel();
                        break;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static System.Console;
using static System.Convert;


namespace cs_7._2_serialization
{
    /// <summary>
    /// Class menu for manipulation with Car objects
    /// </summary>
    class Menu
    {
        AllCars cars;

        /// <summary>
        /// Constructor. Deserializes data from Cars.xml
        /// </summary>
        public Menu()
        {
            FileInfo file = new FileInfo("Cars.xml");
            if (file.Exists)
            {
                using (var stream = new FileStream("Cars.xml", FileMode.Open))
                {
                    XmlSerializer serialize = new XmlSerializer(typeof(AllCars));
                    cars = serialize.Deserialize(stream) as AllCars;
                }
            }
            else
            {
                cars = new AllCars();
            }
        }

        /// <summary>
        /// Main menu
        /// </summary>
        public void Start()
        {
            bool f = true;
            while (f)
            {
                WriteLine("MENU");
                WriteLine("1. Add car");
                WriteLine("2. Add car to service center");
                WriteLine("3. Add car to parking lot");
                WriteLine("4. Show cars in service center");
                WriteLine("5. Show cars on parking lot");
                WriteLine("6. Move car from parking lot to service station");
                WriteLine("7. Move car from service station to parking lot");
                WriteLine("8. Remove car by number");
                WriteLine("9. Show all cars of red color");
                WriteLine("10. Show models that are both in parking lot and service station");
                WriteLine("11. Show available cars");
                WriteLine("0. Exit");
                Write("Your choice -> ");

                try
                {
                    switch (ToInt32(ReadLine()))
                    {
                        case 0:
                            f = false;
                            break;
                        case 1:
                            AddCar();
                            SaveChanges();
                            break;
                        case 2:
                            AddToServiceCenter();
                            SaveChanges();
                            break;
                        case 3:
                            AddToParkingLot();
                            SaveChanges();
                            break;
                        case 4:
                            ShowCarsInServiceCenter();
                            break;
                        case 5:
                            ShowCarsOnParkingLot();
                            break;
                        case 6:
                            MovefromParkingToService();
                            SaveChanges();
                            break;
                        case 7:
                            MoveFromServiceToParking();
                            SaveChanges();
                            break;
                        case 8:
                            RemoveCarByNumber();
                            SaveChanges();
                            break;
                        case 9:
                            ShowRedCars();
                            break;
                        case 10:
                            ModelsParkedAndServiced();
                            break;
                        case 11:
                            ShowAvailableCars();
                            break;
                    }
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    ReadKey();
                }
                Clear();
            }
        }

        private void ModelsParkedAndServiced()
        {
            cars.ShowParkedAndServicedModels();
            Footer();
        }

        private void ShowRedCars()
        {
            cars.ShowRed();
            Footer();
        }

        private void RemoveCarByNumber()
        {
            Write("Enter car number to remove -> ");
            int carNumber = ToInt32(ReadLine());
            cars.RemoveByNumber(carNumber);
            WriteLine($"\nThe car with the number {carNumber} has been removed.");
            Footer();
        }

        private void ShowAvailableCars()
        {
            for (int i = 0; i < cars.GetNumberOfAvailableCars(); i++)
            {
                cars.GetAvailableCar(i).Show();
            }

            Footer();
        }

        private void MoveFromServiceToParking()
        {
            cars.FromServiceToParked(ChooseCarFromServiceStation());

            Footer();
        }

        private Car ChooseCarFromServiceStation()
        {
            int n = cars.GetNumberOfBrokenCars();
            bool enterPressed = false;
            int count = 0;
            Write("Choose car from service station -> ");
            Write($"< {cars.GetBrokenCar(count).CarColor} {cars.GetBrokenCar(count).CarModel}, №{cars.GetBrokenCar(count).Number} >");

            while (!enterPressed)
            {
                int posX = 35;
                int posY = 14;

                if (KeyAvailable)
                {
                    ConsoleKeyInfo key = ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            count = (count < n - 1) ? count + 1 : 0;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetBrokenCar(count).CarColor} {cars.GetBrokenCar(count).CarModel}, №{cars.GetBrokenCar(count).Number} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetBrokenCar(count).CarColor} {cars.GetBrokenCar(count).CarModel}, №{cars.GetBrokenCar(count).Number} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            return cars.GetBrokenCar(count);
                    }
                }
            }
            return null;
        }

        private void MovefromParkingToService()
        {
            cars.FromParkedToService(ChooseCarFromParkingLot());

            Footer();
        }

        private Car ChooseCarFromParkingLot()
        {
            int n = cars.GetNumberOfParkedCars();
            bool enterPressed = false;
            int count = 0;
            Write("Choose car from parking lot -> ");
            Write($"< {cars.GetParkedCar(count).CarColor} {cars.GetParkedCar(count).CarModel}, №{cars.GetParkedCar(count).Number} >");

            while (!enterPressed)
            {
                int posX = 31;
                int posY = 14;

                if (KeyAvailable)
                {
                    ConsoleKeyInfo key = ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            count = (count < n - 1) ? count + 1 : 0;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetParkedCar(count).CarColor} {cars.GetParkedCar(count).CarModel}, №{cars.GetParkedCar(count).Number} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetParkedCar(count).CarColor} {cars.GetParkedCar(count).CarModel}, №{cars.GetParkedCar(count).Number} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            return cars.GetParkedCar(count);
                    }
                }
            }
            return null;
        }

        private void ShowCarsOnParkingLot()
        {
            for (int i = 0; i < cars.GetNumberOfParkedCars(); i++)
            {
                cars.GetParkedCar(i).Show();
            }

            Footer();
        }

        private void ShowCarsInServiceCenter()
        {
            for (int i = 0; i < cars.GetNumberOfBrokenCars(); i++)
            {
                cars.GetBrokenCar(i).Show();
            }

            Footer();
        }

        private void AddToParkingLot()
        {
            cars.AddParkedCar(ChooseCarFromAvailable());

            Footer();
        }

        private void AddToServiceCenter()
        {
            cars.AddBrokenCar(ChooseCarFromAvailable());
            Footer();
        }

        private Car ChooseCarFromAvailable()
        {
            int n = cars.GetNumberOfAvailableCars();
            bool enterPressed = false;
            int count = 0;
            Write("Choose available car -> ");
            Write($"< {cars.GetAvailableCar(count).CarColor} {cars.GetAvailableCar(count).CarModel} №:{cars.GetAvailableCar(count).Number} >");

            while (!enterPressed)
            {
                int posX = 24;
                int posY = 14;

                if (KeyAvailable)
                {
                    ConsoleKeyInfo key = ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            count = (count < n - 1) ? count + 1 : 0;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetAvailableCar(count).CarColor} {cars.GetAvailableCar(count).CarModel} №:{cars.GetAvailableCar(count).Number} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetAvailableCar(count).CarColor} {cars.GetAvailableCar(count).CarModel} №:{cars.GetAvailableCar(count).Number} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            return cars.GetAvailableCar(count);
                    }
                }
            }
            return null;
        }

        private void AddCar()
        {
            cars.AddCar(ChooseColor(), ChooseModel());
        }

        private Model ChooseModel()
        {
            Model result = Model.BMW;
            int n = Enum.GetNames(typeof(Model)).Length;
            string[] modelNames = Enum.GetNames(typeof(Model));
            int count = 0;
            bool enterPressed = false;
            Write($"\nChoose model -> ");

            Write($"< {modelNames[count]} >");

            while (!enterPressed)
            {
                int posX = 16;
                int posY = 15;

                if (KeyAvailable)
                {
                    ConsoleKeyInfo key = ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            count = (count < n - 1) ? count + 1 : 0;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {modelNames[count]} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {modelNames[count]} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            result = (Model)count;
                            break;
                    }
                }
            }
            return result;
        }

        private Color ChooseColor()
        {
            Color result = Color.Black;
            int n = Enum.GetNames(typeof(Color)).Length;
            string[] colorNames = Enum.GetNames(typeof(Color));
            int count = 0;
            bool enterPressed = false;
            Write($"Choose color -> ");
            Write($"< {colorNames[count]} >");

            while (!enterPressed)
            {
                int posX = 16;
                int posY = 14;

                if (KeyAvailable)
                {
                    ConsoleKeyInfo key = ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            count = (count < n - 1) ? count + 1 : 0;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {colorNames[count]} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {colorNames[count]} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            result = (Color)count;
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Serializes data after each change
        /// </summary>
        private void SaveChanges()
        {
            XmlSerializer serialize = new XmlSerializer(typeof(AllCars));
            var stream = new FileStream("Cars.xml", FileMode.Create, FileAccess.Write);
            serialize.Serialize(stream, cars);
            stream.Close();
        }

        private void Footer()
        {
            WriteLine("\nPress any key to continue...");
            ReadKey();
        }
    }
}

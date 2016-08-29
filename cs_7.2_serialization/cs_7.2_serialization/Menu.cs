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
    class Menu
    {
        AllCars cars;

        public Menu()
        {
            using (var stream = new FileStream("Cars.xml", FileMode.Open))
            {
                XmlSerializer serialize = new XmlSerializer(typeof(AllCars));
                cars = serialize.Deserialize(stream) as AllCars;
            }
            if (cars == null)
            {
                cars = new AllCars();
            }
        }

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
                WriteLine("8. Remove car with the number starting from 18");
                WriteLine("9. Show all cars of red color");
                WriteLine("10. Show models that are both in parking lot and service station");
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
                            break;
                        case 3:
                            AddToParkingLot();
                            break;
                        case 4:
                            ShowCarsInServiceCenter();
                            break;
                        case 5:
                            ShowCarsOnParkingLot();
                            break;
                        case 6:
                            MovefromParkingToService();
                            break;
                        case 7:
                            MoveFromServiceToParking();
                            break;
                        case 8:

                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                    }
                }
                catch
                {
                    WriteLine("Invalid input, try again");
                    ReadKey();
                }
                Clear();
            }
        }

        private void MoveFromServiceToParking()
        {
            cars.FromServiceToParked(ChooseCarFromServiceStation());

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private Car ChooseCarFromServiceStation()
        {
            int n = cars.GetNumberOfParkedCars();
            bool enterPressed = false;
            int count = 0;
            Write($"< {cars.GetBrokenCar(count)} >");

            while (!enterPressed)
            {
                int posX = 20;
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
                            Write($"< {cars.GetBrokenCar(count)} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetBrokenCar(count)} >");
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

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private Car ChooseCarFromParkingLot()
        {
            int n = cars.GetNumberOfParkedCars();
            bool enterPressed = false;
            int count = 0;
            Write($"< {cars.GetParkedCar(count)} >");

            while (!enterPressed)
            {
                int posX = 20;
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
                            Write($"< {cars.GetParkedCar(count)} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetParkedCar(count)} >");
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

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private void ShowCarsInServiceCenter()
        {
            for (int i = 0; i < cars.GetNumberOfBrokenCars(); i++)
            {
                cars.GetBrokenCar(i).Show();
            }

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private void AddToParkingLot()
        {
            cars.AddParkedCar(ChooseCarFromAvailable());

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private void AddToServiceCenter()
        {
            cars.AddBrokenCar(ChooseCarFromAvailable());

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private Car ChooseCarFromAvailable()
        {
            int n = cars.GetNumberOfAvailableCars();
            bool enterPressed = false;
            int count = 0;
            Write($"< {cars.GetAvailableCar(count)} >");

            while (!enterPressed)
            {
                int posX = 20;
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
                            Write($"< {cars.GetAvailableCar(count)} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {cars.GetAvailableCar(count)} >");
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
            Write($"< {modelNames[count]} >");

            while (!enterPressed)
            {
                int posX = 20;
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
                            result = (Model)ToInt32(modelNames[count]);
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
            Write($"< {colorNames[count]} >");

            while (!enterPressed)
            {
                int posX = 20;
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
                            result = (Color)ToInt32(colorNames[count]);
                            break;
                    }
                }
            }
            return result;
        }

        private void SaveChanges()
        {
            XmlSerializer serialize = new XmlSerializer(typeof(AllCars));
            var stream = new FileStream("Cars.xml", FileMode.Create, FileAccess.Write);
            serialize.Serialize(stream, cars);
            stream.Close();
        }
    }
}

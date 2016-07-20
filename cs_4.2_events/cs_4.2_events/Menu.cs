using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_4._2_events
{
    class Menu
    {
        Cloud home;

        public void Start()
        {
            bool f = true;
            while (f)
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Создать жука");
                Console.WriteLine("2. Испугать жука №...");
                Console.WriteLine("3. Сделать ход");
                Console.WriteLine("4. Посмотреть текущее положение жуков");
                Console.WriteLine("0. Выход");

                Console.Write("Ваш выбор -> ");
                string menuItem = Console.ReadLine();
                int key;
                int.TryParse(menuItem, out key);
                switch (key)
                {
                    case 1:
                        AddBug();
                        break;

                    case 2:
                        ScareBug();
                        break;

                    case 3:
                        MakeStep();
                        break;

                    case 4:
                        ShowBugs();
                        break;

                    case 0:
                        Console.WriteLine("Всего доброго!");
                        f = false;
                        break;

                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        break;
                }

                //Delay
                Console.Write("\n\n\nНажмите любую клавишу для продолжения ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowBugs()
        {
            home.Show();
        }

        private void MakeStep()
        {
            home.NextStep();
        }

        private void ScareBug()
        {
            Console.Write("Введите номер жука : ");
            int index = int.Parse(Console.ReadLine());
            if (index < 0 || index > home.bugs.Count())
            {
                Console.WriteLine("Жука с таким номером не существует");
            }
            else
            {
                home.bugs[index].InvokeEvent();
                Console.WriteLine("Жук № {0} напуган и его страх передается всему рою", index);
            }
        }

        private void AddBug()
        {
            home.CreateBug();
            Console.WriteLine("Новый жук успешно создан");
        }

        public Menu()
        {
            home = new Cloud();
        }
    }
}

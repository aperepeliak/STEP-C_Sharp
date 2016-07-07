using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_2._2_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Product test = new Product();
            test.Info();

            bool f = false;
            while (!f)
            {
                try
                {
                    Console.Write("Введите название товара -> ");
                    test.Name = Console.ReadLine();
                    Console.WriteLine("------");
                    f = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            f = false;
            while (!f)
            {
                try
                {
                    Console.Write("Введите описание товара -> ");
                    test.Description = Console.ReadLine();
                    Console.WriteLine("------");
                    f = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            f = false;
            while (!f)
            {
                try
                {
                    Console.Write("Введите длину -> ");
                    test.Length = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("------");
                    f = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Размер должен быть целым числом, указанным в мм");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            f = false;
            while (!f)
            {
                try
                {
                    Console.Write("Введите ширину -> ");
                    test.Width = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("------");
                    f = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Размер должен быть целым числом, указанным в мм");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            f = false;
            while (!f)
            {
                try
                {
                    Console.Write("Введите высоту -> ");
                    test.Height = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("------");
                    f = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Размер должен быть целым числом, указанным в мм");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            f = false;
            while (!f)
            {
                try
                {
                    Console.Write("Введите цену товара -> ");
                    test.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("------");
                    f = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введен недопустимый формат цены");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Информация о товаре : \n");
            test.Info();
        }
    }
}

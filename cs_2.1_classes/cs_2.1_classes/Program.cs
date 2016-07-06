using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_2._1_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание списка из 5 объектов 
            List<Laptop> laptops = new List<Laptop>();
            laptops.Add(new Laptop(Brand.Apple, Material.Metal, Color.White, 87400));
            laptops.Add(new Laptop(12999));
            laptops.Add(new Laptop(Brand.Asus, 28700));
            laptops.Add(new Laptop());
            laptops.Add(new Laptop(Brand.HP, Material.Plastic, Color.Black, 19000));

            for (int i = 0; i < laptops.Count; i++)
            {
                laptops[i].Info();
                Console.WriteLine("-----------------------");
            }

            // Проверка исключения
            try
            {
                laptops[1].Brandname = (Brand)10;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("-----------------------");

            bool flashDrive = false;
            Console.WriteLine("USB-flash drive is connected -> " + flashDrive.ToString());
            laptops[0].ConnectDevice(ref flashDrive);
            Console.WriteLine("USB-flash drive is connected -> " + flashDrive.ToString());
            Console.WriteLine("-----------------------");

            Console.WriteLine("Number of memory banks in laptop : " + laptops[0].MemoryBanks.ToString());
            laptops[0].IncreaseMemory();
            Console.WriteLine("After single increase : " + laptops[0].MemoryBanks.ToString());
            laptops[0].IncreaseMemory(3);
            Console.WriteLine("After triple increase : " + laptops[0].MemoryBanks.ToString());
            laptops[0].PullAllMemory();
            Console.WriteLine("After pulling all memory : " + laptops[0].MemoryBanks.ToString());
            Console.WriteLine("-----------------------");

            Console.WriteLine(Convert.ChangeType(laptops[0].Brandname, laptops[0].Brandname.GetTypeCode())); 
        }
    }
}

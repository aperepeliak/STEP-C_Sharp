using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_2._1_classes
{
    public enum Brand { NoBrand = 1, Dell, Apple, Acer, HP, Asus, MSI, Lenovo };
    public enum Material { NoMaterial = 1, Plastic, Metal, Composite };
    public enum Color { NoColor = 1, White, Black, Metallic, Pink };

    partial class Laptop
    {
        // Закрытые поля
        private Brand brandname;
        private Material materialType;
        private Color color;
        private bool isOpen;
        private int price;


        // Статические поля
        static int webcam = 1;
        static bool keyboard;

        // Методы доступа к закрытым полям
        public Brand Brandname
        {
            set
            {
                if (Convert.ToInt32(value) < 1 || Convert.ToInt32(value) > Enum.GetNames(typeof(Brand)).Length)
                    throw new Exception("Такой модели ноутбука не существует");
                brandname = value;
            }
            get
            {
                return brandname;
            }
        }
        public Material MaterialType
        {
            set
            {
                if (Convert.ToInt32(value) < 1 || Convert.ToInt32(value) > Enum.GetNames(typeof(Material)).Length)
                    throw new Exception("Такого материала ноутбука не существует");
                materialType = value;
            }
            get
            {
                return materialType;
            }
        }
        public Color Color
        {
            set
            {
                if (Convert.ToInt32(value) < 1 || Convert.ToInt32(value) > Enum.GetNames(typeof(Color)).Length)
                    throw new Exception("Нет такого цвета");
                Color = value;
            }
            get
            {
                return color;
            }
        }
        public int Price
        {
            set
            {
                if (value < 0)
                    throw new Exception("Введена недопустимая цена");
                else
                    price = value;
            }

            get
            {
                if (price == 0)
                    throw new Exception("Цена для данного товара не указана");
                else
                    return price;
            }
        }
        
        // Статический конструктор
        static Laptop()
        {
            keyboard = true;
        }

        // Конструктор по умолчанию
        public Laptop()
        {
            brandname = Brand.NoBrand;
            materialType = Material.NoMaterial;
            color = Color.NoColor;
            isOpen = false;
        }

        // Перегруженные конструкторы
        public Laptop(int price)
        {
            this.price = price;
            brandname = Brand.NoBrand;
            materialType = Material.NoMaterial;
            color = Color.NoColor;
            isOpen = false;
        }
        public Laptop(Brand br, int price)
        {
            brandname = br;
            materialType = Material.NoMaterial;
            color = Color.NoColor;
            this.price = price;
            isOpen = false;
        }
        public Laptop(Brand br, Material m, Color c, int price)
        {
            brandname = br;
            materialType = m;
            color = c;
            this.price = price;
            isOpen = false;
        }

        // Создать метод, в который передаются аргументы по ссылке
        public void ConnectDevice(ref bool deviceConnected)
        {
            deviceConnected = true;
        }

        public void OpenLaptop()
        {
            isOpen = true;
        }

        public void Info()
        {
            Console.WriteLine("Brand    : " + brandname.ToString());
            Console.WriteLine("Material : " + materialType.ToString());
            Console.WriteLine("Color    : " + color.ToString());
            Console.WriteLine("Price    : " + price.ToString() + " UAH");
        }
    }
}

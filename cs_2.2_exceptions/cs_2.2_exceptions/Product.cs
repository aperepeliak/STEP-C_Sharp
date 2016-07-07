using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_2._2_exceptions
{
    class Product
    {
        private string name;
        private string description;

        private int length;
        private int width;
        private int height;

        private decimal price;

        public string Name
        {
            set
            {
                if (value.Length < 4)
                {
                    throw new Exception("Название товара дожно иметь не менее 4 символов");
                }
                else if (value.Length > 63)
                {
                    throw new Exception("Слишком длинное название товара");
                }
                else if (value.Any(char.IsLetter) == false)
                {
                    throw new Exception("Название товара должно содержать минимум одну букву");
                }
                else if (char.IsNumber(value[0]) || char.IsPunctuation(value[0]))
                {
                    throw new Exception("Название товара не может начинать с цифры или знака пунктуации");
                }
                else
                {
                    name = value;
                }
            }
            get
            {
                if (name == "undefined")
                {
                    throw new Exception("Название товара не указано");
                }
                else
                {
                    return name;
                }
            }
        }
        public string Description
        {
            set
            {
                if (value.Length > 255)
                {
                    throw new Exception("Слишком длинное описание");
                }
                else
                {
                    description = value;
                }

            }
            get
            {
                return description;
            }
        }

        public int Length
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Задана недопустимая длина");
                }
                else
                {
                    length = value;
                }
            }
            get
            {
                if (length == 0)
                {
                    throw new Exception("Длина не задана");
                }
                else
                {
                    return length;
                }
            }
        }
        public int Width
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Задана недопустимая ширина");
                }
                else
                {
                    width = value;
                }
            }
            get
            {
                if (width == 0)
                {
                    throw new Exception("Ширина не задана");
                }
                else
                {
                    return width;
                }
            }
        }
        public int Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Задана недопустимая высота");
                }
                else
                {
                    height = value;
                }
            }
            get
            {
                if (height == 0)
                {
                    throw new Exception("Высота не задана");
                }
                else
                {
                    return height;
                }
            }
        }

        public decimal Price
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Недопустимое значение цены");
                }
                else if ((BitConverter.GetBytes(decimal.GetBits(value)[3])[2]) > 2)
                {
                    throw new Exception("Цена не может содержать более 2 цифр после запятой");
                }
                else
                {
                    price = value;
                }
            }
            get
            {
                if (price == 0)
                {
                    throw new Exception("Цена не указана");
                }
                else
                {
                    return price;
                }
            }
        }

        public Product()
        {
            name = "undefined";
            description = "no";
            length = width = height = 0;
            price = 0;
        }

        public void Info()
        {
            Console.WriteLine("Название     : " + name);
            Console.WriteLine("Описание     : " + description);
            Console.WriteLine("Длина        : " + length.ToString() + " мм");
            Console.WriteLine("Ширина       : " + width.ToString() + " мм");
            Console.WriteLine("Высота       : " + height.ToString() + " мм");
            Console.WriteLine("Цена         : " + price.ToString() + " грн");
            Console.WriteLine("-------------");
        }
    }
}

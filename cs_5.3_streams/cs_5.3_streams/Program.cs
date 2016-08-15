using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

using static System.Console;

namespace cs_5._3_streams
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool f = true;
            //var directory = new DirectoryInfo(@".");

            ////while(f)
            ////{

            ////}

            //if (directory.Exists)
            //{
            //    WriteLine($"Current directory: {directory.FullName}");
            //} else
            //{
            //    WriteLine("directory not found");
            //}

            //directory = new DirectoryInfo(@"D:\Study\");
            //if (directory.Exists)
            //{
            //    WriteLine($"Current directory: {directory.FullName}");
            //}
            //else
            //{
            //    WriteLine("directory not found");
            //}

            //string search = "каталог";
            //string str = ReadLine();
            //directory = new DirectoryInfo(@str);
            //if (directory.Exists)
            //{
            //    WriteLine($"Current directory: {directory.FullName}");

            //    // Получаем все файлы с расширением .txt.
            //    FileInfo[] files = directory.GetFiles("*" + search + "*", SearchOption.AllDirectories);
            //    DirectoryInfo[] dirs = directory.GetDirectories("*" + search + "*", SearchOption.AllDirectories);

            //    // Сколько файлов с расширением .txt в данной директории.
            //    WriteLine("Найдено {0} файлов\n", files.Length);

            //    // Выводим информацию о каждом файле.
            //    foreach (FileInfo file in files)
            //    {
            //        WriteLine("File name : {0}", file.Name);
            //        WriteLine("File size : {0}", file.Length);
            //        WriteLine("Creation  : {0}", file.CreationTime);
            //        WriteLine("Attributes: {0}", file.Attributes.ToString());
            //        Write("\n");
            //    }



            //    WriteLine("Найдено {0} папок\n", dirs.Length);

            //    // Выводим информацию о каждом файле.
            //    foreach (DirectoryInfo dir in dirs)
            //    {
            //        WriteLine("File name : {0}", dir.Name);
            //        //WriteLine("File size : {0}", dir.Length);
            //        WriteLine("Creation  : {0}", dir.CreationTime);
            //        WriteLine("Attributes: {0}", dir.Attributes.ToString());
            //        Write("\n");
            //    }
            //}
            //else
            //{
            //    WriteLine("directory not found");
            //}

            Menu test = new Menu();
            test.Start();


        }
    }
}

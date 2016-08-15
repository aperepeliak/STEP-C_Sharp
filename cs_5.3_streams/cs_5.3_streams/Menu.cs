using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
using static System.Convert;

namespace cs_5._3_streams
{
    class Menu
    {

        SearchEngine mySearch;

        public Menu()
        {
            mySearch = new SearchEngine();
        }

        public void Start()
        {
            bool f = true;
            while (f)
            {
                WriteLine("MENU: ");
                WriteLine("1. Search files and folders");
                WriteLine("0. Exit App");
                WriteLine("-----");
                Write("Your choice -> ");
                try
                {
                    int key = ToInt32(ReadLine());
                    switch (key)
                    {
                        case 1:
                            Submenu();
                            break;
                        case 0:
                            WriteLine("Good Bye!");
                            f = false;
                            break;

                        default:
                            WriteLine("No such option");
                            break;
                    }

                }
                catch
                {
                    Clear();
                    WriteLine("Error! Invalid input");
                    Write($"\nPress any key to retry ...");
                    ReadKey();

                }
                Clear();
            }
        }

        void Submenu()
        {
            bool f = true;
            while (f)
            {
                Clear();
                WriteLine($"MENU\n | -- Search Files and Folders\n");
                WriteLine($"Current directory: {mySearch.Directory.FullName}");
                WriteLine("------");
                WriteLine($"1. Change directory");
                WriteLine($"2. Search by Name...");
                WriteLine($"3. Search by Size...");
                WriteLine($"4. Search by Date...");
                WriteLine($"0. Back to main menu");
                WriteLine("------");
                Write($"Your choice -> ");
                bool correctPath = false;

                try
                {
                    switch (ToInt32(ReadLine()))
                    {
                        case 0:
                            f = false;
                            break;
                        case 1:
                            while (!correctPath)
                            {
                                Clear();
                                WriteLine($"MENU\n | -- Search Files and Folders\n\t | -- Change directory\n");
                                Write($"Enter new path -> ");
                                string str = ReadLine();
                                if (mySearch.SetNewPath(str))
                                {
                                    Write($"New path: { mySearch.Directory.FullName}");
                                    correctPath = true;
                                }
                                else
                                {
                                    Write($"New path: path not found");
                                    correctPath = false;
                                }
                                // Delay
                                Write($"\n\nPress any key to continue ...");
                                ReadKey();
                                Clear();
                            }
                            break;
                        case 2:
                            Clear();
                            WriteLine($"MENU\n | -- Search Files and Folders\n\t | -- Search by Name\n");
                            WriteLine($"Current directory: { mySearch.Directory.FullName}");
                            Write($"Enter name of file or directory to search -> ");
                            string toSearch = ReadLine();
                            FileInfo[] files = mySearch.SearchFiles(toSearch);
                            DirectoryInfo[] dirs = mySearch.SearchDirs(toSearch);
                            WriteLine($"{files.Length} files found");
                            WriteLine($"{dirs.Length} directories found");


                            // Delay
                            ReadKey();
                            Clear();
                            break;
                    }
                }
                catch
                {
                    Clear();
                    WriteLine("Error! Invalid input");
                    Write($"\nPress any key to retry ...");
                    ReadKey();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                WriteLine("MENU: \n\n");
                WriteLine("1. Search files and folders");
                WriteLine("2. Search txt files by content");
                WriteLine("3. Remove html tags");
                WriteLine("0. Exit App");
                WriteLine("-----");
                Write("Your choice -> ");
                try
                {
                    int key = ToInt32(ReadLine());
                    switch (key)
                    {
                        case 1:
                            Submenu_SearchFilesAndFolders();
                            break;
                        case 2:
                            Submenu_SearchByContent();
                            break;
                        case 3:
                            Submenu_RemoveHTMLTags();
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

        void Submenu_SearchFilesAndFolders()
        {
            bool f = true;
            while (f)
            {
                Header("Search Files and Folders", true);
                WriteLine($"1. Change directory");
                WriteLine($"2. Search by Name");
                WriteLine($"3. Search by Size");
                WriteLine($"4. Search by Date");
                WriteLine($"0. Back to main menu");
                WriteLine("------");
                Write($"Your choice -> ");

                try
                {
                    switch (ToInt32(ReadLine()))
                    {
                        case 0:
                            f = false;
                            break;
                        case 1:
                            Submenu_ChangeActiveDirectory();
                            break;
                        case 2:
                            Submenu_SearchByName();
                            break;
                        case 3:
                            Submenu_SearchBySize();
                            break;
                        case 4:
                            Submenu_SearchByDate();
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

        public void Submenu_ChangeActiveDirectory()
        {
            bool correctPath = false;
            while (!correctPath)
            {
                Header("Search Files and Folders", false, "Change directory");
                Write($"Enter new path -> ");
                SendKeys.SendWait($"{mySearch.CurrentDirectory.FullName}");
                string str = ReadLine();
                if (mySearch.SetNewPath(str))
                {
                    Write($"New path: { mySearch.CurrentDirectory.FullName}");
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
        }

        public void Submenu_SearchByName()
        {
            Header("Search Files and Folders", true, "Search by Name");
            Write($"Enter name of file or directory to search -> ");
            string toSearch = ReadLine();
            FileInfo[] files = mySearch.SearchFiles(toSearch);
            DirectoryInfo[] dirs = mySearch.SearchDirs(toSearch);
            WriteLine($"{files.Length} file{(files.Length == 1 ? "" : "s")} found");
            WriteLine($"{dirs.Length} director{(dirs.Length == 1 ? "y" : "ies")} found");

            bool subFlag = true;
            bool firstDisplay = true;

            do
            {
                if (firstDisplay)
                {
                    WriteLine($"\n\t>F< -- List files");
                    WriteLine($"\t>D< -- List directories");
                    WriteLine($"\t>Q< -- Exit");

                    Write($"\tYour choice -> ");
                    firstDisplay = false;
                }
                else
                {
                    Header("Search Files and Folders", true, "Search by Name");
                    WriteLine($"{files.Length} file{(files.Length == 1 ? "" : "s")} found");
                    WriteLine($"{dirs.Length} director{(dirs.Length == 1 ? "y" : "ies")} found");
                    Write("-----\n");
                    WriteLine($"\n\t>F< -- List files");
                    WriteLine($"\t>D< -- List directories");
                    WriteLine($"\t>Q< -- Exit");

                    Write($"\tYour choice -> ");
                }

                try
                {
                    switch (ToChar(ReadLine()))
                    {
                        case 'f':
                        case 'F':
                            ShowFiles(files);
                            break;

                        case 'd':
                        case 'D':
                            ShowDirs(dirs);
                            break;

                        case 'q':
                        case 'Q':
                            subFlag = false;
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
            } while (subFlag);
        }

        public void Submenu_SearchBySize()
        {
            Header("Search Files and Folders", true, "Search by Size");
            Write($"Search for files that are less than ('L' - default) or more than ('M')? -> ");
            string option = ReadLine();
            Write($"Enter size in KB -> ");
            int toSearch = ToInt32(ReadLine());
            FileInfo[] files = mySearch.SearchBySize(toSearch, (option == "M" ? "M" : "L"));
            WriteLine($"{files.Length} file{(files.Length == 1 ? "" : "s")} found");

            ShowFiles(files);
        }

        public void Submenu_SearchByDate()
        {
            Header("Search Files and Folders", true, "Search by Creation Date");
            Write($"Search for files that are created Earlier than ('E' - default) or Later than ('L')? -> ");
            string option = ReadLine();
            Write($"Enter date ('dd-mm-yyyy' or 'dd.mm.yyyy') -> ");
            DateTime toSearch = ToDateTime(ReadLine());
            FileInfo[] files = mySearch.SearchByDate(toSearch, (option == "L" ? "L" : "E"));
            WriteLine($"{files.Length} file{(files.Length == 1 ? "" : "s")} found");

            ShowFiles(files);
        }

        public void ShowFiles(FileInfo[] files)
        {
            int i = 1;
            int yPos = 15;
            int fileNamePos = 4;
            int fileSizePos = 60;
            int fileCreationDatePos = 75;
            int fileExtensionPos = 100;

            int fileNameMaxLength = 50;

            SetCursorPosition(0, yPos);
            Write($"№");
            SetCursorPosition(fileNamePos, yPos);
            Write($"| File Name");
            SetCursorPosition(fileSizePos, yPos);
            Write($"| Size, KB");
            SetCursorPosition(fileCreationDatePos, yPos);
            Write($"| Creation Date");
            SetCursorPosition(fileExtensionPos, yPos);
            Write($"| Extension");
            yPos++;
            SetCursorPosition(0, yPos);
            Write(new string('-', 113));
            yPos++;

            foreach (FileInfo file in files)
            {
                SetCursorPosition(0, yPos);
                Write($"{i++}");
                SetCursorPosition(fileNamePos, yPos);
                Write($"| {file.Name.Truncate(fileNameMaxLength)}");
                SetCursorPosition(fileSizePos, yPos);
                Write($"| {(file.Length / 1000)}");
                SetCursorPosition(fileCreationDatePos, yPos);
                Write($"| {file.CreationTime}");
                SetCursorPosition(fileExtensionPos, yPos);
                Write($"| {file.Extension.Truncate(5)}");
                yPos++;
            }

            Write("\n\nPress any key to return...");
            // Delay
            ReadKey();
            Clear();
        }

        public void ShowDirs(DirectoryInfo[] dirs)
        {
            int i = 1;
            int yPos = 15;
            int dirNamePos = 4;
            int dirFullName = 30;

            int dirNameMaxLength = 20;
            int dirFullNameMaxLength = 80;

            SetCursorPosition(0, yPos);
            Write($"№");
            SetCursorPosition(dirNamePos, yPos);
            Write($"| Directory Name");
            SetCursorPosition(dirFullName, yPos);
            Write($"| Full Name");
            yPos++;
            SetCursorPosition(0, yPos);
            Write(new string('-', 113));
            yPos++;

            foreach (DirectoryInfo dir in dirs)
            {
                SetCursorPosition(0, yPos);
                Write($"{i++}");
                SetCursorPosition(dirNamePos, yPos);
                Write($"| {dir.Name.Truncate(dirNameMaxLength)}");
                SetCursorPosition(dirFullName, yPos);
                Write($"| {dir.FullName.Truncate(dirFullNameMaxLength)}");
                yPos++;
            }
            Write("\n\nPress any key to return...");
            // Delay
            ReadKey();
            Clear();
        }

        private void Submenu_SearchByContent()
        {
            bool f = true;
            while (f)
            {
                Header("Search text files by content", true);
                WriteLine($"1. Change directory");
                WriteLine($"2. Start search...");
                WriteLine($"3. Files manipulation");
                WriteLine($"0. Back to main menu");
                WriteLine("------");
                Write($"Your choice -> ");

                try
                {
                    switch (ToInt32(ReadLine()))
                    {
                        case 0:
                            f = false;
                            break;

                        case 1:
                            Submenu_ChangeActiveDirectory();
                            break;

                        case 2:
                            Submenu_SearchContent();
                            break;

                        case 3:
                            Submenu_FilesManip();
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

        public void Submenu_SearchContent()
        {
            Header("Search text files by content", true, "Start search...");
            Write($"Enter content to search -> ");
            string toSearch = ReadLine();
            FileInfo[] files = mySearch.SearchByContent(toSearch);
            WriteLine($"{files.Length} file{(files.Length == 1 ? "" : "s")} found");

            ShowFiles(files);

        }

        public void Submenu_FilesManip()
        {
            bool f = true;
            while (f)
            {
                Header("Search text files by content", true, "Files manipilation");
                WriteLine($"1. Delete file");
                WriteLine($"2. Copy to...");
                WriteLine($"3. Move to...");
                WriteLine($"0. Back to previous menu");
                WriteLine("------");
                Write($"Your choice -> ");
                try
                {
                    switch (ToInt32(ReadLine()))
                    {
                        case 0:
                            f = false;
                            break;

                        case 1:
                            Submenu_Delete();
                            break;

                        case 2:
                            Submenu_CopyTo();
                            break;

                        case 3:
                            Submenu_MoveTo();
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

        public void Submenu_Delete()
        {
            Header("Search text files by content", false, "Files Manipulation", "Delete");
            Write($"Enter text file name to delete -> {mySearch.CurrentDirectory.FullName}\\");
            string toDelete = ReadLine();
            Write("-----\n");
            string formattedFileName = (toDelete.Contains('.') ? toDelete : toDelete + ".txt");
            if (mySearch.fileIsFound(formattedFileName))
            {
                Write($"Are you sure you want to delete {formattedFileName} (y/n)? -> ");
                string clarify = ReadLine();
                if (clarify == "y" || clarify == "Y")
                {
                    mySearch.DeleteFile(formattedFileName);
                    WriteLine($"File {formattedFileName} was succesfully deleted.");
                }
                else
                {
                    WriteLine($"Abort delete.");
                }
            }
            else
            {
                WriteLine($"File {formattedFileName} is not found.");
            }

            Write("\n\nPress any key to return...");
            // Delay
            ReadKey();
            Clear();
        }

        public void Submenu_CopyTo()
        {
            Header("Search text files by content", false, "Files Manipulation", "Copy to ...");
            Write($"Enter text file name to copy -> {mySearch.CurrentDirectory.FullName}\\");
            string toCopy = ReadLine();

            string formattedFileName = (toCopy.Contains('.') ? toCopy : toCopy + ".txt");
            if (mySearch.fileIsFound(formattedFileName))
            {
                Write($"\nEnter destination path -> ");
                SendKeys.SendWait($"{mySearch.CurrentDirectory.FullName}");
                string destPath = ReadLine();
                mySearch.CopyFile(mySearch.CurrentDirectory.FullName, destPath, formattedFileName);
                WriteLine($"File {formattedFileName} was succesfully copied to {destPath}");
            }
            else
            {
                WriteLine($"File {formattedFileName} is not found.");
            }
            Write("\n\nPress any key to return...");
            // Delay
            ReadKey();
            Clear();
        }

        public void Submenu_MoveTo()
        {

        }

        public void Submenu_RemoveHTMLTags()
        {
            throw new NotImplementedException();
        }

        void Header(string menuItem, bool displayCurrentPath, string subMenuItem = "", string secondSubItem = "")
        {
            Clear();
            Write($"MENU\n ");
            Write($"{(menuItem == "" ? "" : "| -- ")}{menuItem}\n\t");
            Write($"{(subMenuItem == "" ? "" : "| -- ")}{subMenuItem}\n\t\t");
            Write($"{(secondSubItem == "" ? "" : "| -- ")}{secondSubItem}\n");
            Write("\n");
            if (displayCurrentPath)
            {
                WriteLine($"Current directory: { mySearch.CurrentDirectory.FullName}");
                Write("-----\n");
            }



        }

    }

    static class StringExtendClass
    {
        public static string Truncate(this string str, int maxLength)
        {
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }
    }
}

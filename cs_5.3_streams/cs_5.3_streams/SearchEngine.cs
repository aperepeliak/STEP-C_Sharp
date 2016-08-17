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
    class SearchEngine
    {
        public DirectoryInfo CurrentDirectory { get; set; }

        public bool SetNewPath(string str)
        {
            CurrentDirectory = new DirectoryInfo(@str);
            if (CurrentDirectory.Exists)
                return true;
            else
                return false;
        }

        public FileInfo[] SearchFiles(string toSearch)
        {
            return CurrentDirectory.GetFiles("*" + toSearch + "*", SearchOption.AllDirectories);
        }

        public FileInfo[] SearchBySize(int SizeKB, string option)
        {
            FileInfo[] tmp = CurrentDirectory.GetFiles("*", SearchOption.AllDirectories);
            List<FileInfo> files = new List<FileInfo>();
            if (option == "L")
            {
                foreach (var file in tmp)
                {
                    if ((file.Length / 1000) <= SizeKB)
                    {
                        files.Add(file);
                    }
                }
                return files.ToArray();
            }
            else
            {
                foreach (var file in tmp)
                {
                    if ((file.Length / 1000) >= SizeKB)
                    {
                        files.Add(file);
                    }
                }
                return files.ToArray();
            }

        }

        public FileInfo[] SearchByDate(DateTime date, string option)
        {
            FileInfo[] tmp = CurrentDirectory.GetFiles("*", SearchOption.AllDirectories);
            List<FileInfo> files = new List<FileInfo>();
            if (option == "L")
            {
                foreach (var file in tmp)
                {
                    if (file.CreationTime >= date)
                    {
                        files.Add(file);
                    }
                }
                return files.ToArray();
            }
            else
            {
                foreach (var file in tmp)
                {
                    if (file.CreationTime <= date)
                    {
                        files.Add(file);
                    }
                }
                return files.ToArray();
            }
        }

        public FileInfo[] SearchByContent(string toSearch)
        {
            FileInfo[] tmp = CurrentDirectory.GetFiles("*.txt", SearchOption.AllDirectories);
            List<FileInfo> files = new List<FileInfo>();
            foreach (var file in tmp)
            {
                StreamReader reader = File.OpenText(file.FullName.ToString());
                string input;
                while ((input = reader.ReadLine()) != null)
                {
                    if (input.Contains(toSearch, StringComparison.OrdinalIgnoreCase))
                    {
                        files.Add(file);
                        break;
                    }
                }
                reader.Close();
            }
            return files.ToArray();
        }

        public DirectoryInfo[] SearchDirs(string toSearch)
        {
            return CurrentDirectory.GetDirectories("*" + toSearch + "*", SearchOption.AllDirectories);
        }

        public bool fileIsFound(string fileName)
        {
            var file = new FileInfo($"{CurrentDirectory.FullName}\\{fileName}");
            if (file.Exists)
                return true;
            else
                return false;
        }

        public void DeleteFile(string fileName)
        {
            var file = new FileInfo($"{CurrentDirectory.FullName}\\{fileName}");
            file.Delete();
        }

        public void CopyFile(string source, string dest, string file)
        {
            string sourceFile = Path.Combine(source, file);
            string destFile = Path.Combine(dest, file);
            if (!Directory.Exists(dest))
            {
                Directory.CreateDirectory(dest);
            }
            File.Copy(sourceFile, destFile, true);
        }

        public void EditFile(string fileName, string oldValue, string newValue)
        {
            var file = new FileInfo($"{CurrentDirectory.FullName}\\{fileName}");
            string text = File.ReadAllText(file.FullName.ToString());
            text = text.Replace(oldValue, newValue);
            File.WriteAllText(file.FullName.ToString(), text);
        }

        public SearchEngine()
        {
            CurrentDirectory = new DirectoryInfo(@".");
        }
    }
}

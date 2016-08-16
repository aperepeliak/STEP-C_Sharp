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
        public DirectoryInfo Directory { get; set; }

        public bool SetNewPath(string str)
        {
            Directory = new DirectoryInfo(@str);
            if (Directory.Exists)
                return true;
            else
                return false;
        }

        public FileInfo[] SearchFiles(string toSearch)
        {
            return Directory.GetFiles("*" + toSearch + "*", SearchOption.AllDirectories);
        }

        public FileInfo[] SearchBySize(int SizeKB, string option)
        {
            FileInfo[] tmp = Directory.GetFiles("*", SearchOption.AllDirectories);
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
            } else
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

        public DirectoryInfo[] SearchDirs(string toSearch)
        {
            return Directory.GetDirectories("*" + toSearch + "*", SearchOption.AllDirectories);
        }

        public SearchEngine()
        {
            Directory = new DirectoryInfo(@".");
        }
    }
}

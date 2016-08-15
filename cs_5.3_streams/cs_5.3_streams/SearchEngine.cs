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

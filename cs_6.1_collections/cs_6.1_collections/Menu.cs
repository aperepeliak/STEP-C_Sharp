using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
using static System.Convert;

namespace cs_6._1_collections
{
    class Menu
    {
        List<Student> students;
        List<Teacher> teachers;

        public Menu()
        {
            students = new List<Student>();
            teachers = new List<Teacher>();
            FileInfo file = new FileInfo("Students.txt");
            if (file.Exists)
            {
                StreamReader reader = File.OpenText(file.ToString());
                string input;
                while ((input = reader.ReadLine()) != null)
                {
                    string[] data = input.Split(';');
                    string firstN = data[0].Split(',')[0];
                    string lastN = data[0].Split(',')[1];
                    int teachID = ToInt32(data[1]);
                    string[] gradesString = data[2].Split(',');
                    List<int> grades = new List<int>();
                    foreach (string grade in gradesString) {
                        grades.Add(ToInt32(grade));
                    }
                    students.Add(new Student(firstN, lastN, teachID, grades));
                }
                reader.Close();
            }
            else
            {
                WriteLine("File was not found");
            }


        }

        public void Start()
        {
            foreach (var student in students)
            {
                student.Show();
            }
        }
    }
}

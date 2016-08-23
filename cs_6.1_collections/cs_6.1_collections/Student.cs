using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace cs_6._1_collections
{
    class Student
    {
        static int counterID = 0;
        string firstName;
        string lastName;
        public List<int> grades;

        public int StudentID { get; }
        public int TeacherID { get; set; }


        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == "")
                {
                    throw new Exception("Empty string");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == "")
                {
                    throw new Exception("Empty string");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public Student(string firstN, string lastN, int teacherID)
        {
            StudentID = counterID++;
            FirstName = firstN;
            LastName = lastN;
            grades = new List<int>();
            TeacherID = teacherID;
        }

        public Student(string firstN, string lastN, int teacherID, List<int> _grades)
        {
            StudentID = counterID++;
            FirstName = firstN;
            LastName = lastN;
            grades = new List<int>();
            TeacherID = teacherID;
            grades = new List<int>(_grades);
        }

        public void Show()
        {
            WriteLine($"{FirstName} {LastName}"); ;
            WriteLine($"Teacher ID: {TeacherID}");
            Write($"Grades: ");
            foreach (var grade in grades)
            {
                Write($" {grade} ");
            }
            Write("\n-----------\n");
        }
    }
}

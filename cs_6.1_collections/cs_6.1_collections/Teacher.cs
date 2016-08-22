using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_6._1_collections
{
    class Teacher
    {
        static int counterID = 0;
        string firstName;
        string lastName;
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

        public int TeacherID { get; }

        List<Student> myStudents;

        public Teacher(string firstN, string lastN)
        {
            TeacherID = counterID++;
            FirstName = firstN;
            LastName = lastN;
            myStudents = new List<Student>();
        }
    }
}

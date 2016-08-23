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
                    if (data[2] != "")
                    {
                        string[] gradesString = data[2].Split(',');
                        List<int> grades = new List<int>();
                        foreach (string grade in gradesString)
                        {
                            grades.Add(ToInt32(grade));
                        }
                        students.Add(new Student(firstN, lastN, teachID, grades));
                    } else
                    {
                        students.Add(new Student(firstN, lastN, teachID));
                    }
                    
                }
                reader.Close();
            }

            file = new FileInfo("Teachers.txt");
            if (file.Exists)
            {
                StreamReader reader = File.OpenText(file.ToString());
                string input;
                while ((input = reader.ReadLine()) != null)
                {
                    string[] data = input.Split(';');
                    string firstN = data[0].Split(',')[0];
                    string lastN = data[0].Split(',')[1];

                    if (data[1] != "")
                    {
                        string[] studsID = data[1].Split(',');
                        List<int> studs = new List<int>();
                        foreach (var stud in studsID)
                        {
                            studs.Add(ToInt32(stud));
                        }
                        teachers.Add(new Teacher(firstN, lastN, studs));
                    }
                    else
                    {
                        teachers.Add(new Teacher(firstN, lastN));
                    }




                }
                reader.Close();
            }



        }

        public void Start()
        {
            bool f = true;
            while (f)
            {
                WriteLine("MENU");
                WriteLine("1. List all students");
                WriteLine("2. List all teachers");
                WriteLine("3. Add student");
                WriteLine("4. Add teacher");
                WriteLine("5. A teacher with the biggest number of students");
                WriteLine("6. List students with an average grade higher than 10");
                WriteLine("7. List students who have more than 3 grades");
                WriteLine("8. Teachers and their students");
                WriteLine("9. The most active teacher");
                WriteLine("10. Choose students who have teacher XXX and have at least one 10, 11 or 12 grade");
                Write("Your choice -> ");
                try
                {
                    switch (ToInt32(ReadLine()))
                    {
                        case 0:
                            f = false;
                            break;

                        case 1:
                            ListAllStudents();
                            break;

                        case 2:
                            ListAllTeachers();
                            break;

                        case 3:
                            AddStudent();
                            SaveChanges();
                            break;

                        case 4:
                            break;

                        case 5:
                            break;

                        case 6:
                            break;

                        case 7:
                            break;

                        case 8:
                            break;

                        case 9:
                            break;

                        case 10:
                            break;
                    }
                }
                catch (Exception e) { WriteLine(e.Message); }
                ReadKey();
                Clear();
            }


        }

        private void AddStudent()
        {
            Write("\nAdd first name -> ");
            string newFirstName = ReadLine();
            Write("\nAdd last name -> ");
            string newLastName = ReadLine();
            Write("\nAssign a teacher -> ");

            int n = teachers.Count;
            int count = 0;
            bool enterPressed = false;

            Write($"< {teachers[count].FirstName} {teachers[count].LastName} >");

            while (!enterPressed)
            {
                int posX = 20;
                int posY = 17;
                if (KeyAvailable)
                {
                    ConsoleKeyInfo key = ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            count = (count < n - 1) ? count + 1 : 0;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {teachers[count].FirstName} {teachers[count].LastName} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {teachers[count].FirstName} {teachers[count].LastName} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ListAllTeachers()
        {
            foreach (var teacher in teachers)
            {
                teacher.Show();
            }
            WriteLine("Press any key...");
            ReadKey();
        }

        void ListAllStudents()
        {
            foreach (var student in students)
            {
                student.Show();
            }
            WriteLine("Press any key...");
            ReadKey();
        }

        void SaveChanges()
        {

        }
    }
}

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
                    }
                    else
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
                WriteLine("5. Add grade");
                WriteLine("6. A teacher with the biggest number of students");
                WriteLine("7. List students with an average grade higher than 10");
                WriteLine("8. List students who have more than 3 grades");
                WriteLine("9. Teachers and their students");
                WriteLine("10. The most active teacher");
                WriteLine("11. Choose students who have teacher XXX and have at least one 10, 11 or 12 grade");
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
                            AddTeacher();
                            SaveChanges();
                            break;

                        case 5:
                            AddGrade();
                            SaveChanges();
                            break;

                        case 6:
                            MostPopularTeacher();
                            break;

                        case 7:
                            Nerds();
                            break;

                        case 8:
                            ActiveStudents();
                            break;

                        case 9:
                            break;

                        case 10:
                            break;

                        case 11:
                            break;
                    }
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    ReadKey();
                }
                Clear();
            }
        }

        private void ActiveStudents()
        {
            List<Student> activeStudents = new List<Student>();
            foreach (var student in students)
            {
                if (student.grades.Count > 3)
                {
                    activeStudents.Add(student);
                }
            }
            WriteLine("Result: ");
            if (activeStudents.Count > 0)
            {
                activeStudents.Sort((x, y) => y.grades.Count.CompareTo(x.grades.Count));
                foreach (var student in activeStudents)
                {
                    WriteLine($"{student.FirstName} {student.LastName} (number of grades: {student.grades.Count})");
                }
            } else
            {
                WriteLine("No match found");
            }
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private void Nerds()
        {
            List<Student> nerds = new List<Student>();
            foreach (var student in students)
            {
                if (student.grades.Average() > 10)
                {
                    nerds.Add(student);
                }
            }
            WriteLine("Result: ");
            if (nerds.Count > 0)
            {
                foreach (var student in nerds)
                {
                    WriteLine("{0} {1} (average grade: {2:F2})",
                        student.FirstName,
                        student.LastName,
                        student.grades.Average());
                }
            }
            else
            {
                WriteLine("No match found");
            }
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private void MostPopularTeacher()
        {
            int count = 0;
            int maxID = 0;
            foreach (var teacher in teachers)
            {
                if (teacher.myStudents.Count > count)
                {
                    count = teacher.myStudents.Count;
                    maxID = teacher.TeacherID;
                }
            }
            WriteLine($"Result: {teachers[maxID].FirstName} {teachers[maxID].LastName} (has {count} students)");
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private void AddGrade()
        {
            Write("\nChoose a student -> ");
            int n = students.Count;
            int count = 0;
            bool enterPressed = false;

            Write($"< {students[count].FirstName} {students[count].LastName} >");

            while (!enterPressed)
            {
                int posX = 20;
                int posY = 14;
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
                            Write($"< {students[count].FirstName} {students[count].LastName} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 0) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {students[count].FirstName} {students[count].LastName} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            int grade = ChooseGrade();
                            students[count].grades.Add(grade);
                            WriteLine("\n\nThe new grade was succesfully added.");
                            WriteLine("Press any key to continue...");
                            ReadKey();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private int ChooseGrade()
        {
            Write("\nChoose grade -> ");
            int n = 13;
            int count = 1;
            bool enterPressed = false;

            Write($"< {count} >");

            while (!enterPressed)
            {
                int posX = 16;
                int posY = 15;
                if (KeyAvailable)
                {
                    ConsoleKeyInfo key = ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            count = (count < n - 1) ? count + 1 : 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {count} >");
                            break;
                        case ConsoleKey.LeftArrow:
                            count = (count == 1) ? n - 1 : count - 1;
                            SetCursorPosition(posX, posY);
                            Write(new string(' ', WindowWidth));
                            SetCursorPosition(posX, posY);
                            Write($"< {count} >");
                            break;
                        case ConsoleKey.Enter:
                            enterPressed = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            return count;
        }

        private void AddTeacher()
        {
            Write("\nAdd first name -> ");
            string newFirstName = ReadLine();
            Write("Add last name -> ");
            string newLastName = ReadLine();
            teachers.Add(new Teacher(newFirstName, newLastName));
            WriteLine("\n\nThe new teacher was succesfully added.");
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private void AddStudent()
        {
            Write("\nAdd first name -> ");
            string newFirstName = ReadLine();
            Write("Add last name -> ");
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
                            students.Add(new Student(newFirstName, newLastName, count));
                            teachers[count].myStudents.Add(students[students.Count - 1].StudentID);
                            WriteLine("\n\nThe new student was succesfully added.");
                            WriteLine("Press any key to continue...");
                            ReadKey();
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
            FileInfo file = new FileInfo("Students.txt");
            StreamWriter writer = file.CreateText();
            foreach (var student in students)
            {
                string concat = string.Join(",", student.grades.ToArray());
                writer.WriteLine($"{student.FirstName},{student.LastName};{student.TeacherID};{(concat != "" ? concat : "")}");

            }
            writer.Close();

            file = new FileInfo("Teachers.txt");
            writer = file.CreateText();
            foreach (var teacher in teachers)
            {
                string concat = string.Join(",", teacher.myStudents.ToArray());
                writer.WriteLine($"{teacher.FirstName},{teacher.LastName};{(concat != "" ? concat : "")}");
            }
            writer.Close();
        }
    }
}

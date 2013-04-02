using System;
using System.Collections.Generic;
using System.Linq;

namespace SortStudents
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class SortStudents
    {
        static void Main()
        {
            Student[] students = {
                                    new Student { FirstName = "Ivan", LastName = "Vasilev", Age = 20 },
                                    new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 26 },
                                    new Student { FirstName = "Stanimir", LastName = "Ivanov", Age = 18 },
                                    new Student { FirstName = "George", LastName = "Johnson", Age = 22 },
                                 };

            var sortedStudents = students.OrderByDescending(stud => stud.FirstName).ThenByDescending(stud => stud.LastName);

            Console.WriteLine("Sorted with Lambda expression:\n");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            var sortedStudentsLINQ = from student in students
                                     orderby student.FirstName descending, student.LastName descending
                                     select new { FirstName = student.FirstName, LastName = student.LastName };

            Console.WriteLine("\nSorted with LINQ:\n");
            foreach (var student in sortedStudentsLINQ)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}

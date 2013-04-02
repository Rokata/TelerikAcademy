using System;
using System.Linq;

namespace StudentsNames
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class StudentsNamesDemo
    {
        static void Main()
        {
            Student[] students = {
                                    new Student { FirstName = "Ivan", LastName = "Vasilev", Age = 20 },
                                    new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 26 },
                                    new Student { FirstName = "Stanimir", LastName = "Ivanov", Age = 21 },
                                    new Student { FirstName = "George", LastName = "Johnson", Age = 22 },
                                 };

            var resultStudents = from student in students
                                 where student.FirstName.CompareTo(student.LastName) < 0
                                 select new { firstName = student.FirstName, lastName = student.LastName };

            foreach (var student in resultStudents)
            {
                Console.WriteLine("{0} {1}", student.firstName, student.lastName);
            }
        }
    }
}

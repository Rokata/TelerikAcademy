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

    class AgeStudents
    {
        static void Main()
        {
            Student[] students = {
                                    new Student { FirstName = "Ivan", LastName = "Vasilev", Age = 20 },
                                    new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 26 },
                                    new Student { FirstName = "Stanimir", LastName = "Ivanov", Age = 17 },
                                    new Student { FirstName = "George", LastName = "Johnson", Age = 22 },
                                 };

            var resultStudents = from student in students
                                 where student.Age >= 18 && student.Age <= 24
                                 select new { firstName = student.FirstName, lastName = student.LastName };

            foreach (var student in resultStudents)
            {
                Console.WriteLine("{0} {1}", student.firstName, student.lastName);
            }
        }
    }
}
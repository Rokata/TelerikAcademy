using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanHierachy
{
    class HumanHierarchy
    {
        public static void PrintCollection(List<Human> list)
        {
            foreach (Human h in list) Console.WriteLine("{0} {1}", h.FirstName, h.LastName);
        }

        static void Main()
        {
            List<Student> students = new List<Student>(10);

            students.Add(new Student("Ivan", "Ivanov", 4.54));
            students.Add(new Student("Georgi", "Petrov", 5.12));
            students.Add(new Student("Atanas", "Petrov", 3.54));
            students.Add(new Student("Yavor", "Todorov", 6.00));
            students.Add(new Student("Boris", "Borisov", 5.09));
            students.Add(new Student("Kiril", "Nedev", 4.88));
            students.Add(new Student("Ivailo", "Sergeev", 3.24));
            students.Add(new Student("Matei", "Kaziiski", 5.02));
            students.Add(new Student("David", "Beckham", 4.22));
            students.Add(new Student("Lionel", "Messi", 4.02));

            var sortedStudents = students.OrderBy(x => x.Grade);

            Console.WriteLine("Sorted students by grade: \n");
            PrintCollection(sortedStudents.ToList<Human>());

            Console.WriteLine();

            List<Worker> workers = new List<Worker>(10);

            workers.Add(new Worker("Georgi", "Georgiev", 150.23, 8));
            workers.Add(new Worker("Ivan", "Petrov", 270.23, 7));
            workers.Add(new Worker("Petar", "Mihailov", 402.23, 9));
            workers.Add(new Worker("Cristiano", "Ronaldo", 200000.00, 4));
            workers.Add(new Worker("Xabi", "Alonso", 150000.00, 4));
            workers.Add(new Worker("Bill", "Gates", 200000000.00, 12));
            workers.Add(new Worker("Wayne", "Rooney", 240000.43, 4));
            workers.Add(new Worker("Robin", "van Persie", 300000.00, 5));
            workers.Add(new Worker("Luis", "Nani", 120000.50, 4));
            workers.Add(new Worker("Georgi", "Vasilev", 720.44, 8));

            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());

            Console.WriteLine("Sorted workers by money per hour: \n");
            PrintCollection(sortedWorkers.ToList<Human>());

            Console.WriteLine();

            List<Human> humans = new List<Human>(20);
            humans.AddRange(students);
            humans.AddRange(workers);

            var sortedHumans = humans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            Console.WriteLine("Sorted humans by first and last name: \n");
            PrintCollection(sortedHumans.ToList<Human>());
        }
    }
}

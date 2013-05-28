using System;

namespace StudentDemo
{
    class StudentDemo
    {
        static void Main()
        {
            Student s1 = new Student("Pesho", "Ivanov", "Ivanov", 8832738273, "Imaginary Str 44", 3849384398, 
                "pesho@test.net", 3, Specialty.Law, University.SofiaUniversity, Faculty.FacultyOfLaw);

            Student s2 = new Student("Pesho", "Ivanov", "Ivanov", 7839938273, "Imaginary Str 44", 39483439,
                "pesho@test.net", 3, Specialty.ComputerSystems, University.SofiaUniversity, Faculty.FMI);

            Console.WriteLine("s1 HashCode: " + s1.GetHashCode());
            Console.WriteLine("s2 HashCode: " + s2.GetHashCode());
            Console.WriteLine("s1 equals s2: " + s1.Equals(s2));
            Console.WriteLine("s1 == s2: " + (s1 == s2));
            Console.WriteLine("s1 != s2: " + (s1 != s2));
            Console.WriteLine();
            Console.WriteLine(s2.ToString());
            Console.WriteLine();

            Student s3 = (Student)s2.Clone();

            Console.WriteLine("s2 == s3: " + (s2 == s3));
            Console.WriteLine("s2 != s3: " + (s2 != s3));
            Console.WriteLine("s2.CompareTo(s3): " + s2.CompareTo(s3));
            Console.WriteLine("s1.CompareTo(s2): " + s1.CompareTo(s2));
        }
    }
}

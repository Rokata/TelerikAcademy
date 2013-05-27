using System;


namespace PersonDemo
{
    class PersonDemo
    {
        static void Main()
        {
            Person p = new Person("Ivan");
            Console.WriteLine(p.ToString());

            p.Age = 22;
            Console.WriteLine(p.ToString());   
        }
    }
}

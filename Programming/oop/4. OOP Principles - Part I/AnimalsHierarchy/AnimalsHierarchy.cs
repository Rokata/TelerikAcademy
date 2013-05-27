using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsHierarchy
{
    public enum Sex { Male, Female };

    class AnimalsHierarchy
    {
        public static double CalculateAvgAge(Animal[] animals)
        {
            return (float) animals.Average<Animal>(x => x.Age);
        }

        static void Main()
        {
            Tomcat[] tomcats = {
                                new Tomcat(7, "Jonny"),
                                new Tomcat(5, "Mr Meow"),
                                new Tomcat(2, "Mr Meow Junior")
                               };

            Console.WriteLine("Average tomcats age: {0}", Math.Round(CalculateAvgAge(tomcats), 2));

            Kitten[] kittens = {
                                new Kitten(5, "Kitten 1"),
                                new Kitten(2, "Kitten 2"),
                                new Kitten(6, "Kitten 3"),
                                new Kitten(8, "Kitten 4")
                               };

            Console.WriteLine("Average kittens age: {0}", Math.Round(CalculateAvgAge(kittens), 2));

            Dog[] dogs = {
                            new Dog(5, "Dog 1", Sex.Male),
                            new Dog(4, "Dog 2", Sex.Female),
                            new Dog(3, "Dog 3", Sex.Female),
                            new Dog(4, "Dog 4", Sex.Male)
                         };

            Console.WriteLine("Average dogs age: {0}", Math.Round(CalculateAvgAge(dogs), 2));
            dogs[0].ProduceSound();
            tomcats[0].ProduceSound();
        }
    }
}

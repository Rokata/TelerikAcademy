using System;

namespace AnimalsHierarchy
{
    public class Dog : Animal
    {
        public Dog(int age, string name, Sex sex) : base(age, name, sex) { }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof-woof!");
        }
    }
}

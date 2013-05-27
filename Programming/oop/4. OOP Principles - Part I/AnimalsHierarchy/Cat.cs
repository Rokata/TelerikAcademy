using System;

namespace AnimalsHierarchy
{
    public abstract class Cat : Animal
    {
        public Cat(int age, string name) : base(age, name)  { }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}

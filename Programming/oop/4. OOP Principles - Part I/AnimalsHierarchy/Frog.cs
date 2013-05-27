using System;

namespace AnimalsHierarchy
{
    public class Frog : Animal
    {
        public Frog(int age, string name, Sex sex) : base(age, name, sex) { }

        public override void ProduceSound()
        {
            Console.WriteLine("I am a frog!");
        }
    }
}

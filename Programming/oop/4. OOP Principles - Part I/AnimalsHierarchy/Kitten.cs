using System;

namespace AnimalsHierarchy
{
    public class Kitten : Cat
    {
        public Kitten(int age, string name) : base(age, name) 
        {
            base.Sex = Sex.Female;
        }
    }
}

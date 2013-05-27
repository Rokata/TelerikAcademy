using System;

namespace AnimalsHierarchy
{
    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private Sex sex;

        public Animal(int age, string name, Sex sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }

        public Animal(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Sex Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public abstract void ProduceSound();
    }
}

using System;
using System.Text;

namespace PersonDemo
{
    public class Person
    {
        private string name;
        private int? age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(string name, int? age = null)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(name);

            if (age != null)
            {
                builder.Append(", ");
                builder.Append(age);
                builder.Append(" years old");
            }

            return builder.ToString();
        }
    }
}

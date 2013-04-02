using System;

namespace School
{
    public abstract class Person : ICommentable
    {
        private string name;
        public string FreeTextBlock { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string name)
        {
            this.name = name;
        }
    }
}

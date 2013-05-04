using System;

namespace SchoolHierarchy
{
    public class Student
    {
        private string name;
        private int uniqueID;
        public static int NextID = 10000;

        public Student(string name)
        {
            this.Name = name;
            this.UniqueID = NextID++;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Student name cannot be null!");

                this.name = value;
            }
        }

        public int UniqueID
        {
            get { return this.uniqueID; }
            set
            {
                if (value < 10000 || value > 99999)
                    throw new ArgumentException("ID must be between 10000 and 99999!");

                this.uniqueID = value;
            }
        }
    }
}

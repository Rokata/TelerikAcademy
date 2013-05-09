using System;

namespace SchoolHierarchy
{
    public class Student
    {
        private string name;
        private int uniqueID;
        private static int nextID = 10000;

        public Student(string name)
        {
            if (nextID > 99999)
                throw new ArgumentException("All available IDs were already used.");

            this.Name = name;
            this.uniqueID = nextID++;
        }

        public static int NextID
        {
            get { return nextID; }
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
        }
    }
}

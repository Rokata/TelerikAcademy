using System;

namespace School
{
    public class Student : Person
    {
        private int classNumber;

        public Student(string name, int classNumber) : base(name)
        {
            this.classNumber = classNumber;
        }

        public int ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName = null, 
            IList<string> students = null, string lab  = null) : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }
            set { this.lab = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}

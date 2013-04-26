using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName = null, 
            IList<string> students = null, string town  = null) : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town 
        {
            get { return this.town; }
            set { this.town = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}

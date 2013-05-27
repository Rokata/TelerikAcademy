using System;
using System.Collections.Generic;

namespace School
{
    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher(string name, List<Discipline> disciplines) : base(name)
        {
            this.disciplines = disciplines;
        }
    }
}

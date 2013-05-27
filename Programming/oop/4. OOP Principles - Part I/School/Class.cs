using System;
using System.Collections.Generic;

namespace School
{
    public class Class : ICommentable
    {
        private string id;
        private List<Teacher> teachers;
        private List<Student> students;
        public string FreeTextBlock { get; set; }

        public Class(string id, List<Teacher> teachers, List<Student> students)
        {
            this.id = id;
            this.teachers = teachers;
            this.students = students;
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public List<Teacher> Teachers
        {
            get { return teachers; }
        }

        public List<Student> Students
        {
            get { return students; }
        }
    }
}

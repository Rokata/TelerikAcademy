using System;
using System.Collections.Generic;

namespace SchoolHierarchy
{
    public class Course
    {
        public const int MaxStudentCount = 29;
        private List<Student> students;
        private string name;

        public Course(string name)
        {
            this.students = new List<Student>(MaxStudentCount);
            this.Name = name;
        }

        public List<Student> Students
        {
            get { return this.students; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Course name must not be empty!");

                this.name = value;
            }
        }

        public bool HasStudent(string name)
        {
            foreach (var student in this.students)
            {
                if (student.Name == name) return true;
            }

            return false;
        }

        public void AddNewStudent(Student student)
        {
            if (student == null)
                throw new ArgumentException("Value should not be null!");

            if (this.students.Count == MaxStudentCount || this.HasStudent(student.Name))
                throw new InvalidOperationException("Max students count reached or student already enrolled!");

            this.students.Add(student);
        }

        public void RemoveStudent(int id)
        {
            for (int i = 0; i < this.students.Count; i++)
            {
                if (students[i].UniqueID == id)
                {
                    this.students.RemoveAt(i);
                    return;
                }
            }

            throw new KeyNotFoundException("A student with the specified id doesn't exist!");
        }
    }
}

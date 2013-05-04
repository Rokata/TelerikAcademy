using System;
using System.Collections.Generic;

namespace SchoolHierarchy
{
    public class School
    {
        private List<Course> courses;

        public School()
        {
            this.courses = new List<Course>();
        }

        public void AddCourse(Course newCourse)
        {
            if (newCourse == null)
                throw new ArgumentException("Course cannot be null!");

            foreach (Course course in courses)
            {
                if (course.Name == newCourse.Name)
                    throw new InvalidOperationException("This course is already registered in the school!");
            }

            this.courses.Add(newCourse);
        }

        public void RemoveCourse(string courseName)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name == courseName)
                {
                    this.courses.RemoveAt(i);
                    return;
                }
            }

            throw new KeyNotFoundException("A course with the specified name doesn't exist!");
        }
    }
}

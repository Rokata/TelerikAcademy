using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolHierarchy;
using System.Collections.Generic;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Course already exists")]
        public void AddCourse_ThrowsExceptionWhenCourseAlreadyExists() 
        {
            School school = new School();

            school.AddCourse(new Course(".NET"));
            school.AddCourse(new Course("PHP"));
            school.AddCourse(new Course("Java"));

            school.AddCourse(new Course(".NET"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Course to remove not found")]
        public void RemoveCourse_ThrowsExceptionWhenCourseNotFound()
        {
            School school = new School();

            school.AddCourse(new Course(".NET"));
            school.AddCourse(new Course("PHP"));
            school.AddCourse(new Course("Java"));

            school.RemoveCourse("HTML5, CSS3, JavaScript");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Course to remove not found")]
        public void RemoveCourse_ThrowsExceptionWhenParameterNull()
        {
            School school = new School();

            school.AddCourse(new Course(".NET"));
            school.AddCourse(new Course("PHP"));
            school.AddCourse(new Course("Java"));

            school.RemoveCourse(null);
        }
    }
}

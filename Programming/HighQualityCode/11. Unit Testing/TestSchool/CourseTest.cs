using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolHierarchy;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestSchool
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Course name cannot be null")]
        public void Name_ThrowsExceptionWhenNull()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Student with this ID doesn't exist")]
        public void RemoveStudent_ThrowsExceptionOnNotFound()
        {
            Course course = new Course(".NET");
            course.RemoveStudent(23);
        }

        [TestMethod]
        public void StudentID_HasCorrectValue()
        {
            Course course = new Course(".NET");

            for (int i = 0; i < 5; i++)
            {
                course.AddNewStudent(new Student("Student" + i));
            }

            int lastStudentID = course.Students[4].UniqueID;

            Assert.AreEqual(Student.NextID - 1, lastStudentID);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Max students count in course reached")]
        public void AddStudent_ThrowsExceptionWhenMaxReached()
        {
            Course course = new Course(".NET");

            for (int i = 0; i < Course.MaxStudentCount + 1; i++)
            {
                course.AddNewStudent(new Student("Student" + i));
            }
        }

        [TestMethod]
        public void AddStudent_ExecutesCorrectlyWith10Students()
        {
            Course course = new Course(".NET");

            for (int i = 0; i < 10; i++)
            {
                course.AddNewStudent(new Student("Student" + i));
            }
        }

        [TestMethod]
        public void RemoveStudent_ExecutesCorrectlyOnRemove()
        {
            Course course = new Course(".NET");

            for (int i = 0; i < 10; i++)
            {
                course.AddNewStudent(new Student("Student" + i));
            }

            course.RemoveStudent(Student.NextID - 5);
        }

        [TestMethod]
        public void HasStudent_Test()
        {
            Course course = new Course(".NET");

            course.AddNewStudent(new Student("Pesho"));
            course.AddNewStudent(new Student("Ivan"));
            course.AddNewStudent(new Student("Garo"));

            bool isFound = course.HasStudent(Student.NextID - 2);
            bool notFound = !course.HasStudent(Student.NextID - 4);

            Assert.AreEqual(true, isFound);
            Assert.AreEqual(true, notFound);
        }
    }
}

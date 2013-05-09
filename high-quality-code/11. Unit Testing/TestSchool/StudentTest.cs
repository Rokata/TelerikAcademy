using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolHierarchy;
using System.Collections.Generic;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Student name empty")]
        public void StudentName_ThrowsExceptionWhenEmpty()
        {
            Student stud = new Student("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Student name null")]
        public void StudentName_ThrowsExceptionWhenNull()
        {
            Student stud = new Student(null);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CourseSystem.Tests
{
    [TestClass()]
    public class ClassTests
    {
        Class courseInfoCSIE;
        Class courseInfoEE;

        const string CLASS_CSIE = "CSIE";
        const string CLASS_EE = "EE";
        const int CSIE_LENGTH = 12;
        const int EE_LENGTH = 25;
        const int SIXTH_COURSE = 5;
        const string SIXTH_COURSE_NUMBER = "291706";
        const string NULL_STRING = "";

        // initialize data
        [TestInitialize()]
        public void Initialize()
        {
            courseInfoCSIE = new Class(CLASS_CSIE);
            courseInfoEE = new Class(CLASS_EE);
        }

        // test generate course info both classes
        [TestMethod()]
        public void TestGenerateCourseInfo()
        {
            BindingList<CourseInfoDto> courseInfo = courseInfoCSIE.GenerateCourseInfo(CLASS_CSIE);
            Assert.AreEqual(CSIE_LENGTH, courseInfo.Count);
            courseInfo = courseInfoEE.GenerateCourseInfo(CLASS_EE);
            Assert.AreEqual(EE_LENGTH, courseInfo.Count);
        }

        // test copy by value, change one wont change another
        [TestMethod()]
        public void TestCopyClassByValue()
        {
            Class courseInfo = courseInfoCSIE;
            courseInfoCSIE.CourseInfo.RemoveAt(0);
            Assert.AreEqual(CSIE_LENGTH - 1, courseInfo.CourseInfo.Count);
            courseInfo = courseInfoCSIE.CopyClassByValue();
            courseInfoCSIE.CourseInfo.RemoveAt(0);
            Assert.AreEqual(CSIE_LENGTH - 1, courseInfo.CourseInfo.Count);
        }

        // test return binding list
        [TestMethod()]
        public void TestGetBindingList()
        {
            Assert.AreEqual(courseInfoCSIE.CourseInfo, courseInfoCSIE.GetBindingList());
        }

        // test return a normal list
        [TestMethod()]
        public void TestGetList()
        {
            Assert.IsInstanceOfType(courseInfoCSIE.GetList(), typeof(List<CourseInfoDto>));
            Assert.AreEqual(courseInfoCSIE.CourseInfo.Count, courseInfoCSIE.GetList().Count);
        }

        // test return course with given index
        [TestMethod()]
        public void TestGetCourse()
        {
            Assert.AreEqual(SIXTH_COURSE_NUMBER, courseInfoCSIE.GetCourse(SIXTH_COURSE).Number);
        }

        // test adding course
        [TestMethod()]
        public void TestAddCourse()
        {
            CourseInfoDto course = new CourseInfoDto(NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING);
            courseInfoCSIE.AddCourse(course);
            Assert.AreEqual(CSIE_LENGTH + 1, courseInfoCSIE.GetBindingList().Count);
            Assert.AreEqual(NULL_STRING, courseInfoCSIE.CourseInfo[courseInfoCSIE.CourseInfo.Count - 1].Number);
            Assert.AreEqual(NULL_STRING, courseInfoCSIE.CourseInfo[courseInfoCSIE.CourseInfo.Count - 1].ClassChineseName);
        }

        // test delete course
        [TestMethod()]
        public void DeleteCourseTest()
        {
            Assert.AreEqual(SIXTH_COURSE_NUMBER, courseInfoCSIE.CourseInfo[SIXTH_COURSE].Number);
            courseInfoCSIE.DeleteCourse(SIXTH_COURSE);
            Assert.AreNotEqual(SIXTH_COURSE_NUMBER, courseInfoCSIE.CourseInfo[SIXTH_COURSE].Number);
        }
    }
}
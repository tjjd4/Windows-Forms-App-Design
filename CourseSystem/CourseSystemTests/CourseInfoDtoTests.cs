using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem.Tests
{
    [TestClass()]
    public class CourseInfoDtoTests
    {
        CourseInfoDto emptyCourse;
        CourseInfoDto courseCSIE1;
        CourseInfoDto courseCSIE2;
        CourseInfoDto courseEE1;

        const string NULL_STRING = "";
        const int DATA_AMOUNT = 24;
        const string CLASS_CSIE = "CSIE";
        const string CLASS_EE = "EE";
        const string COURSE_NUMBER_1 = "111111";
        const string COURSE_NAME_1 = "1";
        const string COURSE_NUMBER_2 = "222222";
        const string COURSE_NAME_2 = "2";
        const string CLASS_TIME_1 = "1 D";
        const string CLASS_TIME_2 = "N C";

        // initialize data
        [TestInitialize()]
        public void Initialize()
        {
            emptyCourse = new CourseInfoDto(NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING);
            courseCSIE1 = new CourseInfoDto(COURSE_NUMBER_1, COURSE_NAME_1, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, CLASS_TIME_1, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, CLASS_CSIE);
            courseCSIE2 = new CourseInfoDto(COURSE_NUMBER_2, COURSE_NAME_2, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, CLASS_TIME_2, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, CLASS_CSIE);
            courseEE1 = new CourseInfoDto(COURSE_NUMBER_1, COURSE_NAME_1, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, CLASS_TIME_1, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, CLASS_EE);
        }

        // test change data to string[]
        [TestMethod()]
        public void TestGetInRow()
        {
            int count = 0;
            foreach (string data in emptyCourse.GetInRow())
            {
                Assert.AreEqual(NULL_STRING, data);
                count++;
            }
            Assert.AreEqual(DATA_AMOUNT, count);
        }

        // test check same course
        [TestMethod()]
        public void TestCheckSameCourse()
        {
            Assert.IsTrue(CourseInfoDto.CheckSameCourse(courseCSIE1, courseCSIE1));
            Assert.IsFalse(CourseInfoDto.CheckSameCourse(courseCSIE1, courseCSIE2));
        }

        // test check course number
        [TestMethod()]
        public void TestCheckCourseNumber()
        {
            Assert.IsTrue(CourseInfoDto.CheckCourseNumber(courseCSIE1, courseEE1));
            Assert.IsFalse(CourseInfoDto.CheckCourseNumber(courseCSIE1, courseCSIE2));
        }

        // test check course number in another input
        [TestMethod()]
        public void TestCheckCourseNumber1()
        {
            Assert.IsTrue(CourseInfoDto.CheckCourseNumber(COURSE_NUMBER_1, courseCSIE1));
            Assert.IsFalse(CourseInfoDto.CheckCourseNumber(COURSE_NUMBER_2, courseCSIE1));
        }

        // test check course name
        [TestMethod()]
        public void TestCheckCourseName()
        {
            Assert.IsTrue(CourseInfoDto.CheckCourseName(courseCSIE1, courseEE1));
            Assert.IsFalse(CourseInfoDto.CheckCourseName(courseCSIE1, courseCSIE2));
        }

        // test check course class time
        [TestMethod()]
        public void TestCheckCourseClassTime()
        {
            Assert.IsTrue(CourseInfoDto.CheckCourseClassTime(courseCSIE1, courseEE1));
            Assert.IsFalse(CourseInfoDto.CheckCourseClassTime(courseCSIE1, courseCSIE2));
        }

        // test check class name
        [TestMethod()]
        public void TestCheckClassName()
        {
            Assert.IsFalse(CourseInfoDto.CheckClassChineseName(courseCSIE1, courseEE1));
            Assert.IsTrue(CourseInfoDto.CheckClassChineseName(courseCSIE1, courseCSIE2));
        }
    }
}
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
    public class WebCrawlerTests
    {
        // test fetch course info
        [TestMethod()]
        public void TestGetCourseInfo()
        {
            BindingList<CourseInfoDto> courseInfo = WebCrawler.GetCourseInfo("CSIE");
            Assert.AreEqual(12, courseInfo.Count);
            courseInfo = WebCrawler.GetCourseInfo("EE");
            Assert.AreEqual(25, courseInfo.Count);
        }
    }
}
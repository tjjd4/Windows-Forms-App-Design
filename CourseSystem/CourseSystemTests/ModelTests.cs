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
    public class ModelTests
    {
        Model model;

        const int FIVE = 5;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
        }

        // test generate all course
        [TestMethod()]
        public void TestGenerateAllCourses()
        {
            model.GenerateAllCourses();
            Assert.IsNotNull(model.CourseInfos);
        }

        // test add courses
        [TestMethod()]
        public void TestAddCourses()
        {
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(3);
            integer.Add(4);
            index.Add(integer);
            List<string> message = model.AddCourses(index);
            Assert.AreEqual("", message[0]);
            Assert.AreEqual("", message[1]);
            Assert.AreEqual("", message[2]);
        }

        // test delete course with index
        [TestMethod()]
        public void TestDeleteSelectedCourse()
        {
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(3);
            integer.Add(4);
            index.Add(integer);
            List<string> message = model.AddCourses(index);
            foreach (string singleMessage in message)
            {
                if (singleMessage != "")
                    Assert.Fail();
            }
            model.DeleteSelectedCourse(1);
            Assert.AreEqual(1, model.SelectedCourseInfo.CourseInfo.Count);
            model.DeleteSelectedCourse(0);
            Assert.AreEqual(0, model.SelectedCourseInfo.CourseInfo.Count);
        }

        // test check is there a duplicate course number
        [TestMethod()]
        public void TestCheckChangedCourseNumber()
        {
            Assert.IsTrue(model.CheckChangedCourseNumber("290783"));
            Assert.IsFalse(model.CheckChangedCourseNumber("290784"));
        }

        // test modify course and save it
        [TestMethod()]
        public void TestModifyCourse()
        {
            CourseInfoDto course = new CourseInfoDto("", "計算機網路修改版", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "資工三");
            CourseInfoDto originCourse = model.CourseInfos[0].GetBindingList()[5];
            model.ModifyCourse(course, originCourse);
            Assert.AreEqual("計算機網路修改版", model.CourseInfos[0].GetBindingList()[5].Name);
            course = new CourseInfoDto("", "資料庫系統修改版", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "電子三甲");
            originCourse = model.CourseInfos[0].GetBindingList()[4];
            model.ModifyCourse(course, originCourse);
            Assert.AreEqual("計算機網路修改版", model.CourseInfos[0].GetBindingList()[4].Name);
            Assert.AreEqual("資料庫系統修改版", model.CourseInfos[1].GetBindingList()[model.CourseInfos[1].GetBindingList().Count - 1].Name);
        }

        // test add new course
        [TestMethod()]
        public void TestAddNewCourse()
        {
            CourseInfoDto course = new CourseInfoDto("", "新課程", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "電子三甲");
            model.AddNewCourse(course);
            Assert.AreEqual("新課程", model.CourseInfos[1].GetBindingList()[model.CourseInfos[1].GetBindingList().Count - 1].Name);
        }

        // test setting dictionary
        [TestMethod()]
        public void TestSetDictionary()
        {
            Assert.AreEqual(model.ClassNameToClassIndex["CSIE"], 0);
            Assert.AreEqual(model.ClassNameToClassIndex["EE"], 1);
        }

        // test create message by comparing the course
        [TestMethod()]
        public void TestCreateMessage()
        {
            CourseInfoDto course1 = new CourseInfoDto("123456", "test1", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            CourseInfoDto course2 = new CourseInfoDto("654321", "test2", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            string message = model.CreateMessage(course1, course2);
            Assert.AreEqual("「123456test1」 「654321test2」 \n", message);
        }

        // test save course and determine from message
        [TestMethod()]
        public void TestSaveCourse()
        {
            List<string> message = new List<string>();
            for (int _ = 0; _ < 3; _++)
            {
                message.Add("");
            }
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(3);
            integer.Add(4);
            index.Add(integer);
            model.SaveCourse(message, index);
            Assert.AreEqual(2, model.SelectedCourseInfo.CourseInfo.Count);
            message[0] = "123";
            model.SaveCourse(message, index);
            Assert.AreEqual(2, model.SelectedCourseInfo.CourseInfo.Count);
        }

        // construct selectingCourseInfos from subtract courses in courseInfos
        [TestMethod()]
        public void TestConstructSelectingTable()
        {
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(3);
            integer.Add(4);
            index.Add(integer);
            model.AddCourses(index);
            model.ConstructSelectingTable();
            Assert.AreEqual(model.CourseInfos[0].GetBindingList().Count - 2, model.SelectingCourseInfos[0].GetBindingList().Count);
        }

        // test copy the course fromm courseInfos to selectingCourseInfos
        [TestMethod()]
        public void TestCopyCourseInfos()
        {
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(3);
            integer.Add(4);
            index.Add(integer);
            model.AddCourses(index);
            model.CopyCourseInfos();
            Assert.AreEqual(model.CourseInfos[0].GetBindingList().Count, model.SelectingCourseInfos[0].GetBindingList().Count);
        }

        // test modify the course
        [TestMethod()]
        public void TestModifySelectedCourse()
        {
            CourseInfoDto course = new CourseInfoDto("", "計算機網路修改版", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "CSIE");
            CourseInfoDto originCourse = model.CourseInfos[0].GetBindingList()[FIVE];
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(FIVE);
            index.Add(integer);
            model.AddCourses(index);
            model.ModifySelectedCourse(course, originCourse);
            Assert.AreEqual("計算機網路修改版", model.SelectedCourseInfo.GetBindingList()[0].Name);
            Assert.AreEqual("計算機網路", model.CourseInfos[0].GetBindingList()[FIVE].Name);
        }

        // test download a class and add to courseInfos
        [TestMethod()]
        public void TestDownloadSingleClass()
        {
            int originLength = model.CourseInfos.Count;
            model.DownloadSingleClass("");
            Assert.AreEqual(originLength, model.CourseInfos.Count);
            model.DownloadSingleClass("CSIE1");
            Assert.AreEqual(originLength + 1, model.CourseInfos.Count);
        }

        // test delete a course
        [TestMethod()]
        public void TestDeleteCourse()
        {
            CourseInfoDto course = model.CourseInfos[0].CourseInfo[5];
            Assert.AreEqual("計算機網路", model.CourseInfos[0].CourseInfo[5].Name);
            model.DeleteCourse(course);
            Assert.AreNotEqual("計算機網路", model.CourseInfos[0].CourseInfo[5].Name);
        }

        // test delete a course in selected course
        [TestMethod()]
        public void TestDeleteCourseInSelected()
        {
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(5);
            index.Add(integer);
            model.AddCourses(index);
            CourseInfoDto course = model.CourseInfos[0].CourseInfo[5];
            Assert.AreEqual("計算機網路", model.SelectedCourseInfo.CourseInfo[0].Name);
            model.DeleteCourseInSelected(course);
            Assert.AreEqual(0, model.SelectedCourseInfo.CourseInfo.Count);
        }

        // test check is there a same class chinese name exist
        [TestMethod()]
        public void TestIsClassChineseNameExist()
        {
            Assert.IsTrue(model.IsClassChineseNameExist("資工三"));
            Assert.IsFalse(model.IsClassChineseNameExist("資工"));
        }

        // test get class by index
        [TestMethod()]
        public void TestGetClassByIndex()
        {
            Assert.AreEqual("資工三", model.GetClassByIndex(0).ClassChineseName);
            Assert.AreEqual(12, model.GetClassByIndex(0).GetBindingList().Count);
            Assert.AreEqual("電子三甲", model.GetClassByIndex(1).ClassChineseName);
        }
    }
}
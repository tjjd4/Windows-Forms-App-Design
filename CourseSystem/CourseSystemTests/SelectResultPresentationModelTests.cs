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
    public class SelectResultPresentationModelTests
    {
        Model model;
        SelectResultPresentationModel selectResultPresentationModel;

        // initialize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            selectResultPresentationModel = new SelectResultPresentationModel(model);
        }

        // test get selected courseInfo
        [TestMethod()]
        public void TestGetResultCourseInfo()
        {
            Assert.AreEqual(model.SelectedCourseInfo, selectResultPresentationModel.GetResultCourseInfo());
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(3);
            integer.Add(4);
            index.Add(integer);
            model.AddCourses(index);
            Assert.AreEqual(model.SelectedCourseInfo, selectResultPresentationModel.GetResultCourseInfo());
        }

        // test delete selected course
        [TestMethod()]
        public void TestDeleteSelectedCourse()
        {
            Assert.AreEqual(model.SelectedCourseInfo, selectResultPresentationModel.GetResultCourseInfo());
            List<List<int>> index = new List<List<int>>();
            List<int> integer = new List<int>();
            integer.Add(4);
            integer.Add(5);
            index.Add(integer);
            model.AddCourses(index);
            Assert.AreEqual(model.SelectedCourseInfo, selectResultPresentationModel.GetResultCourseInfo());
            selectResultPresentationModel.DeleteSelectedCourse(0);
            Assert.AreEqual(1, selectResultPresentationModel.GetResultCourseInfo().GetBindingList().Count);
            Assert.AreEqual("計算機網路", selectResultPresentationModel.GetResultCourseInfo().GetBindingList()[0].Name);
        }
    }
}
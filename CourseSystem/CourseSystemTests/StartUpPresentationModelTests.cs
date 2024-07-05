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
    public class StartUpPresentationModelTests
    {
        Model model;
        StartUpPresentationModel startUpPresentationModel;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            startUpPresentationModel = new StartUpPresentationModel(model);
        }

        // test
        [TestMethod()]
        public void TestIsSelectEnable()
        {
            Assert.IsTrue(startUpPresentationModel.IsSelectEnable());
        }

        // test
        [TestMethod()]
        public void TestIsManagementEnable()
        {
            Assert.IsTrue(startUpPresentationModel.IsManagementEnable());
        }
    }
}
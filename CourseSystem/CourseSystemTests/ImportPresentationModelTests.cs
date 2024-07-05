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
    public class ImportPresentationModelTests
    {
        Model model;
        ImportPresentationModel importPresentationModel;

        const string REPORT = "資料已經下載完成";

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            importPresentationModel = new ImportPresentationModel(model);
        }

        // test download classes
        [TestMethod()]
        public void TestDownloadClasses()
        {
            Assert.AreEqual(2, model.CourseInfos.Count);
            importPresentationModel.DownloadClasses();
            Assert.AreNotEqual(REPORT, importPresentationModel.Progress);
            Assert.AreEqual(5, model.CourseInfos.Count);
            importPresentationModel.DownloadClasses();
            Assert.AreEqual(REPORT, importPresentationModel.Progress);
            Assert.AreEqual(5, model.CourseInfos.Count);
        }
    }
}
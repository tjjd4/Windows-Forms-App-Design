using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm.Tests
{
    [TestClass]
    public class UITests
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_VIEW = "Form1";

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "DrawingForm";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\DrawingFormAndApp"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "DrawingForm.exe");
            _robot = new Robot(targetAppPath, START_UP_VIEW);
        }

        // clean up
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // test click select
        [TestMethod()]
        public void TestSetRectangle()
        {
            _robot.ClickButton("Rectangle");
        }

        // test click select
        [TestMethod()]
        public void TestSetEllipse()
        {
            _robot.ClickButton("Ellipse");
        }

        // test click select
        [TestMethod()]
        public void TestClear()
        {
            _robot.ClickButton("Clear");
        }
    }
}

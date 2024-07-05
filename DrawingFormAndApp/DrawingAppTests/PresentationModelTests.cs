using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingApp.Tests
{
    [TestClass]
    public class presentationModelTests
    {
        DrawingModel.Model model;
        DrawingApp.PresentationModel presentationModel;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new DrawingModel.Model();
            presentationModel = new DrawingApp.PresentationModel(model);
        }

        // test clear
        [TestMethod()]
        public void TestClear()
        {
            presentationModel.Clear();
            Assert.IsFalse(presentationModel.IsRectangleMode);
            Assert.IsFalse(presentationModel.IsEllipseMode);
            Assert.IsFalse(presentationModel.IsLineMode);
        }

        // test set rectangle mode
        [TestMethod()]
        public void TestSetRectangleMode()
        {
            presentationModel.SetRectangleMode();
            Assert.IsTrue(presentationModel.IsRectangleMode);
            Assert.IsFalse(presentationModel.IsEllipseMode);
            Assert.IsFalse(presentationModel.IsLineMode);
        }

        // test set ellipse mode
        [TestMethod()]
        public void TestSetEllipseMode()
        {
            presentationModel.SetEllipseMode();
            Assert.IsFalse(presentationModel.IsRectangleMode);
            Assert.IsTrue(presentationModel.IsEllipseMode);
            Assert.IsFalse(presentationModel.IsLineMode);
        }

        // test set line mode
        [TestMethod()]
        public void TestSetLineMode()
        {
            presentationModel.SetLineMode();
            Assert.IsFalse(presentationModel.IsRectangleMode);
            Assert.IsFalse(presentationModel.IsEllipseMode);
            Assert.IsTrue(presentationModel.IsLineMode);
        }

        // test set line mode
        [TestMethod()]
        public void TestSetInfo()
        {
            DrawingModel.Rectangle shape = new DrawingModel.Rectangle();
            shape.Type = "Rectangle";
            shape.X1 = 10;
            shape.X2 = 20;
            shape.Y1 = 100;
            shape.Y2 = 200;
            model.Select = shape;
            presentationModel.SetInfo();
            Assert.AreEqual("Rectangle(10,100,20,200)", presentationModel.Info);
        }
    }
}

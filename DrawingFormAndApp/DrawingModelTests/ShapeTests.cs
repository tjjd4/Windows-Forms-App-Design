using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        Shape shape;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            shape = new Shape();
        }

        // test transfer data
        [TestMethod()]
        public void TestTransferData()
        {
            shape.X1 = 10;
            shape.Y1 = 20;
            shape.X2 = 100;
            shape.Y2 = 200;
            shape.TransferData();
            Assert.AreEqual(10, shape.Left);
            Assert.AreEqual(20, shape.Top);
            Assert.AreEqual(90, shape.Width);
            Assert.AreEqual(180, shape.Height);
            shape.X1 = 100;
            shape.Y1 = 200;
            shape.X2 = 10;
            shape.Y2 = 20;
            shape.TransferData();
            Assert.AreEqual(10, shape.Left);
            Assert.AreEqual(20, shape.Top);
            Assert.AreEqual(90, shape.Width);
            Assert.AreEqual(180, shape.Height);
        }

        // test correct data
        [TestMethod()]
        public void TestCorrectData()
        {
            shape.X1 = 10;
            shape.Y1 = 20;
            shape.X2 = 100;
            shape.Y2 = 200;
            shape.CorrectData();
            Assert.AreEqual(10, shape.X1);
            Assert.AreEqual(20, shape.Y1);
            Assert.AreEqual(100, shape.X2);
            Assert.AreEqual(200, shape.Y2);
            shape.X1 = 100;
            shape.Y1 = 200;
            shape.X2 = 10;
            shape.Y2 = 20;
            shape.CorrectData();
            Assert.AreEqual(10, shape.X1);
            Assert.AreEqual(20, shape.Y1);
            Assert.AreEqual(100, shape.X2);
            Assert.AreEqual(200, shape.Y2);
        }
    }
}
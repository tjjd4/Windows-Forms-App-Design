using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class LineTests
    {
        Shape shape1;
        Shape shape2;
        Line line;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            shape1 = new Rectangle();
            shape2 = new Ellipse();
            line = new Line();
            shape1.X1 = 10;
            shape1.Y1 = 20;
            shape1.X2 = 100;
            shape1.Y2 = 200;
            shape2.X1 = 200;
            shape2.Y1 = 100;
            shape2.X2 = 300;
            shape2.Y2 = 200;
        }

        // test calculate center test
        [TestMethod()]
        public void TestCalculateCenter()
        {
            line.Shape1 = shape1;
            line.Shape2 = shape2;
            line.CalculateCenter();
            Assert.AreEqual(55, line.X1);
            Assert.AreEqual(250, line.X2);
            Assert.AreEqual(110, line.Y1);
            Assert.AreEqual(150, line.Y2);
        }

        // test set shape
        [TestMethod()]
        public void TestSetShape()
        {
            line.SetShape(shape1, 1);
            line.SetShape(shape2, 2);
            Assert.AreEqual(shape1, line.Shape1);
            Assert.AreEqual(shape2, line.Shape2);
        }
    }
}
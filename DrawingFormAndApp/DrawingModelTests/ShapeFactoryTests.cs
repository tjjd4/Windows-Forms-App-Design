using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        ShapeFactory shapeFactory;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            shapeFactory = new ShapeFactory();
        }

        // test create shape
        [TestMethod()]
        public void TestCreateShape()
        {
            Shape shape = shapeFactory.CreateShape("Rectangle");
            Assert.IsInstanceOfType(shape, typeof(Rectangle));
            shape = shapeFactory.CreateShape("Ellipse");
            Assert.IsInstanceOfType(shape, typeof(Ellipse));
            shape = shapeFactory.CreateShape("Line");
            Assert.IsInstanceOfType(shape, typeof(Line));
            shape = shapeFactory.CreateShape("");
            Assert.AreEqual(null, shape);
        }
    }
}
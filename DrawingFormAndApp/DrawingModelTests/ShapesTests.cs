using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes shapes;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            shapes = new Shapes();
        }

        // test add shape into list
        [TestMethod()]
        public void TestAddShape()
        {
            Shape shape = new Shape();
            shapes.AddShape(shape);
            Assert.AreEqual(1, shapes.ShapesList.Count);
            shapes.AddShape(shape);
            Assert.AreEqual(2, shapes.ShapesList.Count);
        }

        // test clear shapes list
        [TestMethod()]
        public void TestClear()
        {
            Shape shape = new Shape();
            shapes.AddShape(shape);
            shapes.AddShape(shape);
            shapes.Clear();
            Assert.AreEqual(0, shapes.ShapesList.Count);
        }

        // test delete shape
        [TestMethod()]
        public void TestDeleteShape()
        {
            Shape shape = new Shape();
            shapes.AddShape(shape);
            Assert.AreEqual(1, shapes.ShapesList.Count);
            shapes.AddShape(shape);
            Assert.AreEqual(2, shapes.ShapesList.Count);
            shapes.DeleteShape();
            Assert.AreEqual(1, shapes.ShapesList.Count);
            shapes.DeleteShape();
            Assert.AreEqual(0, shapes.ShapesList.Count);
        }

        // test located in shape
        [TestMethod()]
        public void TestLocatedInShape()
        {
            Shape shape = new Shape();
            shape.X1 = 10;
            shape.Y1 = 20;
            shape.X2 = 100;
            shape.Y2 = 200;
            shapes.AddShape(shape);
            Assert.IsNotNull(shapes.LocateInShape(15, 25));
            Assert.IsNull(shapes.LocateInShape(15, 300));
        }
    }
}
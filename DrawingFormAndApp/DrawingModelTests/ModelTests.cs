using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
        }

        // test clear
        [TestMethod()]
        public void TestClear()
        {
            model.State = new DrawingState(model);
            model.Status = "Rectangle";
            model.PressPointer(10, 20);
            model.MovePointer(100, 200);
            model.ReleasePointer(100, 200);
            model.Clear();
            Assert.AreEqual(0, model.Shapes.ShapesList.Count);
        }

        // test delete
        [TestMethod()]
        public void TestDeleteShape()
        {
            model.State = new DrawingState(model);
            model.Status = "Rectangle";
            model.PressPointer(10, 20);
            model.MovePointer(100, 200);
            model.ReleasePointer(100, 200);
            model.DeleteShape();
            Assert.AreEqual(0, model.Shapes.ShapesList.Count);
        }

        // test set rectangle
        [TestMethod()]
        public void TestSetRectangle()
        {
            model.SetRectangle();
            Assert.IsInstanceOfType(model.State, typeof(DrawingState));
            Assert.AreEqual("Rectangle", model.Status);
        }

        // test set ellipse
        [TestMethod()]
        public void TestSetEllipse()
        {
            model.SetEllipse();
            Assert.IsInstanceOfType(model.State, typeof(DrawingState));
            Assert.AreEqual("Ellipse", model.Status);
        }

        // test set rectangle
        [TestMethod()]
        public void TestSetLine()
        {
            model.SetLine();
            Assert.IsInstanceOfType(model.State, typeof(DrawingLineState));
            Assert.AreEqual("Line", model.Status);
        }

        // test press in drawing state
        [TestMethod()]
        public void TestDrawingPress()
        {
            model.DrawingPress(10, 20);
            Assert.IsFalse(model.IsPress);
            model.Status = "Rectangle";
            model.DrawingPress(0, 0);
            Assert.IsFalse(model.IsPress);
            model.DrawingPress(10, 20);
            Assert.IsInstanceOfType(model.Hint, typeof(Rectangle));
            Assert.IsTrue(model.IsPress);
        }

        // test move in drawing state
        [TestMethod()]
        public void TestDrawingMove()
        {
            model.Status = "Rectangle";
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            Assert.AreEqual(100, model.Hint.X2);
            Assert.AreEqual(200, model.Hint.Y2);
            Assert.IsTrue(model.IsMoved);
        }

        // test release in drawing state
        [TestMethod()]
        public void TestDrawingRelease()
        {
            model.Status = "Rectangle";
            model.State = new DrawingState(model);
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            model.DrawingRelease(100, 200);
            Assert.AreEqual(100, model.Hint.X2);
            Assert.AreEqual(200, model.Hint.Y2);
            Assert.AreEqual(1, model.Shapes.ShapesList.Count);
            Assert.IsInstanceOfType(model.State, typeof(PointerState));
            Assert.IsFalse(model.IsPress);
            Assert.IsFalse(model.IsMoved);
        }

        // test press in drawing line state
        [TestMethod()]
        public void TestDrawingLinePress()
        {
            model.Status = "Rectangle";
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            model.DrawingRelease(100, 200);
            model.Status = "Line";
            model.DrawingLinePress(5, 25);
            Assert.IsFalse(model.IsPress);
            Assert.IsInstanceOfType(model.Hint, typeof(Rectangle));
            model.DrawingLinePress(15, 25);
            Assert.IsInstanceOfType(model.Hint, typeof(Line));
            Assert.IsTrue(model.IsPress);
        }

        // test move in drawing line state
        [TestMethod()]
        public void TestDrawingLineMove()
        {
            model.Status = "Rectangle";
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            model.DrawingRelease(100, 200);
            model.Status = "Line";
            model.DrawingLinePress(15, 25);
            model.DrawingLineMove(150, 250);
            Assert.AreEqual(150, model.Hint.X2);
            Assert.AreEqual(250, model.Hint.Y2);
            Assert.IsTrue(model.IsMoved);
        }

        // test release in drawing line state
        [TestMethod()]
        public void TestDrawingLineRelease()
        {
            model.Status = "Rectangle";
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            model.DrawingRelease(100, 200);
            model.DrawingPress(300, 400);
            model.DrawingMove(500, 600);
            model.DrawingRelease(500, 600);
            Assert.AreEqual(2, model.Shapes.ShapesList.Count);
            model.State = new DrawingLineState(model);
            model.Status = "Line";
            model.DrawingLinePress(15, 25);
            model.DrawingLineMove(150, 250);
            model.DrawingLineRelease(150, 250);
            Assert.AreEqual(2, model.Shapes.ShapesList.Count);
            Assert.IsInstanceOfType(model.State, typeof(DrawingLineState));
            model.DrawingLinePress(15, 25);
            model.DrawingLineMove(350, 450);
            model.DrawingLineRelease(350, 450);
            Assert.AreEqual(3, model.Shapes.ShapesList.Count);
            Assert.IsFalse(model.IsPress);
            Assert.IsFalse(model.IsMoved);
            Assert.IsInstanceOfType(model.State, typeof(PointerState));
        }

        // test press in pointer state
        [TestMethod()]
        public void TestPointerPress()
        {
            model.Status = "Rectangle";
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            model.DrawingRelease(100, 200);
            model.PointerPress(150, 250);
            Assert.IsNull(model.Select);
            Assert.IsFalse(model.IsPress);
            model.PointerPress(50, 50);
            Assert.IsNotNull(model.Select);
            Assert.IsTrue(model.IsPress);
        }

        // test move in pointer state
        [TestMethod()]
        public void TestPointerMove()
        {
            model.Status = "Rectangle";
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            model.DrawingRelease(100, 200);
            model.PointerPress(50, 50);
            model.PointerMove(150, 150);
            Assert.AreEqual(160, model.Shapes.ShapesList[0].X1);
            Assert.AreEqual(170, model.Shapes.ShapesList[0].Y1);
            Assert.AreEqual(250, model.Shapes.ShapesList[0].X2);
            Assert.AreEqual(350, model.Shapes.ShapesList[0].Y2);
            Assert.IsTrue(model.IsPress);
            Assert.IsTrue(model.IsMoved);
        }

        // test release in pointer state
        [TestMethod()]
        public void TestPointerRelease()
        {
            model.Status = "Rectangle";
            model.DrawingPress(10, 20);
            model.DrawingMove(100, 200);
            model.DrawingRelease(100, 200);
            model.PointerPress(50, 50);
            model.PointerMove(150, 150);
            model.PointerRelease(0, 0);
            Assert.AreEqual(160, model.Shapes.ShapesList[0].X1);
            Assert.AreEqual(170, model.Shapes.ShapesList[0].Y1);
            Assert.AreEqual(250, model.Shapes.ShapesList[0].X2);
            Assert.AreEqual(350, model.Shapes.ShapesList[0].Y2);
            Assert.IsFalse(model.IsPress);
            Assert.IsFalse(model.IsMoved);
        }

    }
}
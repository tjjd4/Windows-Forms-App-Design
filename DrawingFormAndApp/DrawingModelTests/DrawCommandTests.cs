using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        Model model;
        Shape shape;
        DrawCommand drawCommand;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            shape = new Shape();
            drawCommand = new DrawCommand(model, shape);
        }

        // test execute
        [TestMethod()]
        public void ExecuteTest()
        {
            drawCommand.Execute();
            Assert.AreEqual(shape, model.Shapes.ShapesList[model.Shapes.ShapesList.Count - 1]);
        }

        // test undo execute
        [TestMethod()]
        public void UndoExecuteTest()
        {
            drawCommand.Execute();
            Assert.AreEqual(shape, model.Shapes.ShapesList[model.Shapes.ShapesList.Count - 1]);
            drawCommand.UndoExecute();
            Assert.AreEqual(0, model.Shapes.ShapesList.Count);
        }
    }
}
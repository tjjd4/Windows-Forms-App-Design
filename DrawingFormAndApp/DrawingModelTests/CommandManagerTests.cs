using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        CommandManager commandManager;
        Model model;

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            commandManager = new CommandManager();
            model = new Model();
        }

        // test execute
        [TestMethod()]
        public void TestExecute()
        {
            commandManager.Execute(new DrawCommand(model, new Shape()));
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }

        // test undo
        [TestMethod()]
        public void TestUndo()
        {
            commandManager.Execute(new DrawCommand(model, new Shape()));
            commandManager.Execute(new DrawCommand(model, new Shape()));
            commandManager.Undo();
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Undo();
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
        }


        // test redo
        [TestMethod()]
        public void TestRedo()
        {
            commandManager.Execute(new DrawCommand(model, new Shape()));
            commandManager.Execute(new DrawCommand(model, new Shape()));
            commandManager.Undo();
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Undo();
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Redo();
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Redo();
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
            commandManager.Undo();
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Execute(new DrawCommand(model, new Shape()));
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }
        
        // test clear
        [TestMethod()]
        public void TestClear()
        {
            commandManager.Execute(new DrawCommand(model, new Shape()));
            commandManager.Execute(new DrawCommand(model, new Shape()));
            commandManager.Undo();
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Clear();
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }
    }
}
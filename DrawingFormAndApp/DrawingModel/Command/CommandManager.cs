using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        const string CANNOT_UNDO = "Cannot Undo exception\n";
        const string CANNOT_REDO = "Cannot Redo exception\n";

        // execute  add command into stack
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        // undo
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(CANNOT_UNDO);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.UndoExecute();
        }

        // redo
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(CANNOT_REDO);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        // refresh undo redo stack
        public void Clear()
        {
            _undo.Clear();
            _redo.Clear();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}

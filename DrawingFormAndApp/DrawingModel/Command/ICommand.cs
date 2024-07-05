using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public interface ICommand
    {
        // execute
        void Execute();

        // unexecute
        void UndoExecute();
    }
}

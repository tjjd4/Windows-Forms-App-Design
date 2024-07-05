using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        // execute      override
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        // unexecute    override
        public void UndoExecute()
        {
            _model.DeleteShape();
        }
    }
}

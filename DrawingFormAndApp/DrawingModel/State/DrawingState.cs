using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class DrawingState : IState
    {
        Model _model;

        public DrawingState(Model model)
        {
            _model = model;
        }

        // press for drawing shape
        public void Press(double x1, double y1)
        {
            _model.DrawingPress(x1, y1);
        }

        // move for drawing shape
        public void Move(double x2, double y2)
        {
            _model.DrawingMove(x2, y2);
        }

        // release for drawing shape
        public void Release(double x2, double y2)
        {
            _model.DrawingRelease(x2, y2);
        }
    }
}

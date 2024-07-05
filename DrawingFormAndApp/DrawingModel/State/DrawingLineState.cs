using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class DrawingLineState : IState
    {
        Model _model;

        public DrawingLineState(Model model)
        {
            _model = model;
        }

        // press for drawing line
        public void Press(double x1, double y1)
        {
            _model.DrawingLinePress(x1, y1);
        }

        // move for drawing line
        public void Move(double x2, double y2)
        {
            _model.DrawingLineMove(x2, y2);
        }

        // release for drawing line
        public void Release(double x2, double y2)
        {
            _model.DrawingLineRelease(x2, y2);
        }
    }
}

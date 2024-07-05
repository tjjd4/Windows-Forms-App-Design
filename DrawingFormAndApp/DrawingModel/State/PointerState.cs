using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class PointerState : IState
    {
        Model _model;
        double _firstClickX;
        double _firstClickY;

        public PointerState(Model model)
        {
            _model = model;
        }

        // press for pointer
        public void Press(double x1, double y1)
        {
            _firstClickX = x1;
            _firstClickY = y1;
            _model.PressInPointerState(x1, y1);
        }

        // move for pointer
        public void Move(double x1, double y1)
        {
            double moveX = x1 - _firstClickX;
            double moveY = y1 - _firstClickY;
            _firstClickX = x1;
            _firstClickY = y1;
            _model.MoveInPointerState(moveX, moveY);
        }

        // release for pointer
        public void Release(double x1, double y1)
        {
            double moveX = x1 - _firstClickX;
            double moveY = y1 - _firstClickY;
            _model.ReleaseInPointerState(moveX, moveY);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public interface IState
    {
        // press
        void Press(double x1, double y1);

        // move
        void Move(double x1, double y1);

        // release
        void Release(double x1, double y1);
    }
}

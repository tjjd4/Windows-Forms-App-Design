using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        // clear all virtual
        void ClearAll();

        // draw line virtual
        void DrawLine(double x1, double y1, double x2, double y2);

        // draw rectangle
        void DrawRectangle(double x1, double y1, double width, double height);

        // draw dotted line around rectangle
        void DrawDottedLineInRectangle(double x1, double y1, double width, double height);

        // draw ellipse
        void DrawEllipse(double x1, double y1, double width, double height);

        // draw dotted line around ellipse
        void DrawDottedLineInEllipse(double x1, double y1, double width, double height);
    }
}
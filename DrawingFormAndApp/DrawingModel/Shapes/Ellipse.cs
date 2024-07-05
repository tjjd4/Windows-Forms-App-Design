using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class Ellipse : Shape
    {
        const string ELLIPSE = "Ellipse";
        const string FORMAT = "{0},{1},{2},{3},{4},null,null\n";

        // draw ellipse
        public override void Draw(IGraphics graphics)
        {
            TransferData();
            graphics.DrawEllipse(_left, _top, _width, _height);
        }

        // draw dotted line around ellipse
        public override void DrawDottedLine(IGraphics graphics)
        {
            graphics.DrawDottedLineInEllipse(_left, _top, _width, _height);
        }

        // get data in string
        public override string GetDataInString()
        {
            return string.Format(FORMAT, ELLIPSE, _x1, _y1, _x2, _y2);
        }
    }
}

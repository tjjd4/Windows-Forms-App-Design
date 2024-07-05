using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class Rectangle : Shape
    {
        const string RECTANGLE = "Rectangle";
        const string FORMAT = "{0},{1},{2},{3},{4},null,null\n";

        // draw rectangle
        public override void Draw(IGraphics graphics)
        {
            TransferData();
            graphics.DrawRectangle(_left, _top, _width, _height);
        }

        // draw dotted line around rectangle
        public override void DrawDottedLine(IGraphics graphics)
        {
            graphics.DrawDottedLineInRectangle(_left, _top, _width, _height);
        }

        // get data in string
        public override string GetDataInString()
        {
            return string.Format(FORMAT, RECTANGLE, _x1, _y1, _x2, _y2);
        }
    }
}

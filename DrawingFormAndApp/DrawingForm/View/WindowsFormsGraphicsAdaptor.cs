using DrawingModel;
using System.Drawing;

namespace DrawingForm
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        const int THICKNESS = 3;
        const int CORNER_RADIUS = 10;
        const int OFFSET = 5;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // clear all
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // draw line and override
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // draw rectangle and override
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            SolidBrush fillColor = new SolidBrush(Color.Yellow);
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)width, (float)height);
            _graphics.FillRectangle(fillColor, (float)x1, (float)y1, (float)width, (float)height);
        }

        // draw ellipse and override
        public void DrawEllipse(double x1, double y1, double width, double height)
        {
            SolidBrush fillColor = new SolidBrush(Color.Orange);
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)width, (float)height);
            _graphics.FillEllipse(fillColor, (float)x1, (float)y1, (float)width, (float)height);
        }

        // draw dotted line for rectangle and override
        public void DrawDottedLineInRectangle(double x1, double y1, double width, double height)
        {
            Pen pen = new Pen(Color.Red, THICKNESS);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            _graphics.DrawRectangle(pen, (float)x1, (float)y1, (float)width, (float)height);
            DrawEllipseAtCorner(x1 - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 - OFFSET, y1 + height - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 + height - OFFSET);
        }

        // draw dotted line for ellipse and override
        public void DrawDottedLineInEllipse(double x1, double y1, double width, double height)
        {
            Pen pen = new Pen(Color.Red, THICKNESS);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            _graphics.DrawEllipse(pen, (float)x1, (float)y1, (float)width, (float)height);
            DrawEllipseAtCorner(x1 - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 - OFFSET, y1 + height - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 + height - OFFSET);
        }

        // draw ellipse at the corner
        public void DrawEllipseAtCorner(double x1, double y1)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)CORNER_RADIUS, (float)CORNER_RADIUS);
        }
    }
}

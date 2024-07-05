using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class ShapeFactory
    {
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const string LINE = "Line";
        const char DOT = ',';
        const char NEW_LINE = '\n';
        const int X1 = 1;
        const int Y1 = 2;
        const int X2 = 3;
        const int Y2 = 4;
        const int INDEX1 = 5;
        const int INDEX2 = 6;

        // create shape
        public Shape CreateShape(string state)
        {
            Shape shape;
            if (state == RECTANGLE)
            {
                shape = new Rectangle();
                shape.Type = RECTANGLE;
                return shape;
            }
            else if (state == ELLIPSE)
            {
                shape = new Ellipse();
                shape.Type = ELLIPSE;
                return shape;
            }
            else if (state == LINE)
            {
                shape = new Line();
                shape.Type = LINE;
                return shape;
            }
            return null;
        }

        // create shape by text
        public Shape CreateShapeByText(string shapeInText)
        {
            char[] delimiterChars = { DOT, NEW_LINE };
            string[] shapeData = shapeInText.Split(delimiterChars);
            Shape shape;
            if (shapeData[0] == LINE)
            {
                shape = CreateLineWithData(shapeData);
                return shape;
            }
            else if (shapeData[0] == RECTANGLE)
            {
                shape = CreateRectangleWithData(shapeData);
                return shape;
            }
            else if (shapeData[0] == ELLIPSE)
            {
                shape = CreateEllipseWithData(shapeData);
                return shape;
            }
            return null;
        }

        // create line by text
        public Shape CreateLineWithData(string[] shapeData)
        {
            Line line = new Line();
            line.X1 = Convert.ToDouble(shapeData[X1]);
            line.Y1 = Convert.ToDouble(shapeData[Y1]);
            line.X2 = Convert.ToDouble(shapeData[X2]);
            line.Y2 = Convert.ToDouble(shapeData[Y2]);
            line.Index1 = Convert.ToInt32(shapeData[INDEX1]);
            line.Index2 = Convert.ToInt32(shapeData[INDEX2]);
            return line;
        }

        // create rectangle by text
        public Shape CreateRectangleWithData(string[] shapeData)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X1 = Convert.ToDouble(shapeData[X1]);
            rectangle.Y1 = Convert.ToDouble(shapeData[Y1]);
            rectangle.X2 = Convert.ToDouble(shapeData[X2]);
            rectangle.Y2 = Convert.ToDouble(shapeData[Y2]);
            return rectangle;
        }

        // create line by text
        public Shape CreateEllipseWithData(string[] shapeData)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.X1 = Convert.ToDouble(shapeData[X1]);
            ellipse.Y1 = Convert.ToDouble(shapeData[Y1]);
            ellipse.X2 = Convert.ToDouble(shapeData[X2]);
            ellipse.Y2 = Convert.ToDouble(shapeData[Y2]);
            return ellipse;
        }
    }
}

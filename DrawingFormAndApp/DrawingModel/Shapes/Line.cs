using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        Shape _shape1;
        Shape _shape2;
        int _index1;
        int _index2;

        const int TWO = 2;
        const string LINE = "Line";
        const string FORMAT = "{0},{1},{2},{3},{4},{5},{6}\n";

        // calculate center
        public void CalculateCenter()
        {
            if (_shape1 != null && _shape2 != null)
            {
                _x1 = (_shape1.X1 + _shape1.X2) / TWO;
                _x2 = (_shape2.X1 + _shape2.X2) / TWO;
                _y1 = (_shape1.Y1 + _shape1.Y2) / TWO;
                _y2 = (_shape2.Y1 + _shape2.Y2) / TWO;
            }
        }

        // draw line
        public override void Draw(IGraphics graphics)
        {
            CalculateCenter();
            graphics.DrawLine(_x1, _y1, _x2, _y2);
        }

        // set reference shape
        public override void SetShape(Shape shape, int index)
        {
            if (index == 1)
                _shape1 = shape;
            else if (index == TWO)
                _shape2 = shape;
        }

        // set reference shape index
        public override void SetReferenceIndex(Shapes shapes)
        {
            int index = 0;
            foreach (Shape shape in shapes.ShapesList)
            {
                if (shape == _shape1)
                {
                    _index1 = index;
                }
                else if (shape == _shape2)
                {
                    _index2 = index;
                }
                index += 1;
            }
        }

        // get data in string
        public override string GetDataInString()
        {
            return string.Format(FORMAT, LINE, _x1, _y1, _x2, _y2, _index1, _index2);
        }

        // set reference shapes by idnex
        public override void SetReferenceShapesWithIndex(List<Shape> shapesList)
        {
            if (_index1 >= 0 && _index1 < shapesList.Count && _index2 >= 0 && _index2 < shapesList.Count)
            {
                _shape1 = shapesList[_index1];
                _shape2 = shapesList[_index2];
            }
        }

        public Shape Shape1
        {
            get
            {
                return _shape1;
            }
            set
            {
                _shape1 = value;
            }
        }

        public Shape Shape2
        {
            get
            {
                return _shape2;
            }
            set
            {
                _shape2 = value;
            }
        }

        public int Index1
        {
            get
            {
                return Index1;
            }
            set
            {
                _index1 = value;
            }
        }

        public int Index2
        {
            get
            {
                return Index2;
            }
            set
            {
                _index2 = value;
            }
        }
    }
}
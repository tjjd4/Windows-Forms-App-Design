using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class Shape
    {
        protected double _x1;
        protected double _y1;
        protected double _x2;
        protected double _y2;
        protected double _left;
        protected double _top;
        protected double _width;
        protected double _height;
        protected string _type;

        // draw virtual
        public virtual void Draw(IGraphics graphics)
        {

        }

        // draw dotted line virtual
        public virtual void DrawDottedLine(IGraphics graphics)
        {

        }

        // set reference shape
        public virtual void SetShape(Shape shape, int index)
        {

        }

        // set reference shape index
        public virtual void SetReferenceIndex(Shapes shapes)
        {

        }

        // set reference shapes by idnex
        public virtual void SetReferenceShapesWithIndex(List<Shape> shapesList)
        {

        }

        // set 
        public virtual string GetDataInString()
        {
            return string.Empty;
        }

        // data transfer
        public void TransferData()
        {
            if (_x1 > _x2)
                _left = _x2;
            else
                _left = _x1;
            if (_y1 > _y2)
                _top = _y2;
            else
                _top = _y1;
            _width = Math.Abs(_x2 - _x1);
            _height = Math.Abs(_y2 - _y1);
        }

        // correct data
        public void CorrectData()
        {
            if (_x1 > _x2)
            {
                double temp = _x2;
                _x2 = _x1;
                _x1 = temp;
            }
            if (_y1 > _y2)
            {
                double temp = _y2;
                _y2 = _y1;
                _y1 = temp;
            }
        }

        public double X1
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }

        public double X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public double Y1
        {
            get
            {
                return _y1;
            }
            set
            {
                _y1 = value;
            }
        }

        public double Y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public double Top
        {
            get
            {
                return _top;
            }
        }

        public double Left
        {
            get
            {
                return _left;
            }
        }
    }
}

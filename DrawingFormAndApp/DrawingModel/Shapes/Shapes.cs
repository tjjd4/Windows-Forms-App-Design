using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class Shapes
    {
        List<Shape> _shapesList = new List<Shape>();
        ShapeFactory _shapeFactory = new ShapeFactory();

        // call shape to draw
        public void Draw(IGraphics graphics)
        {
            foreach (Shape aShape in _shapesList)
            {
                if (aShape is Line)
                    aShape.Draw(graphics);
            }
            foreach (Shape aShape in _shapesList)
            {
                if (!(aShape is Line))
                    aShape.Draw(graphics);
            }
        }

        // add shape
        public void AddShape(Shape shape)
        {
            _shapesList.Add(shape);
        }

        // delete shape
        public void DeleteShape()
        {
            _shapesList.RemoveAt(_shapesList.Count - 1);
        }
        
        // clear list
        public void Clear()
        {
            _shapesList.Clear();
        }

        // connect to shape factory
        public Shape CreateShape(string state)
        {
            return _shapeFactory.CreateShape(state);
        }

        // create shape by string
        public Shape CreateShapeByText(string shapeInText)
        {
            return _shapeFactory.CreateShapeByText(shapeInText);
        }

        // create shapes by string
        public void CreateShapesByText(List<string> shapesInText)
        {
            Clear();
            foreach (string shapeInText in shapesInText)
            {
                Shape shape = CreateShapeByText(shapeInText);
                shape.SetReferenceShapesWithIndex(_shapesList);
                _shapesList.Add(shape);
            }
        }

        // check is the point located in any shape
        public Shape LocateInShape(double x1, double y1)
        {
            foreach (Shape shape in _shapesList)
            {
                if (shape.X1 < x1 && shape.X2 > x1 && !(shape is Line))
                {
                    if (shape.Y1 < y1 && shape.Y2 > y1)
                    {
                        return shape;
                    }
                }
            }
            return null;
        }

        public List<Shape> ShapesList
        {
            get
            {
                return _shapesList;
            }
        }
    }
}

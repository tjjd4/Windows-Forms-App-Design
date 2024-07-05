using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public partial class Model
    {
        // press in drawing state
        public void DrawingPress(double x1, double y1)
        {
            if (x1 > 0 && y1 > 0 && _status != string.Empty)
            {
                _hint = _shapes.CreateShape(_status);
                if (_hint != null)
                {
                    _hint.X1 = x1;
                    _hint.Y1 = y1;
                    _isPressed = true;
                }
            }
        }

        // move in drawing state
        public void DrawingMove(double x2, double y2)
        {
            if (_isPressed)
            {
                _hint.X2 = x2;
                _hint.Y2 = y2;
                _isMoved = true;
                NotifyModelChanged();
            }
        }

        // release in drawing state
        public void DrawingRelease(double x2, double y2)
        {
            if (_isPressed && _isMoved)
            {
                _hint.X2 = x2;
                _hint.Y2 = y2;
                _hint.CorrectData();
                _commandManager.Execute(new DrawCommand(this, _hint));
            }
            _isPressed = false;
            _isMoved = false;
            _hint = null;
            _state = new PointerState(this);
            NotifyModelChanged();
        }

        // press in drawing line state
        public void DrawingLinePress(double x1, double y1)
        {
            if (x1 > 0 && y1 > 0 && _status != string.Empty && _shapes.LocateInShape(x1, y1) != null)
            {
                _hint = _shapes.CreateShape(_status);
                if (_hint != null)
                {
                    _hint.X1 = x1;
                    _hint.Y1 = y1;
                    _isPressed = true;
                }
            }
        }

        // move in drawing line state
        public void DrawingLineMove(double x2, double y2)
        {
            if (_isPressed)
            {
                _hint.X2 = x2;
                _hint.Y2 = y2;
                _isMoved = true;
                NotifyModelChanged();
            }
        }

        // release in drawing line state
        public void DrawingLineRelease(double x2, double y2)
        {
            if (_isPressed && _isMoved)
            {
                if (_shapes.LocateInShape(x2, y2) != null && _shapes.LocateInShape(_hint.X1, _hint.Y1) != _shapes.LocateInShape(x2, y2))
                {
                    _hint.SetShape(_shapes.LocateInShape(_hint.X1, _hint.Y1), 1);
                    _hint.SetShape(_shapes.LocateInShape(x2, y2), TWO);
                    _hint.CorrectData();
                    _commandManager.Execute(new DrawCommand(this, _hint));
                    _state = new PointerState(this);
                }
            }
            _hint = null;
            _isPressed = false;
            _isMoved = false;
            NotifyModelChanged();
        }

        // press in pointer state
        public void PressInPointerState(double x1, double y1)
        {
            if (x1 > 0 && y1 > 0)
            {
                _select = _shapes.LocateInShape(x1, y1);
                _isPressed = true;
            }
        }

        // move in pointer state
        public void MoveInPointerState(double moveX, double moveY)
        {
            if (_isPressed)
            {
                if (_select != null)
                {
                    _select.X1 += moveX;
                    _select.X2 += moveX;
                    _select.Y1 += moveY;
                    _select.Y2 += moveY;
                    _isMoved = true;
                    NotifyModelChanged();
                }
            }
        }

        // release in pointer state
        public void ReleaseInPointerState(double moveX, double moveY)
        {
            if (_isPressed && _isMoved)
            {
                if (_select != null)
                {
                    _select.X1 += moveX;
                    _select.X2 += moveX;
                    _select.Y1 += moveY;
                    _select.Y2 += moveY;
                }
            }
            _isPressed = false;
            _isMoved = false;
            NotifyModelChanged();
        }

        public IState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
    }
}

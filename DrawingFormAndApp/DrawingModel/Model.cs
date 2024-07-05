using System.Collections.Generic;

namespace DrawingModel
{
    public partial class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        CommandManager _commandManager = new CommandManager();
        bool _isPressed = false;
        bool _isMoved = false;
        Shape _hint = new Shape();
        Shapes _shapes = new Shapes();
        Shape _select = null;
        string _status = string.Empty;
        IState _state;
        GoogleDriveService _service;

        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const string LINE = "Line";
        const int TWO = 2;
        const string DASH = "/";
        const string APPLICATION_NAME = "ShapeUploader";
        const string CLIENT_SECRET_FILE_PATH_NAME = "..\\..\\..\\DrawingModel\\Google\\clientSecret.json";
        const string SHAPE_INFORMATION_FILE_PATH_NAME = "..\\..\\..\\DrawingModel\\Google\\shapeInformation.txt";
        const string STORE_SHAPE_INFORMATION_FILE_PATH = "..\\..\\..\\DrawingModel\\Google";
        const string STORE_SHAPE_INFORMATION_FILE_NAME = "shapeInformation.txt";

        public Model()
        {
            _state = new PointerState(this);
        }

        // set service
        public void SetService()
        {
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_PATH_NAME);
        }

        // set z1 y1 pointer  press
        public void PressPointer(double x1, double y1)
        {
            _state.Press(x1, y1);
        }

        // set x2 y2 pointer move
        public void MovePointer(double x2, double y2)
        {
            _state.Move(x2, y2);
        }

        // draw pointer release
        public void ReleasePointer(double x2, double y2)
        {
            _state.Release(x2, y2);
        }

        // set rectangle type
        public void SetRectangle()
        {
            _status = RECTANGLE;
            _state = new DrawingState(this);
        }

        // set ellipse type
        public void SetEllipse()
        {
            _status = ELLIPSE;
            _state = new DrawingState(this);
        }

        // set line type
        public void SetLine()
        {
            _status = LINE;
            _state = new DrawingLineState(this);
        }

        // add shape
        public void AddShape(Shape shape)
        {
            _shapes.AddShape(shape);
        }

        // delete shape
        public void DeleteShape()
        {
            if (_shapes.ShapesList[_shapes.ShapesList.Count - 1] == _select)
            {
                _select = null;
            }
            _shapes.DeleteShape();
        }

        // undo
        public void Undo()
        {
            _commandManager.Undo();
            _state = new PointerState(this);
            NotifyModelChanged();
        }

        // redo
        public void Redo()
        {
            _commandManager.Redo();
            _state = new PointerState(this);
            NotifyModelChanged();
        }

        // clear data
        public void Clear()
        {
            _isPressed = false;
            _isMoved = false;
            _status = string.Empty;
            _select = null;
            _shapes.Clear();
            _commandManager.Clear();
            NotifyModelChanged();
        }

        // redraw shapes
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            if (_select != null)
                _select.DrawDottedLine(graphics);
            if (_isPressed && _hint != null)
                _hint.Draw(graphics);
        }

        // observer pattern
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public bool IsPress
        {
            get
            {
                return _isPressed;
            }
        }

        public bool IsMoved
        {
            get
            {
                return _isMoved;
            }
        }

        public Shape Hint
        {
            get
            {
                return _hint;
            }
        }

        public Shapes Shapes
        {
            get
            {
                return _shapes;
            }
        }

        public Shape Select
        {
            get
            {
                return _select;
            }
            set
            {
                _select = value;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }
    }
}

namespace DrawingForm
{
    public class PresentationModel
    {
        public event PresentationModelChangedEventHandler _presentationModelChanged;
        public delegate void PresentationModelChangedEventHandler();

        DrawingModel.Model _model;
        bool _isRectangleMode;
        bool _isEllipseMode;
        bool _isLineMode;
        string _info;

        const string LEFT_BRACKET = "(";
        const string RIGHT_BRACKET = ")";
        const string COMMA = ",";

        public PresentationModel(DrawingModel.Model model)
        {
            _model = model;
            _isRectangleMode = false;
            _isEllipseMode = false;
            _isLineMode = false;
            _info = string.Empty;
            _model._modelChanged += HandleModelChanged;
        }

        // clear
        public void Clear()
        {
            _isRectangleMode = false;
            _isEllipseMode = false;
            _isLineMode = false;
            _model.Clear();
            NotifyObserver();
        }

        // set rectangle mode
        public void SetRectangleMode()
        {
            _isRectangleMode = true;
            _isEllipseMode = false;
            _isLineMode = false;
            _model.SetRectangle();
            NotifyObserver();
        }

        // set ellipse mode
        public void SetEllipseMode()
        {
            _isRectangleMode = false;
            _isEllipseMode = true;
            _isLineMode = false;
            _model.SetEllipse();
            NotifyObserver();
        }

        // set line mode
        public void SetLineMode()
        {
            _isRectangleMode = false;
            _isEllipseMode = false;
            _isLineMode = true;
            _model.SetLine();
            NotifyObserver();
        }

        // get state
        public void HandleModelChanged()
        {
            if (_model.State is DrawingModel.PointerState)
            {
                _isRectangleMode = false;
                _isEllipseMode = false;
                _isLineMode = false;
                NotifyObserver();
            }
        }

        // set info
        public void SetInfo()
        {
            if (_model.Select != null)
            {
                DrawingModel.Shape shape = _model.Select;
                _info = shape.Type + LEFT_BRACKET + shape.X1.ToString() + COMMA + shape.Y1.ToString() + COMMA + shape.X2.ToString() + COMMA + shape.Y2.ToString() + RIGHT_BRACKET;
            }
            else
                _info = string.Empty;
        }

        // call observer
        void NotifyObserver()
        {
            if (_presentationModelChanged != null)
                _presentationModelChanged();
        }

        public bool IsRectangleMode
        {
            get
            {
                return _isRectangleMode;
            }
        }

        public bool IsEllipseMode
        {
            get
            {
                return _isEllipseMode;
            }
        }

        public bool IsLineMode
        {
            get
            {
                return _isLineMode;
            }
        }

        public string Info
        {
            get
            {
                return _info;
            }
        }
    }
}

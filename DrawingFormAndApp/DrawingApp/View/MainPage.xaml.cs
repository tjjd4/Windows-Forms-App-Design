using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        DrawingModel.IGraphics _iGraphics;
        PresentationModel _presentationModel;

        public MainPage()
        {
            this.InitializeComponent();
            // Model and presentation model
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel(_model);
            // Note: 重複使用_igraphics物件
            _iGraphics = new View.WindowsStoreGraphicsAdaptor(_canvas);
            // Events
            _canvas.PointerPressed += HandleCanvasPointerPressed;
            _canvas.PointerReleased += HandleCanvasPointerReleased;
            _canvas.PointerMoved += HandleCanvasPointerMoved;
            _clear.Click += HandleClearButtonClick;
            _rectangle.Click += HandleRectangleButtonClick;
            _ellipse.Click += HandleEllipseButtonClick;
            _line.Click += HandleLineButtonClick;
            _model._modelChanged += HandleModelChanged;
            _presentationModel._presentationModelChanged += HandlePresentationModelChanged;
            // set status
            _undo.IsEnabled = false;
            _redo.IsEnabled = false;
            _info.Text = string.Empty;
        }

        // click clear
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.Clear();
        }

        // click rectangle
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetRectangleMode();
        }

        // click clear
        private void HandleEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetEllipseMode();
        }

        // click line
        public void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetLineMode();
        }

        // press mouse
        public void HandleCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // release mouse
        public void HandleCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // move mouse
        public void HandleCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // click undo
        public void HandleUndoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Undo();
        }

        // click redo
        public void HandleRedoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Redo();
        }

        // model change event
        public void HandleModelChanged()
        {
            _redo.IsEnabled = _model.IsRedoEnabled;
            _undo.IsEnabled = _model.IsUndoEnabled;
            _presentationModel.SetInfo();
            _info.Text = _presentationModel.Info;
            _model.Draw(_iGraphics);
        }

        // presentation model changed event
        public void HandlePresentationModelChanged()
        {
            _rectangle.IsEnabled = !(_presentationModel.IsRectangleMode);
            _ellipse.IsEnabled = !(_presentationModel.IsEllipseMode);
            _line.IsEnabled = !(_presentationModel.IsLineMode);
        }
    }
}

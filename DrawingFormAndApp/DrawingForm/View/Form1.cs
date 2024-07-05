using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DrawingForm
{
    public partial class Form1 : Form
    {
        DrawingModel.Model _model;
        Panel _canvas = new DoubleBufferedPanel();
        PresentationModel _presentationModel;

        const string LOAD = "Load";
        const string HINT = "是否要重新載入?";

        public Form1(DrawingModel.Model model)
        {
            InitializeComponent();
            //
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPointerPressed;
            _canvas.MouseUp += HandleCanvasPointerReleased;
            _canvas.MouseMove += HandleCanvasPointerMoved;
            _canvas.Paint += HandleCanvasPaint;
            // Note: setting "_canvas.DoubleBuffered = true" does not work
            Controls.Add(_canvas);
            //
            // prepare presentation model and model
            //
            _model = model;
            _presentationModel = new PresentationModel(model);
            _model._modelChanged += HandleModelChanged;
            _presentationModel._presentationModelChanged += HandlePresentationModelChanged;
            _model.SetService();
            //
            // setting
            //
            _undo.Enabled = false;
            _redo.Enabled = false;
            _info.Text = string.Empty;
        }

        // click clear
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.Clear();
        }

        // click rectangle
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.SetRectangleMode();
        }

        // click ellipse
        public void HandleEllipseButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.SetEllipseMode();
        }

        // click line
        public void HandleLineButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.SetLineMode();
        }

        // press pointer
        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
        }

        // release pointer
        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _model.ReleasePointer(e.X, e.Y);
        }

        // move pointer
        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        // click undo
        public void HandleUndoButtonClick(object sender, System.EventArgs e)
        {
            _model.Undo();
        }

        // click redo
        public void HandleRedoButtonClick(object sender, System.EventArgs e)
        {
            _model.Redo();
        }

        // click save
        async public void HandleSaveButtonClick(object sender, System.EventArgs e)
        {
            bool result = await Task.Factory.StartNew(() => _model.SaveShapes());
        }

        // click load
        public void HandleLoadButtonClick(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(HINT, LOAD, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = _model.DownloadShapes();
            }
        }

        // handle canvas paint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            // e.Graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用e.Graphics，因此，Adaptor不能重複使用
            // 每次都要重新new
            _model.Draw(new DrawingForm.WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        // model changed event
        public void HandleModelChanged()
        {
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            _presentationModel.SetInfo();
            _info.Text = _presentationModel.Info;
            Invalidate(true);
        }

        // presentation model changed event
        public void HandlePresentationModelChanged()
        {
            _rectangle.Enabled = !(_presentationModel.IsRectangleMode);
            _ellipse.Enabled = !(_presentationModel.IsEllipseMode);
            _line.Enabled = !(_presentationModel.IsLineMode);
        }
    }
}

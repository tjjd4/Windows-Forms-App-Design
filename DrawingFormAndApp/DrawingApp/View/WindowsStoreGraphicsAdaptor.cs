using DrawingModel;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace DrawingApp.View
{
    // Windows Store App的繪圖方式採用"物件"模型(與Windows Forms完全不同)
    // 當繪圖時，必須先建立"圖形物件"，再將"圖形物件"加入畫布的Children，此後該圖形就會被畫出來
    // 由於畫布管理其Children，因此有以下優缺點
    //   優點：畫布可以自行處理OnPaint()，而使用者則省掉處理OnPaint()的麻煩
    //   缺點：繪圖時必須先建立"圖形物件"；清除某圖形時，必須刪除Children中對應的物件
    public class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;

        const int THICKNESS = 3;
        const int CORNER_RADIUS = 10;
        const int OFFSET = 5;
        const int DASH = 1;

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // clear all
        public void ClearAll()
        {
            // 清除Children也就清除畫布
            _canvas.Children.Clear();
        }

        // draw line and override
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            // 先建立圖形物件
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            // 將圖形物件加入Children
            _canvas.Children.Add(line);
        }

        // draw rectangle and override
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            // 先建立圖形物件
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Colors.Yellow);
            rectangle.SetValue(Canvas.LeftProperty, x1);
            rectangle.SetValue(Canvas.TopProperty, y1);
            // 將圖形物件加入Children
            _canvas.Children.Add(rectangle);
        }

        // draw ellipse and override
        public void DrawEllipse(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.Orange);
            ellipse.SetValue(Canvas.LeftProperty, x1);
            ellipse.SetValue(Canvas.TopProperty, y1);
            // 將圖形物件加入Children
            _canvas.Children.Add(ellipse);
        }

        // draw dotted line for rectangle and override
        public void DrawDottedLineInRectangle(double x1, double y1, double width, double height)
        {
            // 先建立圖形物件
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            DoubleCollection dash = new DoubleCollection();
            dash.Add(DASH);
            dash.Add(DASH);
            rectangle.StrokeDashArray = dash;
            rectangle.StrokeThickness = THICKNESS;
            rectangle.SetValue(Canvas.LeftProperty, x1);
            rectangle.SetValue(Canvas.TopProperty, y1);
            // 將圖形物件加入Children
            _canvas.Children.Add(rectangle);
            DrawEllipseAtCorner(x1 - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 - OFFSET, y1 + height - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 + height - OFFSET);
        }

        // draw dotted line for ellipse and override
        public void DrawDottedLineInEllipse(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Stroke = new SolidColorBrush(Colors.Red);
            DoubleCollection dash = new DoubleCollection();
            dash.Add(DASH);
            dash.Add(DASH);
            ellipse.StrokeDashArray = dash;
            ellipse.StrokeThickness = THICKNESS;
            ellipse.SetValue(Canvas.LeftProperty, x1);
            ellipse.SetValue(Canvas.TopProperty, y1);
            // 將圖形物件加入Children
            _canvas.Children.Add(ellipse);
            DrawEllipseAtCorner(x1 - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 - OFFSET, y1 + height - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 - OFFSET);
            DrawEllipseAtCorner(x1 + width - OFFSET, y1 + height - OFFSET);
        }

        // draw ellipse at the corner
        public void DrawEllipseAtCorner(double x1, double y1)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Width = CORNER_RADIUS;
            ellipse.Height = CORNER_RADIUS;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.SetValue(Canvas.LeftProperty, x1);
            ellipse.SetValue(Canvas.TopProperty, y1);
            _canvas.Children.Add(ellipse);
        }
    }
}
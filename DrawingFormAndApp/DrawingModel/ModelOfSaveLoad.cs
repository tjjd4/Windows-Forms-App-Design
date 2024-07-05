using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DrawingModel
{
    public partial class Model
    {
        // write shapes
        public void WriteShapes()
        {
            int index = 0;
            foreach (Shape shape in _shapes.ShapesList)
            {
                if (shape is Line)
                    shape.SetReferenceIndex(_shapes);
                if (index == 0)
                    File.WriteAllText(SHAPE_INFORMATION_FILE_PATH_NAME, shape.GetDataInString());
                else
                    File.AppendAllText(SHAPE_INFORMATION_FILE_PATH_NAME, shape.GetDataInString());
                index += 1;
            }
        }

        // save shapes
        public bool SaveShapes()
        {
            try
            {
                WriteShapes();
                const string CONTENT_TYPE = "text/csv";
                _service.UploadFile(SHAPE_INFORMATION_FILE_PATH_NAME, CONTENT_TYPE);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // get file list
        public List<Google.Apis.Drive.v2.Data.File> GetFileList()
        {
            return _service.ListRootFileAndFolder();
        }

        // download shape information
        public bool DownloadShapes()
        {
            try
            {
                List<Google.Apis.Drive.v2.Data.File> fileList = GetFileList();
                Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item =>
                {
                    return item.Title == STORE_SHAPE_INFORMATION_FILE_NAME;
                });
                _service.DownloadFile(foundFile, STORE_SHAPE_INFORMATION_FILE_PATH);
                ReadShapes();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // read file shape information
        public void ReadShapes()
        {
            List<string> shapesInText = new List<string>();
            foreach (string line in File.ReadLines(STORE_SHAPE_INFORMATION_FILE_PATH + DASH + STORE_SHAPE_INFORMATION_FILE_NAME))
            {
                shapesInText.Add(line);
            }
            _state = new PointerState(this);
            _isPressed = false;
            _commandManager.Clear();
            _shapes.CreateShapesByText(shapesInText);
            NotifyModelChanged();
        }
    }
}

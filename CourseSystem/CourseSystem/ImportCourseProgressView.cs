using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class ImportCourseProgressView : Form
    {
        Model _model;
        ImportPresentationModel _importModel;

        const string TEXT = "Text";
        const string PROGRESS = "Progress";

        public ImportCourseProgressView(Model model)
        {
            _model = model;
            _importModel = new ImportPresentationModel(model);
            InitializeComponent();
            _label.DataBindings.Add(TEXT, _importModel, PROGRESS);
            _importModel.DownloadClasses();
        }

        // change progress when text changed
        private void ChangeText(object sender, EventArgs e)
        {
            int integer;
            if (int.TryParse(_label.Text,out integer))
            {
                _progressBar.Value = int.Parse(_label.Text);
            }
            _label.Refresh();
        }
    }
}

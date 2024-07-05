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
    public partial class SelectResultView : Form
    {
        SelectResultPresentationModel _selectResultModel;
        Model _model;

        const string DELETE_HEADER = "退";
        const string DELETE_BUTTON = "退選";

        public SelectResultView(Model model)
        {
            _model = model;
            _selectResultModel = new SelectResultPresentationModel(_model);
            InitializeComponent();
            ConstructTable();
            _selectResultModel.SetHeaderText(_dataGridViewResult);
            _model._modelChanged += ConstructTable;
        }

        // construct table for datagridview
        private void ConstructTable()
        {
            _dataGridViewResult.DataSource = _selectResultModel.GetResultCourseInfo().CourseInfo;
        }

        // Click delete button
        private void ClickDeleteButton(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int deleteIndex = e.RowIndex;
                _selectResultModel.DeleteSelectedCourse(deleteIndex);
            }
        }

        // refresh status
        public void CheckState()
        {
            ConstructTable();
        }
    }
}

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
    public partial class SelectView : Form
    {
        SelectPresentationModel _selectModel;
        Model _model;

        public SelectView(Model model)
        {
            _model = model;
            _selectModel = new SelectPresentationModel(_model);
            InitializeComponent();
            ConstructTable();
            _model._modelChanged += CheckState;
            _selectModel._selectModelChanged += CheckState;
        }

        // construct table for datagridview
        public void ConstructTable()
        {
            if (_selectModel.CheckTabPageAmount(_tabControl1.TabPages.Count))
                AddTabPage();

            int tabPageIndex = 0;
            foreach (TabPage tabPage in _tabControl1.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is DataGridView)
                    {
                        ((DataGridView)control).DataSource = _selectModel.GetSelectingCourseInfos()[tabPageIndex].CourseInfo;
                        _selectModel.SetHeaderText((DataGridView)control);
                    }
                    tabPageIndex++;
                }
            }
        }

        // checkbox column click event
        private void ClickCheckBox(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            dataGridView.EndEdit();
            _buttonSend.Enabled = _selectModel.ClickCheckBox(_tabControl1);
        }

        // send data
        private void ClickSend(object sender, EventArgs e)
        {
            _selectModel.ClickSend(_tabControl1);
            _buttonSend.Enabled = false;
        }

        // click select result
        private void ClickSelectResult(object sender, EventArgs e)
        {
            _selectModel.ClickSelectResult();
            _buttonSelectResult.Enabled = false;
        }

        // add tabpage and datagridview
        public void AddTabPage()
        {
            for (int tabPageIndex = _tabControl1.TabPages.Count; tabPageIndex < _selectModel.GetSelectingCourseInfos().Count; tabPageIndex++)
            {
                Console.WriteLine(_selectModel.GetSelectingCourseInfos()[tabPageIndex].ClassChineseName);
                TabPage tabPage = new TabPage("");
                DataGridView dataGridView = _selectModel.GetDataGridView(tabPageIndex);
                dataGridView.CellContentClick += new DataGridViewCellEventHandler(ClickCheckBox);
                _tabControl1.TabPages.Add(tabPage);
                _tabControl1.TabPages[tabPageIndex].Controls.Add(dataGridView);
                _tabControl1.TabPages[tabPageIndex].Text = _selectModel.GetSelectingCourseInfos()[tabPageIndex].ClassChineseName;
                _selectModel.SetHeaderText(dataGridView);
            }
        }

        // refresh status
        private void CheckState()
        {
            _buttonSelectResult.Enabled = _selectModel.IsSelectResultViewClosed;
            ConstructTable();
        }
    }
}

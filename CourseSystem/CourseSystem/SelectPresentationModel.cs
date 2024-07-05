using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace CourseSystem
{
    public class SelectPresentationModel
    {
        public event SelectModelChangedEventHandler _selectModelChanged;
        public delegate void SelectModelChangedEventHandler();

        Model _model;
        bool _isSelectResultViewClosed;

        const int NUMBER_CONFLICT = 0;
        const int NAME_CONFLICT = 1;
        const int CLASSTIME_CONFLICT = 2;
        const string SAME_NUMBER = "課號相同";
        const string SAME_NAME = "課程名稱相同";
        const string SAME_TIME = "衝堂";
        const string SUCCESS_ADD = "加選成功";
        const string NEW_LINE = "\n";
        const string SELECT = "選";
        const string NULL_STRING = "";

        public SelectPresentationModel(Model model)
        {
            _model = model;
            _isSelectResultViewClosed = true;
        }

        public bool IsSelectResultViewClosed
        {
            get
            {
                return _isSelectResultViewClosed;
            }
        }

        // connect to model
        public BindingList<Class> GetSelectingCourseInfos()
        {
            return _model.SelectingCourseInfos;
        }

        // click select result
        public void ClickSelectResult(string test = NULL_STRING)
        {
            if (test == NULL_STRING)
            {
                SelectResultView selectResultView = new SelectResultView(_model);
                selectResultView.Show();
                selectResultView.FormClosed += CloseSelectResultView;
            }
            _isSelectResultViewClosed = false;
        }

        // set the title of the column
        public void SetHeaderText(DataGridView dataGridView)
        {
            Class.SetHeaderText(dataGridView);
        }

        // refresh status
        public void CloseSelectResultView(object sender, FormClosedEventArgs e)
        {
            _isSelectResultViewClosed = true;
            NotifyObserver();
        }

        // check checkbox have been check or not
        public bool ClickCheckBox(TabControl tabControl)
        {
            foreach (TabPage tabpage in tabControl.TabPages)
            {
                foreach (Control control in tabpage.Controls)
                {
                    if (control is DataGridView)
                    {
                        foreach (DataGridViewRow row in ((DataGridView)control).Rows)
                        {
                            if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        // send data
        public void ClickSend(TabControl tabControl)
        {
            List<List<int>> selectedIndex = new List<List<int>>();
            int tabPageIndex = 0;
            foreach (TabPage tabpage in tabControl.TabPages)
            {
                List<int> temporarySelectedIndex = new List<int>();
                foreach (Control control in tabpage.Controls)
                {
                    if (control is DataGridView)
                    {
                        foreach (DataGridViewRow row in ((DataGridView)control).Rows)
                        {
                            if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                            {
                                temporarySelectedIndex.Add(row.Index);
                            }
                        }
                    }
                }
                selectedIndex.Add(temporarySelectedIndex);
                tabPageIndex++;
            }
            CheckCourseAdd(_model.AddCourses(selectedIndex));
        }

        // check course adding is succeed
        public string CheckCourseAdd(List<string> message, string test = NULL_STRING)
        {
            string finalMessage = NULL_STRING;
            if (message[NUMBER_CONFLICT] != NULL_STRING)
            {
                finalMessage += SAME_NUMBER + NEW_LINE + message[NUMBER_CONFLICT] + NEW_LINE + NEW_LINE;
            }
            if (message[NAME_CONFLICT] != NULL_STRING)
            {
                finalMessage += SAME_NAME + NEW_LINE + message[NAME_CONFLICT] + NEW_LINE + NEW_LINE;
            }
            if (message[CLASSTIME_CONFLICT] != NULL_STRING)
            {
                finalMessage += SAME_TIME + NEW_LINE + message[CLASSTIME_CONFLICT] + NEW_LINE + NEW_LINE;
            }
            if (test == NULL_STRING)
            {
                if (finalMessage == NULL_STRING)
                {
                    MessageBox.Show(SUCCESS_ADD);
                }
                else
                {
                    MessageBox.Show(finalMessage);
                }
            }
            return finalMessage;
        }

        // return a list of datagridview
        public DataGridView GetDataGridView(int classIndex)
        {
            BindingList<Class> selectingCourseInfos = GetSelectingCourseInfos();
            DataGridView dataGridView;
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.DataSource = selectingCourseInfos[classIndex];
            dataGridView.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dataGridView.Columns[0].HeaderText = SELECT;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            return dataGridView;
        }

        // check if tabpage is enough
        public bool CheckTabPageAmount(int amount)
        {
            if (GetSelectingCourseInfos().Count > amount)
                return true;
            return false;
        }

        // call observer
        void NotifyObserver()
        {
            if (_selectModelChanged != null)
                _selectModelChanged();
        }
    }
}

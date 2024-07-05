using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class ManagementView : Form
    {
        ManagementPresentationModel _managementModel;
        Model _model;

        const string MODIFY_COURSE = "編輯課程";
        const string ADD_COURSE = "新增課程";
        const string SAVE = "儲存";
        const string ADD = "新增";
        const string DELETE_COURSE = "停課";
        const string CSIE_1_NAME = "資工一";
        const string CSIE_2_NAME = "資工二";
        const string CSIE_4_NAME = "資工四";
        const string TEXT = "Text";
        const string OPEN_CLASS = "開課";
        const string NUMBER = "Number";
        const string NAME = "Name";
        const string STAGE = "Stage";
        const string CREDIT = "Credit";
        const string HOUR = "Hour";
        const string REQUIRED = "Required";
        const string TEACHER = "Teacher";
        const string ASSISTANT = "Assistant";
        const string LANGUAGE = "Language";
        const string NOTE = "Note";
        const string CLASS_CHINESE_NAME = "ClassChineseName";
        const string CLASS = "Class";
        const string CLASS_CHINESE = "班級";
        const string ADD_CLASS = "新增班級";
        const int NUMBER_BOTTOM_LIMIT = 48;
        const int NUMBER_TOP_LIMIT = 57;
        const int NUMBER_BACKSPACE = 8;

        public ManagementView(Model model)
        {
            this.ImeMode = ImeMode.Off;
            _model = model;
            InitializeComponent();
            _managementModel = new ManagementPresentationModel(_model);
            GenerateTable();
            GenerateListBox();
            SetDataBinding();
            _buttonSave.Enabled = false;
            LockAllStatus();
            _model._modelChanged += RefreshStatus;
        }

        // add class time and row
        private void GenerateTable()
        {
            _dataGridViewTime.DataSource = _managementModel.ClassTimeTable;
        }

        // connect link box to courses
        private void GenerateListBox()
        {
            _listBox.DataSource = _managementModel.GetAllCourses().CourseInfo;
            _listBox.DisplayMember = NAME;
            _listBoxClass.DataSource = _managementModel.GetCourseInfos();
            _listBoxClass.DisplayMember = CLASS_CHINESE_NAME;
        }

        // show course data
        private void ClickListBox(object sender, EventArgs e)
        {
            _groupBox.Text = MODIFY_COURSE;
            _buttonSave.Text = SAVE;
            _managementModel.ShowCourseData(_listBox.SelectedIndex);
            _comboBoxStatus.SelectedIndex = 0;
            _buttonAdd.Enabled = true;
            UnlockAllStatus();
        }

        // set data binding
        private void SetDataBinding()
        {
            _textBoxNumber.DataBindings.Add(TEXT, _managementModel, NUMBER);
            _textBoxName.DataBindings.Add(TEXT, _managementModel, NAME);
            _textBoxStage.DataBindings.Add(TEXT, _managementModel, STAGE);
            _textBoxCredit.DataBindings.Add(TEXT, _managementModel, CREDIT);
            _textBoxTeacher.DataBindings.Add(TEXT, _managementModel, TEACHER);
            _textBoxAssistant.DataBindings.Add(TEXT, _managementModel, ASSISTANT);
            _textBoxLanguage.DataBindings.Add(TEXT, _managementModel, LANGUAGE);
            _textBoxNote.DataBindings.Add(TEXT, _managementModel, NOTE);
            _comboBoxRequired.DataBindings.Add(TEXT, _managementModel, REQUIRED);
            _comboBoxHour.DataBindings.Add(TEXT, _managementModel, HOUR);
            _comboBoxClassName.DataBindings.Add(TEXT, _managementModel, CLASS_CHINESE_NAME);
            _textBoxClass.DataBindings.Add(TEXT, _managementModel, CLASS);
        }

        // because cant end edit on text box, the binding data can't refresh instance
        private List<string> FetchText()
        {
            List<string> allText = new List<string>();
            allText.Add(_textBoxNumber.Text.Trim());
            allText.Add(_textBoxName.Text.Trim());
            allText.Add(_textBoxStage.Text.Trim());
            allText.Add(_textBoxCredit.Text.Trim());
            allText.Add(_textBoxTeacher.Text.Trim());
            allText.Add(_comboBoxRequired.Text.Trim());
            allText.Add(_comboBoxHour.Text.Trim());
            allText.Add(_comboBoxClassName.Text.Trim());
            allText.Add(_comboBoxStatus.Text.Trim());
            allText.Add(_groupBox.Text.Trim());
            return allText;

        }

        // lock all text box and combobox
        private void LockAllStatus()
        {
            _managementModel.LockAllStatus(_groupBox);
        }

        // lock all text box and combobox
        private void UnlockAllStatus()
        {
            _managementModel.UnlockAllStatus(_groupBox);
        }

        // clear all combo box
        private void ClearAllComboBox()
        {
            _comboBoxStatus.SelectedIndex = -1;
            _comboBoxRequired.SelectedIndex = -1;
            _comboBoxHour.SelectedIndex = -1;
            _comboBoxClassName.SelectedIndex = -1;
        }

        // refresh save button status (text changed)
        private void CheckState(object sender, EventArgs e)
        {
            _managementModel.SetData(FetchText());
            _buttonSave.Enabled = _managementModel.CheckSaveButtonState();
        }

        // click add button
        private void ClickButtonAdd(object sender, EventArgs e)
        {
            _groupBox.Text = ADD_COURSE;
            _buttonSave.Text = ADD;
            _managementModel.ClearAllData();
            _buttonAdd.Enabled = false;
            ClearAllComboBox();
            _comboBoxStatus.SelectedIndex = 0;
            _comboBoxHour.SelectedIndex = 0;
            _comboBoxClassName.SelectedIndex = 0;
            _comboBoxRequired.SelectedIndex = 0;
            UnlockAllStatus();
        }

        // change class time
        private void ClickClassTime(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            dataGridView.EndEdit();
            _buttonSave.Enabled = _managementModel.CheckSaveButtonState();
        }

        // click save button
        private void ClickButtonSave(object sender, EventArgs e)
        {
            if (_comboBoxStatus.Text == DELETE_COURSE)
            {
                _managementModel.DeleteCourse();
            }
            else
            {
                string text = _groupBox.Text;
                _managementModel.ClickButtonSave(text);
            }
            GenerateListBox();
            _buttonSave.Enabled = false;
            ClearAllComboBox();
            LockAllStatus();
        }

        // restrict interger input
        private void PressKeyInNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < NUMBER_BOTTOM_LIMIT | e.KeyChar > NUMBER_TOP_LIMIT) && e.KeyChar != NUMBER_BACKSPACE)
                e.Handled = true;
        }

        // click download all courses
        private void ClickButtonDownload(object sender, EventArgs e)
        {
            _comboBoxClassName.Items.Add(CSIE_1_NAME);
            _comboBoxClassName.Items.Add(CSIE_2_NAME);
            _comboBoxClassName.Items.Add(CSIE_4_NAME);
            _buttonDownload.Enabled = false;
            _managementModel.ClickButtonDownload();
            _buttonDownload.Enabled = true;
        }

        // refresh list box
        public void RefreshStatus()
        {
            GenerateListBox();
        }

        // show class data
        private void ClickListBoxClass(object sender, EventArgs e)
        {
            _groupBoxClass.Text = CLASS_CHINESE;
            _buttonAddClass.Enabled = true;
            _buttonSaveClass.Enabled = false;
            _textBoxClass.Enabled = false;
            _listBoxCourse.DataSource =  _managementModel.ShowClassData(_listBoxClass.SelectedIndex);
            _listBoxCourse.DisplayMember = NAME;
        }

        // click button add class
        private void ClickButtonAddClass(object sender, EventArgs e)
        {
            _groupBoxClass.Text = ADD_CLASS;
            _buttonAddClass.Enabled = false;
            _textBoxClass.Enabled = true;
            _textBoxClass.Text = string.Empty;
            _listBoxCourse.DataSource = new Class(string.Empty).CourseInfo;
        }

        // click button add class
        private void ClickButtonSaveClass(object sender, EventArgs e)
        {
            _groupBoxClass.Text = CLASS_CHINESE;
            _buttonAddClass.Enabled = true;
            _buttonSaveClass.Enabled = false;
            _textBoxClass.Enabled = false;
            _listBoxCourse.DataSource = new Class(string.Empty).CourseInfo;
            _managementModel.ClickClassButtonSave();
            _comboBoxClassName.Items.Add(_textBoxClass.Text.Trim());
        }

        // check button state (text changed)
        private void CheckClassState(object sender, EventArgs e)
        {
            _buttonSaveClass.Enabled = !(_buttonAddClass.Enabled) && _managementModel.CheckClassSaveButtonState(_textBoxClass.Text.Trim());
        }
    }
}

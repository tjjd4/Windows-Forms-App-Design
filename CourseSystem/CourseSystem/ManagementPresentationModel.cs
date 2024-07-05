using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CourseSystem
{
    public class ManagementPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model _model;
        string _number;
        string _name;
        string _stage;
        string _credit;
        string _teacher;
        string _assistant;
        string _language;
        string _note;
        string _required;
        string _hour;
        string _classChineseName;
        string _class;
        List<string> _allText;
        List<string> _classTime;
        CourseInfoDto _displayingCourse;
        DataTable _classTimeTable = new DataTable();
        Dictionary<char, int> _charToCourseIndex = new Dictionary<char, int>();
        Dictionary<string, string> _chineseNameToClassName = new Dictionary<string, string>();
        Dictionary<string, string> _classNameToChineseName = new Dictionary<string, string>();

        private const int SUNDAY_NUMBER = 7;
        private const int SATURDAY_NUMBER = 13;
        const char CLASS_TIME_NOON = 'N';
        const char CLASS_TIME_A = 'A';
        const char CLASS_TIME_B = 'B';
        const char CLASS_TIME_C = 'C';
        const char CLASS_TIME_D = 'D';
        const char CHAR_SPACE = ' ';
        const int TABLE_ROW_AMOUNT = 14;
        const int TABLE_COLUMN_AMOUNT = 8;
        const string SECTION_NAME = "節數";
        const string MODIFY_COURSE = "編輯課程";
        const string ADD_COURSE = "新增課程";
        const string DELETE_COURSE = "停課";
        const string CSIE_NAME = "資工三";
        const string CSIE_1_NAME = "資工一";
        const string CSIE_2_NAME = "資工二";
        const string CSIE_4_NAME = "資工四";
        const string EE_NAME = "電子三甲";
        const string COURSE_CSIE = "CSIE";
        const string COURSE_CSIE_1 = "CSIE1";
        const string COURSE_CSIE_2 = "CSIE2";
        const string COURSE_CSIE_4 = "CSIE4";
        const string COURSE_EE = "EE";
        const string NULL_STRING = "";
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
        const string STRING_SPACE = " ";
        const int ZERO = 0;
        const int ONE = 1;
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        const int SIX = 6;
        const int SEVEN = 7;
        const int EIGHT = 8;
        const int NINE = 9;
        const int TEN = 10;
        const int ELEVEN = 11;
        const int TWELVE = 12;
        const int THIRTEEN = 13;
        const char CHAR_ONE = '1';
        const char CHAR_TWO = '2';
        const char CHAR_THREE = '3';
        const char CHAR_FOUR = '4';
        const char CHAR_FIVE = '5';
        const char CHAR_SIX = '6';
        const char CHAR_SEVEN = '7';
        const char CHAR_EIGHT = '8';
        const char CHAR_NINE = '9';
        const string SUNDAY_NAME = "日";
        const string MONDAY_NAME = "一";
        const string TUESDAY_NAME = "二";
        const string WEDNESDAY_NAME = "三";
        const string THURSDAY_NAME = "四";
        const string FRIDAY_NAME = "五";
        const string SATURDAY_NAME = "六";

        public ManagementPresentationModel(Model model)
        {
            _model = model;
            SetDictionary();
            _classTimeTable = InitialClassTimeTable(_classTimeTable);
        }

        // set dictionary for class time transform
        public void SetDictionary()
        {
            _charToCourseIndex.Add(CHAR_ONE, ZERO);
            _charToCourseIndex.Add(CHAR_TWO, ONE);
            _charToCourseIndex.Add(CHAR_THREE, TWO);
            _charToCourseIndex.Add(CHAR_FOUR, THREE);
            _charToCourseIndex.Add(CLASS_TIME_NOON, FOUR);
            _charToCourseIndex.Add(CHAR_FIVE, FIVE);
            _charToCourseIndex.Add(CHAR_SIX, SIX);
            _charToCourseIndex.Add(CHAR_SEVEN, SEVEN);
            _charToCourseIndex.Add(CHAR_EIGHT, EIGHT);
            _charToCourseIndex.Add(CHAR_NINE, NINE);
            _charToCourseIndex.Add(CLASS_TIME_A, TEN);
            _charToCourseIndex.Add(CLASS_TIME_B, ELEVEN);
            _charToCourseIndex.Add(CLASS_TIME_C, TWELVE);
            _charToCourseIndex.Add(CLASS_TIME_D, THIRTEEN);
            _chineseNameToClassName.Add(CSIE_NAME, COURSE_CSIE);
            _chineseNameToClassName.Add(CSIE_1_NAME, COURSE_CSIE_1);
            _chineseNameToClassName.Add(CSIE_2_NAME, COURSE_CSIE_2);
            _chineseNameToClassName.Add(CSIE_4_NAME, COURSE_CSIE_4);
            _chineseNameToClassName.Add(EE_NAME, COURSE_EE);
            _classNameToChineseName.Add(COURSE_CSIE, CSIE_NAME);
            _classNameToChineseName.Add(COURSE_CSIE_1, CSIE_1_NAME);
            _classNameToChineseName.Add(COURSE_CSIE_2, CSIE_2_NAME);
            _classNameToChineseName.Add(COURSE_CSIE_4, CSIE_4_NAME);
            _classNameToChineseName.Add(COURSE_EE, EE_NAME);
        }

        // create a empty table for class time
        public DataTable InitialClassTimeTable(DataTable classTimeTable)
        {
            classTimeTable.Columns.Add(new DataColumn(SECTION_NAME, typeof(string)));
            classTimeTable.Columns.Add(new DataColumn(SUNDAY_NAME, typeof(bool)));
            classTimeTable.Columns.Add(new DataColumn(MONDAY_NAME, typeof(bool)));
            classTimeTable.Columns.Add(new DataColumn(TUESDAY_NAME, typeof(bool)));
            classTimeTable.Columns.Add(new DataColumn(WEDNESDAY_NAME, typeof(bool)));
            classTimeTable.Columns.Add(new DataColumn(THURSDAY_NAME, typeof(bool)));
            classTimeTable.Columns.Add(new DataColumn(FRIDAY_NAME, typeof(bool)));
            classTimeTable.Columns.Add(new DataColumn(SATURDAY_NAME, typeof(bool)));
            return InitialRow(classTimeTable);
        }

        // set data row
        public DataTable InitialRow(DataTable classTimeTable)
        {
            for (int rowIndex = 0; rowIndex < TABLE_ROW_AMOUNT; rowIndex++)
            {
                DataRow row = classTimeTable.NewRow();
                if (rowIndex < FOUR)
                    row[SECTION_NAME] = (rowIndex + 1).ToString();
                else if (rowIndex == FOUR)
                    row[SECTION_NAME] = CLASS_TIME_NOON;
                else if (rowIndex == TEN)
                    row[SECTION_NAME] = CLASS_TIME_A;
                else if (rowIndex == ELEVEN)
                    row[SECTION_NAME] = CLASS_TIME_B;
                else if (rowIndex == TWELVE)
                    row[SECTION_NAME] = CLASS_TIME_C;
                else if (rowIndex == THIRTEEN)
                    row[SECTION_NAME] = CLASS_TIME_D;
                else
                    row[SECTION_NAME] = rowIndex.ToString();
                for (int index = 1; index < TABLE_COLUMN_AMOUNT; index++)
                {
                    row[index] = false;
                }
                classTimeTable.Rows.Add(row);
            }
            return classTimeTable;
        }

        // clear table
        public void ClearTable()
        {
            for (int rowIndex = 0; rowIndex < TABLE_ROW_AMOUNT; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < TABLE_COLUMN_AMOUNT; columnIndex++)
                    _classTimeTable.Rows[rowIndex][columnIndex] = false;
            }
        }

        // lock all text box and combobox
        public void LockAllStatus(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox || control is ComboBox)
                {
                    control.Enabled = false;
                }
            }
        }

        // unlock all text box and combobox
        public void UnlockAllStatus(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox || control is ComboBox)
                {
                    control.Enabled = true;
                }
            }
        }

        // get all course info
        public Class GetAllCourses()
        {
            return _model.AllCourses;
        }

        // get CourseInfo
        public BindingList<Class> GetCourseInfos()
        {
            return _model.CourseInfos;
        }

        // showing the course data
        public void ShowCourseData(int selectedIndex)
        {
            _displayingCourse = _model.AllCourses.CourseInfo[selectedIndex];
            _number = _displayingCourse.Number;
            _name = _displayingCourse.Name;
            _stage = _displayingCourse.Stage;
            _credit = _displayingCourse.Credit;
            _teacher = _displayingCourse.Teacher;
            _assistant = _displayingCourse.TeachingAssistant;
            _language = _displayingCourse.Language;
            _note = _displayingCourse.Note;
            _required = _displayingCourse.RequiredOrElective;
            _hour = _displayingCourse.Hour;
            _classChineseName = _displayingCourse.ClassChineseName;
            ClearTable();
            SetClassTimeTable(_displayingCourse);
            NotifyAllChanged();
        }

        // set class time table for databinding
        public void SetClassTimeTable(CourseInfoDto course)
        {
            ClearTable();
            for (int index = SUNDAY_NUMBER; index <= SATURDAY_NUMBER; index++)
            {
                char[] classTime = course.GetInRow()[index].ToCharArray();
                foreach (char letter in classTime)
                {
                    if (letter != CHAR_SPACE)
                        _classTimeTable.Rows[_charToCourseIndex[letter]][index - SIX] = true;
                }
            }
        }

        // set class time table
        public DataTable SetClassTimeTable(CourseInfoDto course, DataTable classTimeTable)
        {
            for (int index = SUNDAY_NUMBER; index <= SATURDAY_NUMBER; index++)
            {
                char[] classTime = course.GetInRow()[index].ToCharArray();
                foreach (char letter in classTime)
                {
                    if (letter != CHAR_SPACE)
                        classTimeTable.Rows[_charToCourseIndex[letter]][index - SIX] = true;
                }
            }
            return classTimeTable;
        }

        // because of text box cant end edit, need to update data manually
        public void SetData(List<string> allText)
        {
            _allText = allText;
        }

        // clear all data
        public void ClearAllData()
        {
            _number = NULL_STRING;
            _name = NULL_STRING;
            _stage = NULL_STRING;
            _credit = NULL_STRING;
            _teacher = NULL_STRING;
            _assistant = NULL_STRING;
            _language = NULL_STRING;
            _note = NULL_STRING;
            _required = NULL_STRING;
            _hour = NULL_STRING;
            _classChineseName = NULL_STRING;
            _displayingCourse = null;
            ClearTable();
            NotifyAllChanged();
        }

        // create a new CourseInfoDto to save data
        public CourseInfoDto SaveDataInCourse()
        {
            _classTime = CollectClassTime();
            CourseInfoDto course = new CourseInfoDto(_number, _name, _stage, _credit, _hour, _required, _teacher, _classTime[ZERO],
                _classTime[ONE], _classTime[TWO], _classTime[THREE], _classTime[FOUR], _classTime[FIVE], _classTime[SIX], NULL_STRING, NULL_STRING,
                NULL_STRING, _assistant, _language, _note, NULL_STRING, NULL_STRING, NULL_STRING, _classChineseName);
            return course;
        }

        // click save button
        public void ClickButtonSave(string text)
        {
            CourseInfoDto course = SaveDataInCourse();
            if (text == MODIFY_COURSE)
                _model.ModifyCourse(course, _displayingCourse);
            else if (text == ADD_COURSE)
            {
                _model.AddNewCourse(course);
            }
            ClearAllData();
        }

        // refresh save button state
        public bool CheckSaveButtonState()
        {
            bool checkValue = true;
            if (CheckStatus())
                return true;
            checkValue = !IsDataEmpty();
            if (checkValue)
                checkValue = CheckClassTime();
            if (checkValue && _displayingCourse != null)
                checkValue = CheckDataChanged() || CheckChangedClassTime();
            else if (checkValue && _displayingCourse == null)
                checkValue = !CheckChangedCourseNumber(_allText[0]);
            return checkValue;
        }

        // check have the data been changed
        public bool CheckDataChanged()
        {
            if (_allText[ZERO] != _displayingCourse.Number || _allText[ONE] != _displayingCourse.Name || _allText[TWO] != _displayingCourse.Stage || float.Parse(_allText[THREE]) != float.Parse(_displayingCourse.Credit) || _allText[FOUR] != _displayingCourse.Teacher || _allText[FIVE] != _displayingCourse.RequiredOrElective || _allText[SIX] != _displayingCourse.Hour || _allText[SEVEN] != _displayingCourse.ClassChineseName)
                return true;
            return false;
        }

        // check if data is empty
        public bool IsDataEmpty()
        {
            return _allText[ZERO] == NULL_STRING || _allText[ONE] == NULL_STRING || _allText[TWO] == NULL_STRING || _allText[THREE] == NULL_STRING || _allText[FOUR] == NULL_STRING || _allText[FIVE] == NULL_STRING || _allText[SIX] == NULL_STRING || _allText[SEVEN] == NULL_STRING;
        }

        // connect to model check is there a same course number
        public bool CheckChangedCourseNumber(string courseNumber)
        {
            return _model.CheckChangedCourseNumber(courseNumber);
        }

        // check group box text and course status
        public bool CheckStatus()
        {
            if (_allText[EIGHT] == DELETE_COURSE && _allText[NINE] == MODIFY_COURSE)
                return true;
            return false;
        }

        // check class time compare with hours
        public bool CheckClassTime()
        {
            int count = 0;
            for (int rowIndex = 0; rowIndex < TABLE_ROW_AMOUNT; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < TABLE_COLUMN_AMOUNT; columnIndex++)
                    if ((bool)_classTimeTable.Rows[rowIndex][columnIndex])
                        count++;
            }
            if (count.ToString() == _allText[SIX].ToString())
                return true;
            return false;
        }

        // check class time with check box
        public bool CheckChangedClassTime()
        {
            DataTable courseClassTimeTable = SetClassTimeTable(_displayingCourse, InitialClassTimeTable(new DataTable()));
            for (int rowIndex = 0; rowIndex < TABLE_ROW_AMOUNT; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < TABLE_COLUMN_AMOUNT; columnIndex++)
                    if ((bool)_classTimeTable.Rows[rowIndex][columnIndex])
                    {
                        if (!(bool)courseClassTimeTable.Rows[rowIndex][columnIndex])
                            return true;
                    }
            }
            return false;
        }

        // get class time in a list
        public List<string> CollectClassTime()
        {
            _classTime = new List<string>();
            for (int columnIndex = 1; columnIndex < TABLE_COLUMN_AMOUNT; columnIndex++)
            {
                string time = NULL_STRING;
                for (int rowIndex = 0; rowIndex < TABLE_ROW_AMOUNT; rowIndex++)
                {
                    if ((bool)_classTimeTable.Rows[rowIndex][columnIndex])
                    {
                        time += _classTimeTable.Rows[rowIndex][0] + STRING_SPACE;
                    }
                }
                _classTime.Add(time.Trim());
            }
            return _classTime;
        }

        // download all csie courses
        public bool ClickButtonDownload(string test = NULL_STRING)
        {
            if (test == NULL_STRING)
            {
                ImportCourseProgressView importCourseProgressView = new ImportCourseProgressView(_model);
                importCourseProgressView.ShowDialog();
            }
            return true;
        }

        // delete course
        public void DeleteCourse()
        {
            _model.DeleteCourse(_displayingCourse);
            ClearAllData();
        }

        // display all course in specific class and change text
        public BindingList<CourseInfoDto> ShowClassData(int index)
        {
            _class = _model.GetClassByIndex(index).ClassChineseName;
            NotifyPropertyChanged(CLASS);
            return _model.GetClassByIndex(index).CourseInfo;
        }

        // check button state
        public bool CheckClassSaveButtonState(string classChineseName)
        {
            if (classChineseName != string.Empty && !(_model.IsClassChineseNameExist(classChineseName)))
                return true;
            return false;
        }

        // click button save class
        public void ClickClassButtonSave()
        {
            Class courseInfo = new Class(string.Empty);
            courseInfo.ClassChineseName = _class.Trim();
            _model.AddNewClass(courseInfo);
            _class = string.Empty;
            NotifyPropertyChanged(CLASS);
        }

        // notify all binding
        void NotifyAllChanged()
        {
            NotifyPropertyChanged(NUMBER);
            NotifyPropertyChanged(NAME);
            NotifyPropertyChanged(STAGE);
            NotifyPropertyChanged(CREDIT);
            NotifyPropertyChanged(TEACHER);
            NotifyPropertyChanged(ASSISTANT);
            NotifyPropertyChanged(LANGUAGE);
            NotifyPropertyChanged(NOTE);
            NotifyPropertyChanged(REQUIRED);
            NotifyPropertyChanged(HOUR);
            NotifyPropertyChanged(CLASS_CHINESE_NAME);
        }

        // databinding partern
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Number
        {
            get
            {
                return this._number;
            }
            set
            {
                this._number = value;
                NotifyPropertyChanged(NUMBER);
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                NotifyPropertyChanged(NAME);
            }
        }

        public string Stage
        {
            get
            {
                return this._stage;
            }
            set
            {
                this._stage = value;
                NotifyPropertyChanged(STAGE);
            }
        }

        public string Credit
        {
            get
            {
                return this._credit;
            }
            set
            {
                this._credit = value;
                NotifyPropertyChanged(CREDIT);
            }
        }

        public string Hour
        {
            get
            {
                return this._hour;
            }
            set
            {
                this._hour = value;
                NotifyPropertyChanged(HOUR);
            }
        }

        public string Required
        {
            get
            {
                return this._required;
            }
            set
            {
                this._required = value;
                NotifyPropertyChanged(REQUIRED);
            }
        }

        public string Teacher
        {
            get
            {
                return this._teacher;
            }
            set
            {
                this._teacher = value;
                NotifyPropertyChanged(TEACHER);
            }
        }

        public string Assistant
        {
            get
            {
                return this._assistant;
            }
            set
            {
                this._assistant = value;
                NotifyPropertyChanged(ASSISTANT);
            }
        }

        public string Language
        {
            get
            {
                return this._language;
            }
            set
            {
                this._language = value;
                NotifyPropertyChanged(LANGUAGE);
            }
        }

        public string Note
        {
            get
            {
                return this._note;
            }
            set
            {
                this._note = value;
                NotifyPropertyChanged(NOTE);
            }
        }

        public string ClassChineseName
        {
            get
            {
                return this._classChineseName;
            }
            set
            {
                this._classChineseName = value;
                NotifyPropertyChanged(CLASS_CHINESE_NAME);
            }
        }

        public DataTable ClassTimeTable
        {
            get
            {
                return _classTimeTable;
            }
        }
        public CourseInfoDto DisplayingCourse
        {
            get
            {
                return _displayingCourse;
            }
        }

        public List<string> AllText
        {
            get
            {
                return _allText;
            }
        }

        public string Class
        {
            get
            {
                return _class;
            }
            set
            {
                this._class = value;
                NotifyPropertyChanged(CLASS);
            }
        }
    }
}

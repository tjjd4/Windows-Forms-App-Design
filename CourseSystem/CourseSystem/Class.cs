using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CourseSystem
{
    public class Class
    {
        BindingList<CourseInfoDto> _courseInfo;
        string _className;
        string _classChineseName;

        const string CLASS_CSIE = "CSIE";
        const string CLASS_EE = "EE";
        const string CLASS_CSIE_1 = "CSIE1";
        const string CLASS_CSIE_2 = "CSIE2";
        const string CLASS_CSIE_4 = "CSIE4";
        private const int COURSE_NUMBER_NUMBER = 0;
        private const int NAME_NUMBER = 1;
        private const int STAGE_NUMBER = 2;
        private const int CREDIT_NUMBER = 3;
        private const int HOUR_NUMBER = 4;
        private const int REQUIRED_NUMBER = 5;
        private const int TEACHER_NUMBER = 6;
        private const int SUNDAY_NUMBER = 7;
        private const int MONDAY_NUMBER = 8;
        private const int TUESDAY_NUMBER = 9;
        private const int WEDNESDAY_NUMBER = 10;
        private const int THURSDAY_NUMBER = 11;
        private const int FRIDAY_NUMBER = 12;
        private const int SATURDAY_NUMBER = 13;
        private const int CLASSROOM_NUMBER = 14;
        private const int STUDENT_NUMBER = 15;
        private const int DROP_NUMBER = 16;
        private const int ASSISTANT_NUMBER = 17;
        private const int LANGUAGE_NUMBER = 18;
        private const int SYLLABUS_NUMBER = 20;
        private const int NOTE_NUMBER = 19;
        private const int AUDIT_NUMBER = 21;
        private const int EXPERIMENT_NUMBER = 22;
        private const int COLUMN_AMOUNT = 23;

        const string COURSE_NUMBER = "課號";
        const string COURSE_NAME = "課程名稱";
        const string COURSE_STAGE = "階段";
        const string COURSE_CREDIT = "學分";
        const string COURSE_HOURS = "時數";
        const string COURSE_REQUIRED = "修";
        const string COURSE_TEACHER = "教師";
        const string COURSE_SUNDAY = "日";
        const string COURSE_MONDAY = "一";
        const string COURSE_TUESDAY = "二";
        const string COURSE_WEDNESDAY = "三";
        const string COURSE_THURSDAY = "四";
        const string COURSE_FRIDAY = "五";
        const string COURSE_SATURDAY = "六";
        const string COURSE_CLASSROOM = "教室";
        const string COURSE_STUDENT = "人";
        const string COURSE_DROP = "撤";
        const string COURSE_ASSISTANT = "教學助理";
        const string COURSE_LANGUAGE = "授課語言";
        const string COURSE_SYLLABUS = "教學大綱與進度表";
        const string COURSE_NOTE = "備註";
        const string COURSE_AUDIT = "隨班附讀";
        const string COURSE_EXPERIMENT = "實驗實習";
        const string CSIE_NAME = "資工三";
        const string EE_NAME = "電子三甲";
        const string CSIE_1_NAME = "資工一";
        const string CSIE_2_NAME = "資工二";
        const string CSIE_4_NAME = "資工四";

        public Class(string className)
        {
            if (className == CLASS_CSIE)
            {
                _courseInfo = GenerateCourseInfo(CLASS_CSIE);
                _className = CLASS_CSIE;
            }
            else if (className == CLASS_EE)
            {
                _courseInfo = GenerateCourseInfo(CLASS_EE);
                _className = CLASS_EE;
            }
            else if (className == CLASS_CSIE_1)
            {
                _courseInfo = GenerateCourseInfo(CLASS_CSIE_1);
                _className = CLASS_CSIE_1;
            }
            else if (className == CLASS_CSIE_2)
            {
                _courseInfo = GenerateCourseInfo(CLASS_CSIE_2);
                _className = CLASS_CSIE_2;
            }
            else if (className == CLASS_CSIE_4)
            {
                _courseInfo = GenerateCourseInfo(CLASS_CSIE_4);
                _className = CLASS_CSIE_4;
            }
            else if (className == "")
                _courseInfo = new BindingList<CourseInfoDto>();
            SetChineseName();
        }

        // construct courseinfo
        public BindingList<CourseInfoDto> GenerateCourseInfo(string className)
        {
            BindingList<CourseInfoDto> courseInfo = new BindingList<CourseInfoDto>();
            if (className == CLASS_CSIE)
                courseInfo = WebCrawler.GetCourseInfo(CLASS_CSIE);
            else if (className == CLASS_EE)
                courseInfo = WebCrawler.GetCourseInfo(CLASS_EE);
            else if (className == CLASS_CSIE_1)
                courseInfo = WebCrawler.GetCourseInfo(CLASS_CSIE_1);
            else if (className == CLASS_CSIE_2)
                courseInfo = WebCrawler.GetCourseInfo(CLASS_CSIE_2);
            else if (className == CLASS_CSIE_4)
                courseInfo = WebCrawler.GetCourseInfo(CLASS_CSIE_4);
            return courseInfo;
        }

        // set chinese name
        public void SetChineseName()
        {
            if (_className == CLASS_CSIE)
                _classChineseName = CSIE_NAME;
            else if (_className == CLASS_EE)
                _classChineseName = EE_NAME;
            else if (_className == CLASS_CSIE_1)
                _classChineseName = CSIE_1_NAME;
            else if (_className == CLASS_CSIE_2)
                _classChineseName = CSIE_2_NAME;
            else if (_className == CLASS_CSIE_4)
                _classChineseName = CSIE_4_NAME;
        }

        // pass by value
        public Class CopyClassByValue()
        {
            Class copyClass = new Class("");
            foreach (CourseInfoDto course in _courseInfo)
            {
                copyClass.AddCourse(course);
            }
            copyClass.ClassName = _className;
            copyClass.ClassChineseName = _classChineseName;
            return copyClass;
        }

        // return binding list to do foreach
        public BindingList<CourseInfoDto> GetBindingList()
        {
            return _courseInfo;
        }

        // get list courseInfo to reverse for deleting course
        public List<CourseInfoDto> GetList()
        {
            List<CourseInfoDto> temporarySelectedCourse = new List<CourseInfoDto>();
            foreach (CourseInfoDto course in _courseInfo)
            {
                temporarySelectedCourse.Add(course);
            }
            return temporarySelectedCourse;
        }

        // return course
        public CourseInfoDto GetCourse(int index)
        {
            return _courseInfo[index];
        }

        // add course in to class
        public void AddCourse(CourseInfoDto course)
        {
            _courseInfo.Add(course);
        }

        // delete course in to class
        public void DeleteCourse(int index)
        {
            _courseInfo.RemoveAt(index);
        }

        // set the header text
        public static void SetHeaderText(DataGridView dataGridView)
        {
            if (dataGridView.Columns.Count > COLUMN_AMOUNT)
            {
                dataGridView.Columns[COURSE_NUMBER_NUMBER + 1].HeaderText = COURSE_NUMBER;
                dataGridView.Columns[NAME_NUMBER + 1].HeaderText = COURSE_NAME;
                dataGridView.Columns[STAGE_NUMBER + 1].HeaderText = COURSE_STAGE;
                dataGridView.Columns[CREDIT_NUMBER + 1].HeaderText = COURSE_CREDIT;
                dataGridView.Columns[HOUR_NUMBER + 1].HeaderText = COURSE_HOURS;
                dataGridView.Columns[REQUIRED_NUMBER + 1].HeaderText = COURSE_REQUIRED;
                dataGridView.Columns[TEACHER_NUMBER + 1].HeaderText = COURSE_TEACHER;
                dataGridView.Columns[SUNDAY_NUMBER + 1].HeaderText = COURSE_SUNDAY;
                dataGridView.Columns[MONDAY_NUMBER + 1].HeaderText = COURSE_MONDAY;
                dataGridView.Columns[TUESDAY_NUMBER + 1].HeaderText = COURSE_TUESDAY;
                dataGridView.Columns[WEDNESDAY_NUMBER + 1].HeaderText = COURSE_WEDNESDAY;
                dataGridView.Columns[THURSDAY_NUMBER + 1].HeaderText = COURSE_THURSDAY;
                dataGridView.Columns[FRIDAY_NUMBER + 1].HeaderText = COURSE_FRIDAY;
                dataGridView.Columns[SATURDAY_NUMBER + 1].HeaderText = COURSE_SATURDAY;
                dataGridView.Columns[CLASSROOM_NUMBER + 1].HeaderText = COURSE_CLASSROOM;
                dataGridView.Columns[STUDENT_NUMBER + 1].HeaderText = COURSE_STUDENT;
                dataGridView.Columns[DROP_NUMBER + 1].HeaderText = COURSE_DROP;
                dataGridView.Columns[ASSISTANT_NUMBER + 1].HeaderText = COURSE_ASSISTANT;
                dataGridView.Columns[LANGUAGE_NUMBER + 1].HeaderText = COURSE_LANGUAGE;
                dataGridView.Columns[SYLLABUS_NUMBER + 1].HeaderText = COURSE_SYLLABUS;
                dataGridView.Columns[NOTE_NUMBER + 1].HeaderText = COURSE_NOTE;
                dataGridView.Columns[AUDIT_NUMBER + 1].HeaderText = COURSE_AUDIT;
                dataGridView.Columns[EXPERIMENT_NUMBER + 1].HeaderText = COURSE_EXPERIMENT;
            }
        }

        public BindingList<CourseInfoDto> CourseInfo
        {
            get 
            {
                return _courseInfo;
            }
        }

        public string ClassName
        {
            get 
            {
                return _className;
            }
            set
            {
                _className = value;
            }
        }

        public string ClassChineseName
        {
            get 
            {
                return _classChineseName;
            }
            set
            {
                _classChineseName = value;
            }
        }
    }
}

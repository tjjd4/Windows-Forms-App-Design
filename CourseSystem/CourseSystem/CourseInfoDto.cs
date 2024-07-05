using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseSystem
{
    public class CourseInfoDto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        const int SUNDAY_NUMBER = 7;
        const int SATURDAY_NUMBER = 13;
        const char BLANK = ' ';
        string _number;
        string _name;
        string _stage;
        string _credit;
        string _hour;
        string _requiredOrElective;
        string _teacher;
        string _classTimeSunday;
        string _classTimeMonday;
        string _classTimeTuesday;
        string _classTimeWednesday;
        string _classTimeThursday;
        string _classTimeFriday;
        string _classTimeSaturday;
        string _classroom;
        string _numberOfStudent;
        string _numberOfDropStudent;
        string _teachingAssistant;
        string _language;
        string _note;
        string _syllabus;
        string _audit;
        string _experiment;
        string _classChineseName;

        const string NUMBER = "Number";
        const string NAME = "Name";
        const string STAGE = "Stage";
        const string CREDIT = "Credit";
        const string HOURS = "Hour";
        const string REQUIRED = "RequiredOrElective";
        const string TEACHER = "Teacher";
        const string SUNDAY = "ClassTimeSunday";
        const string MONDAY = "ClassTimeMonday";
        const string TUESDAY = "ClassTimeTuesday";
        const string WEDNESDAY = "ClassTimeWednesday";
        const string THURSDAY = "ClassTimeThrusday";
        const string FRIDAY = "ClassTimeFriday";
        const string SATURDAY = "ClassTimeSaturday";
        const string CLASSROOM = "Classroom";
        const string STUDENT = "NumberOfStudent";
        const string DROP = "NumberOfDropStudent";
        const string ASSISTANT = "TeachingAssistant";
        const string LANGUAGE = "Language";
        const string SYLLABUS = "Syllabus";
        const string NOTE = "Note";
        const string AUDIT = "Audit";
        const string EXPERIMENT = "Experiment";
        const string CLASS_CHINESE_NAME = "ClassChineseName";

        public CourseInfoDto(string number, string name, string stage, string credit, string hour,
            string requiredOrElective, string teacher, string classTimeSunday, string classTimeMonday, string classTimeTuesday,
            string classTimeWednesday, string classTimeThursday, string classTimeFriday, string classTimeSaturday, string classroom,
            string numberOfStudent, string numberOfDropStudent, string teachingAssistant, string language,
            string note, string syllabus, string audit, string experiment, string classChineseName)
        {
            _number = number;
            _name = name;
            _stage = stage;
            _credit = credit;
            _hour = hour;
            _requiredOrElective = requiredOrElective;
            _teacher = teacher;
            _classTimeSunday = classTimeSunday;
            _classTimeMonday = classTimeMonday;
            _classTimeTuesday = classTimeTuesday;
            _classTimeWednesday = classTimeWednesday;
            _classTimeThursday = classTimeThursday;
            _classTimeFriday = classTimeFriday;
            _classTimeSaturday = classTimeSaturday;
            _classroom = classroom;
            _numberOfStudent = numberOfStudent;
            _numberOfDropStudent = numberOfDropStudent;
            _teachingAssistant = teachingAssistant;
            _language = language;
            _syllabus = syllabus;
            _note = note;
            _audit = audit;
            _experiment = experiment;
            _classChineseName = classChineseName;
        }

        // transfer data to array
        public string[] GetInRow()
        {
            string[] dataInRow =
            { 
                Number, Name, Stage, Credit, Hour, RequiredOrElective, Teacher, ClassTimeSunday, ClassTimeMonday, ClassTimeTuesday,
                ClassTimeWednesday, ClassTimeThursday, ClassTimeFriday, ClassTimeSaturday, Classroom, NumberOfStudent, NumberOfDropStudent,
                TeachingAssistant, Language, Syllabus, Note, Audit, Experiment, ClassChineseName };
            return dataInRow;
        }

        // check are they same course
        public static bool CheckSameCourse(CourseInfoDto courseInfo1, CourseInfoDto courseInfo2)
        {
            int index = 0;
            foreach (string data in courseInfo1.GetInRow())
            {
                if (data != courseInfo2.GetInRow()[index])
                    return false;
                index++;
            }
            return true;
        }

        // check course number
        public static bool CheckCourseNumber(CourseInfoDto courseInfo1, CourseInfoDto courseInfo2)
        {
            if (courseInfo1.GetInRow()[0] == courseInfo2.GetInRow()[0])
                return true;
            else
                return false;
        }

        // check course number with one input is integer
        public static bool CheckCourseNumber(string courseNumber, CourseInfoDto courseInfo)
        {
            int a;
            if (int.TryParse(courseNumber, out a) && int.TryParse(courseInfo.GetInRow()[0], out a))
            {
                if (int.Parse(courseNumber) == int.Parse(courseInfo.GetInRow()[0]))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        // check course name
        public static bool CheckCourseName(CourseInfoDto courseInfo1, CourseInfoDto courseInfo2)
        {
            if (courseInfo1.GetInRow()[1] == courseInfo2.GetInRow()[1])
                return true;
            else
                return false;
        }

        // check course class time
        public static bool CheckCourseClassTime(CourseInfoDto courseInfo1, CourseInfoDto courseInfo2)
        {
            for (int index = SUNDAY_NUMBER; index <= SATURDAY_NUMBER; index++)
            {
                char[] classTime1 = courseInfo1.GetInRow()[index].ToCharArray();
                char[] classTime2 = courseInfo2.GetInRow()[index].ToCharArray();
                foreach (char letter1 in classTime1)
                {
                    foreach (char letter2 in classTime2)
                    {
                        if (letter1 != BLANK && letter2 != BLANK && letter1 == letter2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // check class name
        public static bool CheckClassChineseName(CourseInfoDto courseInfo1, CourseInfoDto courseInfo2)
        {
            if (courseInfo1.ClassChineseName == courseInfo2.ClassChineseName)
                return true;
            return false;
        }

        // databinding partern
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
                NotifyPropertyChanged(HOURS);
            }
        }

        public string RequiredOrElective
        {
            get
            {
                return this._requiredOrElective;
            }
            set
            {
                this._requiredOrElective = value;
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

        public string ClassTimeSunday
        {
            get
            {
                return this._classTimeSunday;
            }
            set
            {
                this._classTimeSunday = value;
                NotifyPropertyChanged(SUNDAY);
            }
        }

        public string ClassTimeMonday
        {
            get
            {
                return this._classTimeMonday;
            }
            set
            {
                this._classTimeMonday = value;
                NotifyPropertyChanged(MONDAY);
            }
        }

        public string ClassTimeTuesday
        {
            get
            {
                return this._classTimeTuesday;
            }
            set
            {
                this._classTimeTuesday = value;
                NotifyPropertyChanged(TUESDAY);
            }
        }

        public string ClassTimeWednesday
        {
            get
            {
                return this._classTimeWednesday;
            }
            set
            {
                this._classTimeWednesday = value;
                NotifyPropertyChanged(WEDNESDAY);
            }
        }

        public string ClassTimeThursday
        {
            get
            {
                return this._classTimeThursday;
            }
            set
            {
                this._classTimeThursday = value;
                NotifyPropertyChanged(THURSDAY);
            }
        }

        public string ClassTimeFriday
        {
            get
            {
                return this._classTimeFriday;
            }
            set
            {
                this._classTimeFriday = value;
                NotifyPropertyChanged(FRIDAY);
            }
        }

        public string ClassTimeSaturday
        {
            get
            {
                return this._classTimeSaturday;
            }
            set
            {
                this._classTimeSaturday = value;
                NotifyPropertyChanged(SATURDAY);
            }
        }

        public string Classroom
        {
            get
            {
                return this._classroom;
            }
            set
            {
                this._classroom = value;
                NotifyPropertyChanged(CLASSROOM);
            }
        }

        public string NumberOfStudent
        {
            get
            {
                return this._numberOfStudent;
            }
            set
            {
                this._numberOfStudent = value;
                NotifyPropertyChanged(STUDENT);
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

        public string NumberOfDropStudent
        {
            get
            {
                return this._numberOfDropStudent;
            }
            set
            {
                this._numberOfDropStudent = value;
                NotifyPropertyChanged(DROP);
            }
        }

        public string TeachingAssistant
        {
            get
            {
                return this._teachingAssistant;
            }
            set
            {
                this._teachingAssistant = value;
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

        public string Syllabus
        {
            get
            {
                return this._syllabus;
            }
            set
            {
                this._syllabus = value;
                NotifyPropertyChanged(SYLLABUS);
            }
        }

        public string Audit
        {
            get
            {
                return this._audit;
            }
            set
            {
                this._audit = value;
                NotifyPropertyChanged(AUDIT);
            }
        }

        public string Experiment
        {
            get
            {
                return this._experiment;
            }
            set
            {
                this._experiment = value;
                NotifyPropertyChanged(EXPERIMENT);
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
    }
}

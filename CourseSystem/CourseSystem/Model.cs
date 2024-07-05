using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Threading;

namespace CourseSystem
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private BindingList<Class> _courseInfos = new BindingList<Class>();
        private BindingList<Class> _selectingCourseInfos = new BindingList<Class>();
        Class _selectedCourseInfo = new Class("");
        Class _allCourses = new Class("");
        Dictionary<string, int> _classNameToClassIndex = new Dictionary<string, int>();

        const int NUMBER_CONFLICT = 0;
        const int NAME_CONFLICT = 1;
        const int CLASS_TIME_CONFLICT = 2;
        const string UPPER_QUOTATION = "「";
        const string LOWER_QUOTATION = "」 ";
        const string NEW_LINE = "\n";
        const int MESSAGE_LENGTH = 3;
        const string CLASS_CSIE = "CSIE";
        const string CLASS_EE = "EE";

        public Model()
        {
            _courseInfos = GenerateClasses();
            _selectingCourseInfos = GenerateClasses();
            SetDictionary();
            GenerateAllCourses();
        }

        // set dictionary
        public void SetDictionary()
        {
            _classNameToClassIndex.Add(CLASS_CSIE, 0);
            _classNameToClassIndex.Add(CLASS_EE, 1);
        }

        // generate classes
        public BindingList<Class> GenerateClasses()
        {
            BindingList<Class> courseInfos = new BindingList<Class>();
            courseInfos.Add(new Class(CLASS_CSIE));
            courseInfos.Add(new Class(CLASS_EE));
            return courseInfos;
        }

        // get all courses in a binding list
        public void GenerateAllCourses()
        {
            _allCourses = new Class("");
            foreach (var courseInfo in _courseInfos)
            {
                foreach (CourseInfoDto course in courseInfo.CourseInfo)
                {
                    _allCourses.AddCourse(course);
                }
            }
        }

        // download a class
        public void DownloadSingleClass(string className)
        {
            if (new Class(className).CourseInfo.Count != 0)
            {
                _courseInfos.Add(new Class(className));
                ConstructSelectingTable();
                GenerateAllCourses();
                NotifyObserver();
            }
        }

        public BindingList<Class> CourseInfos
        {
            get
            {
                return _courseInfos;
            }
        }

        public BindingList<Class> SelectingCourseInfos
        {
            get
            {
                return _selectingCourseInfos;
            }
        }

        public Class SelectedCourseInfo
        {
            get
            {
                return _selectedCourseInfo;
            }
        }

        public Class AllCourses
        {
            get
            {
                return _allCourses;
            }
        }

        public Dictionary<string, int> ClassNameToClassIndex
        {
            get
            {
                return _classNameToClassIndex;
            }
        }

        // add course
        public List<string> AddCourses(List<List<int>> selectIndex)
        {
            List<string> message = new List<string>();
            for (int _ = 0; _ < MESSAGE_LENGTH; _++)
            {
                message.Add("");
            }
            int courseIndex = 0;
            foreach (var classIndex in selectIndex)
            {
                foreach (int index in classIndex)
                {
                    if (_selectedCourseInfo != null)
                    {
                        foreach (var courseInfo in _selectedCourseInfo.GetBindingList())
                        {
                            if (CourseInfoDto.CheckCourseNumber(courseInfo, _selectingCourseInfos[courseIndex].GetCourse(index)))
                                message[NUMBER_CONFLICT] += CreateMessage(courseInfo, _selectingCourseInfos[courseIndex].GetCourse(index));
                            if (CourseInfoDto.CheckCourseName(courseInfo, _selectingCourseInfos[courseIndex].GetCourse(index)))
                                message[NAME_CONFLICT] += CreateMessage(courseInfo, _selectingCourseInfos[courseIndex].GetCourse(index));
                            if (CourseInfoDto.CheckCourseClassTime(courseInfo, _selectingCourseInfos[courseIndex].GetCourse(index)))
                                message[CLASS_TIME_CONFLICT] += CreateMessage(courseInfo, _selectingCourseInfos[courseIndex].GetCourse(index));
                        }
                    }
                }
                courseIndex++;
            }
            SaveCourse(message, selectIndex);
            return message;
        }

        // construct error message
        public string CreateMessage(CourseInfoDto courseInfo1, CourseInfoDto courseInfo2)
        {
            return UPPER_QUOTATION + courseInfo1.GetInRow()[0].ToString() + courseInfo1.GetInRow()[1].ToString() + LOWER_QUOTATION + UPPER_QUOTATION + courseInfo2.GetInRow()[0].ToString() + courseInfo2.GetInRow()[1].ToString() + LOWER_QUOTATION + NEW_LINE;
        }

        // check message to decide add or not
        public void SaveCourse(List<string> message, List<List<int>> selectIndex)
        {
            if (message[NUMBER_CONFLICT] == "" && message[NAME_CONFLICT] == "" && message[CLASS_TIME_CONFLICT] == "")
            {
                int courseIndex = 0;
                foreach (var classIndex in selectIndex)
                {
                    foreach (int index in classIndex)
                    {
                        _selectedCourseInfo.AddCourse(_selectingCourseInfos[courseIndex].GetCourse(index));
                    }
                    classIndex.Reverse();
                    foreach (int index in classIndex)
                    {
                        _selectingCourseInfos[courseIndex].DeleteCourse(index);
                    }
                    courseIndex++;
                }
            }
        }

        // delete selected course
        public void DeleteSelectedCourse(int deleteIndex)
        {
            _selectedCourseInfo.DeleteCourse(deleteIndex);
            if (_selectedCourseInfo != null)
            {
                ConstructSelectingTable();
            }
            NotifyObserver();
        }

        // reconstruct table
        public void ConstructSelectingTable()
        {
            CopyCourseInfos();
            List<CourseInfoDto> temporarySelectedCourseInfo = _selectedCourseInfo.GetList();
            temporarySelectedCourseInfo.Reverse();
            foreach (CourseInfoDto selectedCourse in temporarySelectedCourseInfo)
            {
                int courseIndex = 0;
                foreach (var courseInfo in _courseInfos)
                {
                    int index = 0;
                    foreach (CourseInfoDto course in courseInfo.GetBindingList())
                    {
                        if (CourseInfoDto.CheckSameCourse(course, selectedCourse))
                            _selectingCourseInfos[courseIndex].DeleteCourse(index);
                        index++;
                    }
                    courseIndex++;
                }
            }
        }

        // copy to selecting courseInfos from courseInfos
        public void CopyCourseInfos()
        {
            int index = 0;
            _selectingCourseInfos = new BindingList<Class>();
            foreach (Class courseInfo in _courseInfos)
            {
                _selectingCourseInfos.Add(_courseInfos[index].CopyClassByValue());
                index++;
            }
        }

        // check changed course number
        public bool CheckChangedCourseNumber(string courseNumber)
        {
            foreach (Class courseInfo in _courseInfos)
            {
                foreach (CourseInfoDto course in courseInfo.GetBindingList())
                {
                    if (CourseInfoDto.CheckCourseNumber(courseNumber, course))
                        return true;
                }
            }
            return false;
        }

        // modify course
        public void ModifyCourse(CourseInfoDto modifyCourse, CourseInfoDto displayingCourse)
        {
            int classIndex = 0;
            bool found = false;
            foreach (var courseInfo in _courseInfos)
            {
                int courseIndex = 0;
                foreach (CourseInfoDto course in courseInfo.GetBindingList())
                {
                    if (CourseInfoDto.CheckSameCourse(course, displayingCourse))
                    {
                        if (CourseInfoDto.CheckClassChineseName(course, modifyCourse))
                            _courseInfos[classIndex].CourseInfo[courseIndex] = modifyCourse;
                        else
                        {
                            _courseInfos[classIndex].DeleteCourse(courseIndex);
                            AddNewCourse(modifyCourse);
                        }
                        break;
                    }
                    courseIndex++;
                }
                if (found)
                    break;
                classIndex++;
            }
            ModifySelectedCourse(modifyCourse, displayingCourse);
            ConstructSelectingTable();
            GenerateAllCourses();
            NotifyObserver();
        }

        // check if selected course need to modify
        public void ModifySelectedCourse(CourseInfoDto modifyCourse, CourseInfoDto displayingCourse)
        {
            int index = 0;
            foreach (CourseInfoDto course in _selectedCourseInfo.GetBindingList())
            {
                if (CourseInfoDto.CheckSameCourse(course, displayingCourse))
                {
                    _selectedCourseInfo.CourseInfo[index] = modifyCourse;
                    return;
                }
                index++;
            }
        }

        // add new course
        public void AddNewCourse(CourseInfoDto course)
        {
            _courseInfos[FindClassIndexByClassChineseName(course.ClassChineseName)].AddCourse(course);
            ConstructSelectingTable();
            GenerateAllCourses();
            NotifyObserver();
        }

        // find class index by course's class chinese name
        public int FindClassIndexByClassChineseName(string classChineseName)
        {
            int classIndex = 0;
            foreach (Class courseInfo in _courseInfos)
            {
                if (classChineseName == courseInfo.ClassChineseName)
                    return classIndex;
                classIndex++;
            }
            return 0;
        }

        // delete course
        public void DeleteCourse(CourseInfoDto deleteCourse)
        {
            int classIndex = 0;
            foreach (Class courseInfo in _courseInfos)
            {
                int courseIndex = 0;
                foreach (CourseInfoDto course in courseInfo.CourseInfo)
                {
                    if (CourseInfoDto.CheckSameCourse(course, deleteCourse))
                    {
                        _courseInfos[classIndex].DeleteCourse(courseIndex);
                        DeleteCourseInSelected(deleteCourse);
                        ConstructSelectingTable();
                        GenerateAllCourses();
                        NotifyObserver();
                        return;
                    }
                    courseIndex++;
                }
                classIndex++;
            }
        }

        // check if selected course need to delete
        public void DeleteCourseInSelected(CourseInfoDto deleteCourse)
        {
            int index = 0;
            foreach (CourseInfoDto course in _selectedCourseInfo.GetBindingList())
            {
                if (CourseInfoDto.CheckSameCourse(course, deleteCourse))
                {
                    _selectedCourseInfo.DeleteCourse(index);
                    return;
                }
                index++;
            }
        }

        // return class by index
        public Class GetClassByIndex(int index)
        {
            return _courseInfos[index];
        }

        // check class is exist or not
        public bool IsClassChineseNameExist(string classChineseName)
        {
            foreach (Class courseInfo in _courseInfos)
            {
                if (courseInfo.ClassChineseName == classChineseName)
                    return true;
            }
            return false;
        }

        // add new class
        public void AddNewClass(Class courseInfo)
        {
            _courseInfos.Add(courseInfo);
            ConstructSelectingTable();
            GenerateAllCourses();
            NotifyObserver();
        }

        // observer partern
        void NotifyObserver()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}

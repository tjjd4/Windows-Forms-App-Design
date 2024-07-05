using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using HtmlAgilityPack;

namespace CourseSystem
{
    public class WebCrawler
    {
        const string COURSE_ADDRESS_CSIE = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
        const string COURSE_ADDRESS_EE = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2423";
        const string COURSE_ADDRESS_CSIE_1 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2676";
        const string COURSE_ADDRESS_CSIE_2 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2550";
        const string COURSE_ADDRESS_CSIE_4 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2314";
        const string CLASS_CSIE = "CSIE";
        const string CLASS_CSIE_1 = "CSIE1";
        const string CLASS_CSIE_2 = "CSIE2";
        const string CLASS_CSIE_4 = "CSIE4";
        const string CLASS_EE = "EE";
        private const string BODY_TABLE = "//body/table";
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
        const string CSIE_NAME = "資工三";
        const string EE_NAME = "電子三甲";
        const string CSIE_1_NAME = "資工一";
        const string CSIE_2_NAME = "資工二";
        const string CSIE_4_NAME = "資工四";

        // get course info from website
        public static BindingList<CourseInfoDto> GetCourseInfo(string className)
        {
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document;
            if (className == CLASS_CSIE)
                document = webClient.Load(COURSE_ADDRESS_CSIE);
            else if (className == CLASS_EE)
                document = webClient.Load(COURSE_ADDRESS_EE);
            else if (className == CLASS_CSIE_1)
                document = webClient.Load(COURSE_ADDRESS_CSIE_1);
            else if (className == CLASS_CSIE_2)
                document = webClient.Load(COURSE_ADDRESS_CSIE_2);
            else if (className == CLASS_CSIE_4)
                document = webClient.Load(COURSE_ADDRESS_CSIE_4);
            else
                return new BindingList<CourseInfoDto>();
            BindingList<CourseInfoDto> courseInfoDtos = new BindingList<CourseInfoDto>();
            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(BODY_TABLE);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;
            nodeTableRow = RemoveExtraData(nodeTableRow);
            foreach (var node in nodeTableRow)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                nodeTableDatas.RemoveAt(0);// 移除 #text
                courseInfoDtos.Add(CourseRemoveSpace(nodeTableDatas, className));
            }
            return courseInfoDtos;
        }

        // remove extra data
        public static HtmlNodeCollection RemoveExtraData(HtmlNodeCollection nodeTableRow)
        {
            nodeTableRow.RemoveAt(0);// 移除 tbody
            nodeTableRow.RemoveAt(0);// 移除 <tr>資工三
            nodeTableRow.RemoveAt(0);// 移除 table header
            nodeTableRow.RemoveAt(nodeTableRow.Count - 1);// 移除 <tr>小計
            return nodeTableRow;
        }

        //remove space
        public static CourseInfoDto CourseRemoveSpace(HtmlNodeCollection nodeTableDatas, string className)
        {
            CourseInfoDto courseInfo = new CourseInfoDto(
                    nodeTableDatas[COURSE_NUMBER_NUMBER].InnerText.Trim(), nodeTableDatas[NAME_NUMBER].InnerText.Trim(),// number name
                    nodeTableDatas[STAGE_NUMBER].InnerText.Trim(), nodeTableDatas[CREDIT_NUMBER].InnerText.Trim(),// stage credit
                    nodeTableDatas[HOUR_NUMBER].InnerText.Trim(), nodeTableDatas[REQUIRED_NUMBER].InnerText.Trim(),// hour required/elective
                    nodeTableDatas[TEACHER_NUMBER].InnerText.Trim(),// teacher
                    nodeTableDatas[SUNDAY_NUMBER].InnerText.Trim(), nodeTableDatas[MONDAY_NUMBER].InnerText.Trim(),// Sun Mon
                    nodeTableDatas[TUESDAY_NUMBER].InnerText.Trim(), nodeTableDatas[WEDNESDAY_NUMBER].InnerText.Trim(),// Tue Wed
                    nodeTableDatas[THURSDAY_NUMBER].InnerText.Trim(), nodeTableDatas[FRIDAY_NUMBER].InnerText.Trim(),// Thu Fri
                    nodeTableDatas[SATURDAY_NUMBER].InnerText.Trim(),// Sat
                    nodeTableDatas[CLASSROOM_NUMBER].InnerText.Trim(), nodeTableDatas[STUDENT_NUMBER].InnerText.Trim(),// classroom numberOfStudent
                    nodeTableDatas[DROP_NUMBER].InnerText.Trim(), nodeTableDatas[ASSISTANT_NUMBER].InnerText.Trim(),// numberOfDropStudent TA
                    nodeTableDatas[LANGUAGE_NUMBER].InnerText.Trim(), nodeTableDatas[SYLLABUS_NUMBER].InnerText.Trim(),// language syllabus
                    nodeTableDatas[NOTE_NUMBER].InnerText.Trim(), nodeTableDatas[AUDIT_NUMBER].InnerText.Trim(),// note audit
                    nodeTableDatas[EXPERIMENT_NUMBER].InnerText.Trim(), GetClassChineseNameByClassName(className));// experiment
            return courseInfo;
        }

        // get chinese name
        public static string GetClassChineseNameByClassName(string className)
        {
            if (className == CLASS_CSIE)
                return CSIE_NAME;
            else if (className == CLASS_EE)
                return EE_NAME;
            else if (className == CLASS_CSIE_1)
                return CSIE_1_NAME;
            else if (className == CLASS_CSIE_2)
                return CSIE_2_NAME;
            else if (className == CLASS_CSIE_4)
                return CSIE_4_NAME;
            else
                return string.Empty;
        }
    }
}

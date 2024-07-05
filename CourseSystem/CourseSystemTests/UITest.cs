using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem.Tests
{
    [TestClass()]
    public class UITest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_VIEW = "StartUpView";

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "CourseSystem";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\CourseSystem"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "CourseSystem.exe");
            _robot = new Robot(targetAppPath, START_UP_VIEW);
        }

        // clean up
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // test click select
        [TestMethod()]
        public void TestOpenSelect()
        {
            _robot.ClickButton("Course Select System");
            _robot.AssertEnable("Course Select System", false);
            _robot.SwitchTo("SelectView");
            _robot.ClickButton("關閉");
            _robot.SwitchTo("StartUpView");
            _robot.AssertEnable("Course Select System", true);
        }

        // test click management
        [TestMethod()]
        public void TestOpenManagement()
        {
            _robot.ClickButton("Course Management System");
            _robot.AssertEnable("Course Management System", false);
            _robot.SwitchTo("ManagementView");
            _robot.ClickButton("關閉");
            _robot.SwitchTo("StartUpView");
            _robot.AssertEnable("Course Management System", true);
        }

        // test
        [TestMethod()]
        public void TestSelectAndDeleteCourse()
        {
            _robot.ClickButton("Course Select System");
            _robot.SwitchTo("SelectView");
            _robot.ClickButton("查看選課結果");
            _robot.ClickDataGridViewCellBy("_dataGridViewCSIE", 2, "選");
            _robot.ClickTabControl("電子三甲");
            _robot.ClickDataGridViewCellBy("_dataGridViewEE", 5, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.SwitchTo("SelectResultView");
            _robot.AssertDataGridViewRowCountBy("_dataGridViewResult", 2);
            _robot.ClickDataGridViewCellBy("_dataGridViewResult", 0, "退");
            _robot.ClickDataGridViewCellBy("_dataGridViewResult", 0, "退");
            _robot.AssertDataGridViewRowCountBy("_dataGridViewResult", 0);
        }

        // test
        [TestMethod()]
        public void TestSelectCourse()
        {
            _robot.ClickButton("Course Select System");
            _robot.SwitchTo("SelectView");
            _robot.ClickButton("查看選課結果");
            _robot.ClickDataGridViewCellBy("_dataGridViewCSIE", 2, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.ClickDataGridViewCellBy("_dataGridViewCSIE", 5, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.ClickTabControl("電子三甲");
            _robot.ClickDataGridViewCellBy("_dataGridViewEE", 8, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowCountBy("_dataGridViewEE", 25);
            _robot.ClickTabControl("資工三");
            _robot.AssertDataGridViewRowCountBy("_dataGridViewCSIE", 10);
        }

        // test
        [TestMethod()]
        public void TestChangeCourseInfo()
        {
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo("ManagementView");
            _robot.ClickListBox("_listBox", "視窗程式設計");
            _robot.InputKeyById("_textBoxTeacher", "測試");
            _robot.AssertEnable("儲存", true);
        }

        // test
        [TestMethod()]
        public void TestEmptyData()
        {
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo("ManagementView");
            _robot.ClickListBox("_listBox", "視窗程式設計");
            _robot.InputKeyById("_textBoxTeacher", "");
            _robot.AssertEnable("儲存", false);
        }

        // test
        [TestMethod()]
        public void TestChangedClass()
        {
            _robot.ClickButton("Course Select System");
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo("ManagementView");
            _robot.ClickListBox("_listBox", "視窗程式設計");
            _robot.InputKeyById("_textBoxNumber", "270915");
            _robot.InputKeyById("_textBoxName", "物件導向程式設計");
            _robot.InputKeyById("_textBoxCredit", "2");
            _robot.SelectComboBox("_comboBoxHour", "2");
            _robot.SelectComboBox("_comboBoxClassName", "電子三甲");
            _robot.ClickDataGridViewCellBy("_dataGridViewTime", 6, "四");
            _robot.ClickDataGridViewCellBy("_dataGridViewTime", 3, "四");
            _robot.ClickDataGridViewCellBy("_dataGridViewTime", 2, "四");
            _robot.ClickDataGridViewCellBy("_dataGridViewTime", 2, "一");
            _robot.ClickDataGridViewCellBy("_dataGridViewTime", 2, "二");
            _robot.ClickButton("儲存");
            _robot.ClickListBox("_listBox", "物件導向程式設計");
            _robot.SwitchTo("SelectView");
            _robot.ClickTabControl("電子三甲");
            _robot.AssertDataGridViewRowCountBy("_dataGridViewEE", 26);
            _robot.AssertDataGridViewData("_dataGridViewEE", 25, "課程名稱", "物件導向程式設計");
            _robot.AssertDataGridViewData("_dataGridViewEE", 25, "學分", "2");
            _robot.AssertDataGridViewData("_dataGridViewEE", 25, "時數", "2");
            _robot.AssertDataGridViewData("_dataGridViewEE", 25, "一", "3");
            _robot.AssertDataGridViewData("_dataGridViewEE", 25, "二", "3");
        }

        // test
        [TestMethod()]
        public void TestAddCourse()
        {
            _robot.ClickButton("Course Select System");
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo("ManagementView");
            _robot.ClickButton("新增課程");
            _robot.AssertText("_buttonSave", "新增");
            _robot.InputKeyById("_textBoxNumber", "270915");
            _robot.InputKeyById("_textBoxName", "新課程");
            _robot.InputKeyById("_textBoxStage", "2");
            _robot.InputKeyById("_textBoxCredit", "2");
            _robot.InputKeyById("_textBoxTeacher", "我");
            _robot.SelectComboBox("_comboBoxHour", "2");
            _robot.SelectComboBox("_comboBoxClassName", "電子三甲");
            _robot.ClickDataGridViewCellBy("_dataGridViewTime", 2, "一");
            _robot.ClickDataGridViewCellBy("_dataGridViewTime", 2, "二");
            _robot.ClickButton("新增");
            _robot.ClickListBox("_listBox", "新課程");
            _robot.AssertText("_textBoxName", "新課程");
            _robot.SwitchTo("SelectView");
            _robot.ClickTabControl("電子三甲");
            _robot.AssertDataGridViewData("_dataGridViewEE", 25, "課程名稱", "新課程");
        }

        // test
        [TestMethod()]
        public void TestImportClasses()
        {
            _robot.ClickButton("Course Select System");
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo("ManagementView");
            _robot.ClickButton("匯入資工系全部課程");
            _robot.ClickButtonPrecision("ImportCourseProgressView", "關閉");
            _robot.ClickListBox("_listBox", "微積分");
            _robot.AssertText("_textBoxName", "微積分");
            _robot.ClickListBox("_listBox", "微算機系統");
            _robot.AssertText("_textBoxName", "微算機系統");
            _robot.ClickListBox("_listBox", "軟體工程");
            _robot.AssertText("_textBoxName", "軟體工程");
            _robot.SwitchTo("SelectView");
            _robot.ClickTabControl("資工一");
            _robot.ClickTabControl("資工二");
            _robot.ClickTabControl("資工四");
        }

        // test
        [TestMethod()]
        public void TestAddClass()
        {
            _robot.ClickButton("Course Select System");
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo("ManagementView");
            _robot.ClickTabControl("班級管理");
            _robot.AssertEnable("新增班級", true);
            _robot.AssertEnable("新增", false);
            _robot.ClickButton("新增班級");
            _robot.InputKeyById("_textBoxClass", "新班級");
            _robot.AssertEnable("新增班級", false);
            _robot.AssertEnable("新增", true);
            _robot.ClickButton("新增");
            _robot.ClickListBox("_listBoxClass", "新班級");
            _robot.AssertText("_textBoxClass", "新班級");
            _robot.SwitchTo("SelectView");
            _robot.ClickTabControl("新班級");
        }
    }
}

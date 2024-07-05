using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace CourseSystem.Tests
{
    [TestClass()]
    public class ManagementPresentationModelTests
    {
        Model model;
        ManagementPresentationModel managementPresentationModel;

        const int TABLE_ROW_AMOUNT = 14;
        const int TABLE_COLUMN_AMOUNT = 8;
        const int SIXTH_COURSE = 5;
        const string NULL_STRING = "";

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            managementPresentationModel = new ManagementPresentationModel(model);
        }

        // test lock all boxes enable
        [TestMethod()]
        public void TestLockAllStatus()
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Controls.Add(new TextBox());
            groupBox.Controls.Add(new ComboBox());
            groupBox.Controls.Add(new TextBox());
            managementPresentationModel.LockAllStatus(groupBox);
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox || control is ComboBox)
                    Assert.IsFalse(control.Enabled);
            }
        }

        // test unlock all boxes enable
        [TestMethod()]
        public void TestUnlockAllStatus()
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Controls.Add(new TextBox());
            groupBox.Controls.Add(new ComboBox());
            groupBox.Controls.Add(new TextBox());
            managementPresentationModel.UnlockAllStatus(groupBox);
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox || control is ComboBox)
                    Assert.IsTrue(control.Enabled);
            }
        }

        // test fetch data from model
        [TestMethod()]
        public void TestGetAllCourses()
        {
            Assert.IsNotNull(managementPresentationModel.GetAllCourses());
        }

        // test show course data
        [TestMethod()]
        public void TestShowCourseData()
        {
            managementPresentationModel.ShowCourseData(5);
            Assert.AreEqual("計算機網路", managementPresentationModel.Name);
            Assert.AreEqual("3.0", managementPresentationModel.Credit);
        }

        // test create a class time dataTable column part
        [TestMethod()]
        public void TestInitialClassTimeTable()
        {
            DataTable dataTable = new DataTable();
            dataTable = managementPresentationModel.InitialClassTimeTable(dataTable);
            Assert.AreEqual(8, dataTable.Columns.Count);
        }

        // test create a class time dataTable row part
        [TestMethod()]
        public void TestInitialRow()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("節數", typeof(string)));
            dataTable.Columns.Add(new DataColumn("日", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("一", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("二", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("三", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("四", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("五", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("六", typeof(bool)));
            dataTable = managementPresentationModel.InitialRow(dataTable);
            Assert.AreEqual(14, dataTable.Rows.Count);
            Assert.AreEqual("N", dataTable.Rows[4][0]);
            Assert.AreEqual("D", dataTable.Rows[13][0]);
        }

        // test clear the dataTable
        [TestMethod()]
        public void TestClearTable()
        {
            managementPresentationModel.ClearTable();
            for (int rowIndex = 0; rowIndex < TABLE_ROW_AMOUNT; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < TABLE_COLUMN_AMOUNT; columnIndex++)
                    Assert.AreEqual("False", managementPresentationModel.ClassTimeTable.Rows[rowIndex][columnIndex].ToString());
            }
        }

        // test set up class time table with given course
        [TestMethod()]
        public void TestSetClassTimeTable()
        {
            CourseInfoDto course = new CourseInfoDto(NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, "1 D", NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
                NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING);
            managementPresentationModel.SetClassTimeTable(course);
            Assert.AreEqual("True", managementPresentationModel.ClassTimeTable.Rows[0][1].ToString());
            Assert.AreEqual("True", managementPresentationModel.ClassTimeTable.Rows[13][1].ToString());
            Assert.AreEqual("False", managementPresentationModel.ClassTimeTable.Rows[12][1].ToString());
            Assert.AreEqual("False", managementPresentationModel.ClassTimeTable.Rows[1][1].ToString());
        }

        // test set up class time table with given course and create a dataTable
        [TestMethod()]
        public void TestSetClassTimeTable1()
        {
            CourseInfoDto course = new CourseInfoDto(NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
    NULL_STRING, NULL_STRING, NULL_STRING, "1 D", NULL_STRING, NULL_STRING, NULL_STRING,
    NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING,
    NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING);
            DataTable dataTable = managementPresentationModel.SetClassTimeTable(course, managementPresentationModel.InitialClassTimeTable(new DataTable()));
            Assert.AreEqual("True", dataTable.Rows[0][1].ToString());
            Assert.AreEqual("True", dataTable.Rows[13][1].ToString());
            Assert.AreEqual("False", dataTable.Rows[12][1].ToString());
            Assert.AreEqual("False", dataTable.Rows[1][1].ToString());
        }

        // test clear the showing data
        [TestMethod()]
        public void TestClearAllData()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            managementPresentationModel.ClearAllData();
            Assert.AreEqual("", managementPresentationModel.Number);
            Assert.AreEqual("", managementPresentationModel.ClassChineseName);

        }

        // test change dataTable with class time to a list of string
        [TestMethod()]
        public void TestCollectClassTime()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            List<string> classTime = managementPresentationModel.CollectClassTime();
            Assert.AreEqual("3 4", classTime[1]);
            Assert.AreEqual("2", classTime[2]);
            Assert.AreEqual("", classTime[6]);
        }

        // test save data into model
        [TestMethod()]
        public void TestSaveDataInCourse()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            CourseInfoDto course = managementPresentationModel.SaveDataInCourse();
            Assert.AreEqual("計算機網路", course.Name);
        }

        // test save and add course
        [TestMethod()]
        public void TestClickButtonSave()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            managementPresentationModel.ClickButtonSave("編輯課程");
            Assert.AreEqual(37, managementPresentationModel.GetAllCourses().GetBindingList().Count);
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            managementPresentationModel.ClickButtonSave("新增課程");
            Assert.AreEqual(38, managementPresentationModel.GetAllCourses().GetBindingList().Count);
        }

        // test check data change
        [TestMethod()]
        public void TestCheckDataChanged()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            List<string> allText = new List<string>();
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Number);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Name);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Stage);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Credit);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Teacher);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].RequiredOrElective);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Hour);
            allText.Add("資工三");
            managementPresentationModel.SetData(allText);
            Assert.IsFalse(managementPresentationModel.CheckDataChanged());
            allText[7] = ("電子三甲");
            managementPresentationModel.SetData(allText);
            Assert.IsTrue(managementPresentationModel.CheckDataChanged());
        }

        // check data is empty or not
        [TestMethod()]
        public void TestIsDataEmpty()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            List<string> allText = new List<string>();
            allText.Add(" ");
            allText.Add(" ");
            allText.Add(" ");
            allText.Add(" ");
            allText.Add(" ");
            allText.Add(" ");
            allText.Add(" ");
            allText.Add("");
            managementPresentationModel.SetData(allText);
            Assert.IsTrue(managementPresentationModel.IsDataEmpty());
            allText[7] = (" ");
            managementPresentationModel.SetData(allText);
            Assert.IsFalse(managementPresentationModel.IsDataEmpty());
        }

        // test check is there same course number already
        [TestMethod()]
        public void TestCheckChangedCourseNumber()
        {
            Assert.IsTrue(managementPresentationModel.CheckChangedCourseNumber("291706"));
            Assert.IsFalse(managementPresentationModel.CheckChangedCourseNumber("29170"));
        }

        // test get data from view
        [TestMethod()]
        public void TestSetData()
        {
            List<string> allText = new List<string>();
            allText.Add("");
            allText.Add("");
            allText.Add("");
            allText.Add("");
            allText.Add("");
            allText.Add("");
            allText.Add("");
            managementPresentationModel.SetData(allText);
            foreach (string text in managementPresentationModel.AllText)
            {
                Assert.AreEqual("", text);
            }
        }

        // test check class time and hour are matched or not
        [TestMethod()]
        public void TestCheckClassTime()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            List<string> allText = new List<string>();
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Number);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Name);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Stage);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Credit);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Teacher);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].RequiredOrElective);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Hour);
            allText.Add("資工三");
            managementPresentationModel.SetData(allText);
            Assert.IsTrue(managementPresentationModel.CheckClassTime());
            managementPresentationModel.ClassTimeTable.Rows[0][1] = true;
            Assert.IsFalse(managementPresentationModel.CheckClassTime());
        }

        // test has class time changed
        [TestMethod()]
        public void CheckChangedClassTime()
        {
            managementPresentationModel.ShowCourseData(5);
            Assert.IsFalse(managementPresentationModel.CheckChangedClassTime());
            managementPresentationModel.ClassTimeTable.Rows[0][1] = true;
            Assert.IsTrue(managementPresentationModel.CheckChangedClassTime());
        }

        // test check save button state in different situation
        [TestMethod()]
        public void TestCheckSaveButtonState()
        {
            managementPresentationModel.ShowCourseData(SIXTH_COURSE);
            List<string> allText = new List<string>();
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Number);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Name);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Stage);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Credit);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Teacher);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].RequiredOrElective);
            allText.Add(managementPresentationModel.GetAllCourses().GetBindingList()[SIXTH_COURSE].Hour);
            allText.Add("");
            allText.Add("");
            allText.Add("");
            managementPresentationModel.SetData(allText);
            Assert.IsFalse(!managementPresentationModel.IsDataEmpty());
            allText[7] = ("資工三");
            allText[6] = "4";
            managementPresentationModel.SetData(allText);
            Assert.IsFalse(managementPresentationModel.CheckClassTime());
            allText[6] = "3";
            allText[0] = "29170";
            managementPresentationModel.SetData(allText);
            Assert.IsTrue(managementPresentationModel.CheckDataChanged());
            allText[0] = "291706";
            managementPresentationModel.SetData(allText);
            Assert.IsFalse(managementPresentationModel.CheckSaveButtonState());
            managementPresentationModel.ClassTimeTable.Rows[0][1] = true;
            Assert.IsFalse(managementPresentationModel.CheckSaveButtonState());
            allText[6] = "4";
            managementPresentationModel.SetData(allText);
            Assert.IsTrue(managementPresentationModel.CheckSaveButtonState());
        }

        // test click downlaod button
        [TestMethod()]
        public void TestClickButtonDownload()
        {
            Assert.IsTrue(managementPresentationModel.ClickButtonDownload("test"));
        }

        // test delete course
        [TestMethod()]
        public void TestDeleteCourse()
        {
            int length = managementPresentationModel.GetAllCourses().CourseInfo.Count;
            managementPresentationModel.ShowCourseData(5);
            managementPresentationModel.DeleteCourse();
            Assert.AreEqual(length - 1, managementPresentationModel.GetAllCourses().CourseInfo.Count);
        }

        // test show class
        [TestMethod()]
        public void TestShowClassData()
        {
            Assert.IsInstanceOfType(managementPresentationModel.ShowClassData(0), typeof(BindingList<CourseInfoDto>));
            Assert.IsInstanceOfType(managementPresentationModel.ShowClassData(1), typeof(BindingList<CourseInfoDto>));
            Assert.AreEqual(12, managementPresentationModel.ShowClassData(0).Count);
        }

        // test check class save button state
        [TestMethod()]
        public void TestCheckClassSaveButtonState()
        {
            Assert.IsFalse(managementPresentationModel.CheckClassSaveButtonState(string.Empty));
            Assert.IsTrue(managementPresentationModel.CheckClassSaveButtonState("1"));
            Assert.IsFalse(managementPresentationModel.CheckClassSaveButtonState("電子三甲"));
        }
    }
}
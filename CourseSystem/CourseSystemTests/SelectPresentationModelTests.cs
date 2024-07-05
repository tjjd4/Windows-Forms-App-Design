using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CourseSystem.Tests
{
    [TestClass()]
    public class SelectPresentationModelTests
    {
        Model model;
        SelectPresentationModel selectPresentationModel;

        const string NULL_STRING = "";
        const string NUMBER_1 = "123456";

        // initiallize data
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model();
            selectPresentationModel = new SelectPresentationModel(model);
        }

        // test fetch selecting courseInfo
        [TestMethod()]
        public void TestGetSelectingCourseInfos()
        {
            Assert.AreEqual(model.SelectingCourseInfos, selectPresentationModel.GetSelectingCourseInfos());
        }

        // test click select result button
        [TestMethod()]
        public void TestClickSelectResult()
        {
            Assert.IsTrue(selectPresentationModel.IsSelectResultViewClosed);
            selectPresentationModel.ClickSelectResult("test");
            Assert.IsFalse(selectPresentationModel.IsSelectResultViewClosed);
        }
        
        /*
        // test check the button status
        [TestMethod()]
        public void TestClickCheckBox()
        {
            TabControl tabControl = new TabControl();
            TabPage tabPage1 = new TabPage();
            TabPage tabPage2 = new TabPage();
            DataGridView dataGridView = new DataGridView();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(NULL_STRING, typeof(bool));
            for (int index = 0; index < 10; index++)
            {
                DataRow row1 = dataTable.NewRow();
                row1[0] = true;
                dataTable.Rows.Add(row1);
            }
            DataRow row = dataTable.NewRow();
            row[0] = true;
            dataTable.Rows.Add(row);
            dataGridView.DataSource = dataTable;
            tabPage2.Controls.Add(dataGridView);
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            Assert.IsTrue(selectPresentationModel.ClickCheckBox(tabControl));
        }

        // test click the send button
        [TestMethod()]
        public void ClickSendTest()
        {
            Assert.Fail();
        }
        */

        [TestMethod()]
        public void TestCheckCourseAdd()
        {
            List<string> message = new List<string>();
            for (int _ = 0; _ < 3; _++)
            {
                message.Add(NULL_STRING);
            }
            string finalMessage = selectPresentationModel.CheckCourseAdd(message, "test");
            Assert.AreEqual(NULL_STRING, finalMessage);
            message[2] = NUMBER_1;
            finalMessage = selectPresentationModel.CheckCourseAdd(message, "test");
            Assert.AreNotEqual(NULL_STRING, finalMessage);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class StartUpView : Form
    {
        StartUpPresentationModel _startUpModel;

        public StartUpView(StartUpPresentationModel startUpModel)
        {
            _startUpModel = startUpModel;
            InitializeComponent();
            _startUpModel._startUpModelChanged += CheckState;
        }
        // click course select button
        private void ClickSelect(object sender, EventArgs e)
        {
            _startUpModel.ClickSelect();
            _buttonSelect.Enabled = false;
        }

        // click Management
        private void ClickManagement(object sender, EventArgs e)
        {
            _startUpModel.ClickManagement();
            _buttonManagement.Enabled = false;
        }

        // click exit
        private void ClickExit(object sender, EventArgs e)
        {
            Close();
        }

        // refresh status
        public void CheckState()
        {
            _buttonManagement.Enabled = _startUpModel.IsManagementEnable();
            _buttonSelect.Enabled = _startUpModel.IsSelectEnable();
        }
    }
}

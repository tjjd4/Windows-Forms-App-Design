using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseSystem
{
    public class StartUpPresentationModel
    {

        public event StartUpModelChangedEventHandler _startUpModelChanged;
        public delegate void StartUpModelChangedEventHandler();

        Model _model;
        bool _isSelectViewClosed;
        bool _isManagementViewClosed;

        public StartUpPresentationModel(Model model)
        {
            _model = model;
            _isSelectViewClosed = true;
            _isManagementViewClosed = true;
        }

        // click select
        public void ClickSelect()
        {
            SelectView selectView = new SelectView(_model);
            selectView.Show();
            selectView.FormClosed += CloseSelectView;
            _isSelectViewClosed = false;
        }

        // click management
        public void ClickManagement()
        {
            ManagementView managementView = new ManagementView(_model);
            managementView.Show();
            managementView.FormClosed += CloseManagementView;
            _isManagementViewClosed = false;
        }

        // refresh status
        public void CloseSelectView(Object sender, FormClosedEventArgs e)
        {
            _isSelectViewClosed = true;
            NotifyObserver();
        }

        // refresh status
        public void CloseManagementView(Object sender, FormClosedEventArgs e)
        {
            _isManagementViewClosed = true;
            NotifyObserver();
        }

        // return view is open or not
        public bool IsSelectEnable()
        {
            return _isSelectViewClosed;
        }

        // return view is open or not
        public bool IsManagementEnable()
        {
            return _isManagementViewClosed;
        }

        // call observer
        void NotifyObserver()
        {
            if (_startUpModelChanged != null)
                _startUpModelChanged();
        }
    }
}

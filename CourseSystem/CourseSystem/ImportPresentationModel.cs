using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace CourseSystem
{
    public class ImportPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model _model;
        string _progress;

        const string CLASS_CSIE_1 = "CSIE1";
        const string CLASS_CSIE_2 = "CSIE2";
        const string CLASS_CSIE_4 = "CSIE4";
        const string THIRTY = "30";
        const string SIXTY = "60";
        const string HUNDRED = "100";
        const string PROGRESS = "Progress";
        const string REPORT = "資料已經下載完成";
        const int INITIAL_CLASS_AMOUNT = 2;
        const int TIME_DELAY = 500;

        public ImportPresentationModel(Model model)
        {
            _model = model;
        }

        // download csie classes
        public void DownloadClasses()
        {
            if (_model.CourseInfos.Count == INITIAL_CLASS_AMOUNT)
            {
                _model.DownloadSingleClass(CLASS_CSIE_1);
                _progress = THIRTY;
                Thread.Sleep(TIME_DELAY);
                _model.DownloadSingleClass(CLASS_CSIE_2);
                _progress = SIXTY;
                Thread.Sleep(TIME_DELAY);
                _model.DownloadSingleClass(CLASS_CSIE_4);
                _progress = HUNDRED;
            }
            else
                _progress = REPORT;
        }

        // databinding partern
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                this._progress = value;
                NotifyPropertyChanged(PROGRESS);
            }
        }
    }
}

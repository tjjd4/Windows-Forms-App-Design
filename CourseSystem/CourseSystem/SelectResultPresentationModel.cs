using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace CourseSystem
{
    public class SelectResultPresentationModel
    {
        Model _model;

        public SelectResultPresentationModel(Model model)
        {
            _model = model;
        }

        // connect to model
        public Class GetResultCourseInfo()
        {
            return _model.SelectedCourseInfo;
        }

        // set the title of the column
        public void SetHeaderText(DataGridView dataGridView)
        {
            Class.SetHeaderText(dataGridView);
        }

        // delete course
        public void DeleteSelectedCourse(int deleteIndex)
        {
            _model.DeleteSelectedCourse(deleteIndex);
        }
    }
}

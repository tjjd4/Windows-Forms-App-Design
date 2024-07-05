using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseSystem
{
    class Program
    {
        // main function
        static void Main(string[] args)
        {
            Model model = new Model();
            StartUpPresentationModel startUpModel = new StartUpPresentationModel(model);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartUpView(startUpModel));
        }
    }
}

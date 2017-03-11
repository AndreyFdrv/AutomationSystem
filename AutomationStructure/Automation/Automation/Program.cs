using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.View;
using Automation.Model;

namespace Automation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          

            //BLService model = new BLService();
            //MainForm view = new MainForm();

            //Presenter presenter = new Presenter(model,view);
            //view._presenter = presenter;
            Application.Run(new ModuleConfigurator());
        }
    }
}

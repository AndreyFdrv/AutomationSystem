using System;
using System.Windows.Forms;
using Automation.Model;
using Automation.Presenters;
using Automation.View;

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

            var view = new MainForm();

            ProjectPresenter projectPresenter = new ProjectPresenter();
            CustomerMaterialsPresenter customerMaterialsPresenter = new CustomerMaterialsPresenter(view);
            ProductsPresenter productsPresenter = new ProductsPresenter(view);
            ReportPresenter reportPresenter = new ReportPresenter(view);
            ModulePresenter modulePresenter = new ModulePresenter();
            

            view.ProjectPresenter = projectPresenter;
            view.CustomerMaterialsPresenter = customerMaterialsPresenter;
            view.ProductsPresenter = productsPresenter;
            view.ReportPresenter = reportPresenter;
            view.ModulePresenter = modulePresenter;

            Application.Run(view);
            //Presenter presenter = new Presenter(model, view);
            //view._presenter = presenter;
            //Application.Run(view);
        }
    }
}

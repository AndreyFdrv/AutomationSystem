using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;

namespace Automation.Controls
{
    public partial class ReportWindow : Form
    {
        private DataTable _detailsInfo;
        private DataTable _furniture;
        private string _imagePath;
        private DataTable _loopsInfo;
        private DataTable _mainInfo;
        private string _moduleName;
        private DataTable _shelfInfo;


        public ReportWindow(string moduleName, string imagePath, 
            DataTable mainInfo, DataTable detailsInfo, 
            DataTable loopsInfo, DataTable shelfInfo, DataTable furniture)
        {
            InitializeComponent();
            _moduleName = moduleName;
            _imagePath = imagePath;
            _mainInfo = mainInfo;
            _detailsInfo = detailsInfo;
            _loopsInfo = loopsInfo;
            _shelfInfo = shelfInfo;
            _furniture = furniture;
            Test();
        }

        private void Test()
        {
        
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.EnableExternalImages = true;

            ReportDataSource mainDs = new ReportDataSource("Main",_mainInfo);
            reportViewer1.LocalReport.DataSources.Add(mainDs);

            ReportDataSource loopsDs = new ReportDataSource("Loops", _loopsInfo);
            reportViewer1.LocalReport.DataSources.Add(loopsDs);

            ReportDataSource shelfDs = new ReportDataSource("Shelf", _shelfInfo);
            reportViewer1.LocalReport.DataSources.Add(shelfDs);

            DataTable common = new DataTable();
            common.Columns.Add("NumberModule");
            common.Columns.Add("ImagePath");
            DataRow row = common.NewRow();
            row[0] = _moduleName;
            row[1] = "file:///"+ Environment.CurrentDirectory+"\\"+_imagePath;
            common.Rows.Add(row);
            ReportDataSource commonDs = new ReportDataSource("Common",common);
            reportViewer1.LocalReport.DataSources.Add(commonDs);
           

            reportViewer1.RefreshReport();
        }

        private void ReportWindow_Load(object sender, EventArgs e)
        {
       
        }
    }
}

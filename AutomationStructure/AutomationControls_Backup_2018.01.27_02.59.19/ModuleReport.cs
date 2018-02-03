using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Automation.Controls
{
    public partial class ModuleReport : UserControl
    {

        public event EventHandler<ReportsArgs> onGroupModeChanged;

        public ModuleReport()
        {
            InitializeComponent();
        }

        

        public void BindData(DataTable ldspInfo, DataTable backWallInfo, DataTable furnitureInfo, DataTable fasadeInfo)
        {
            LDSPDetails.DataSource = null;
            LDSPDetails.DataSource = ldspInfo;
            LDSPDetails.MasterTemplate.BestFitColumns();


            BackWallDetails.DataSource = null;
            BackWallDetails.DataSource = backWallInfo;
            BackWallDetails.MasterTemplate.BestFitColumns();

            FurnitureDetails.DataSource = null;
            FurnitureDetails.DataSource = furnitureInfo;
            FurnitureDetails.MasterTemplate.BestFitColumns();

            FasadeDetails.DataSource = null;
            FasadeDetails.DataSource = fasadeInfo;
            FasadeDetails.MasterTemplate.BestFitColumns();
        }

        public void SetViewDefinitions(ColumnGroupsViewDefinition dimensionsVd, ColumnGroupsViewDefinition detailsVd, ColumnGroupsViewDefinition furnitureVd)
        {

        }

        public bool isGroupModule {get;set;}

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            //ReportsArgs arg = new ReportsArgs { isGroupMode = false };
            //onGroupModeChanged(this, arg);
        }

        private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            //ReportsArgs arg = new ReportsArgs { isGroupMode = true };
            //onGroupModeChanged(this, arg);
        }



    }

    public class ReportsArgs : EventArgs
    {
        public bool isGroupMode { get; set; }
    }
}

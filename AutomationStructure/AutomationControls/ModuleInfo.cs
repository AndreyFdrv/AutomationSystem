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
    public partial class ModuleInfo: UserControl
    {
        public ModuleInfo()
        {
            InitializeComponent();
        }


        public void BindData(string moduleName, string imagePath, DataTable dimensionsInfo, DataTable detailsInfo, DataTable shelfInfo, DataTable furnitureInfo, DataTable loopsInfo)
        {
            moduleNameLbl.Text = moduleName;
            modulePbx.Load(imagePath);
            mainInfoDgv.DataSource = dimensionsInfo;
            detailsDgv.DataSource = detailsInfo;
            loopsInfoDgv.DataSource = loopsInfo;
            shelfInfoDgv.DataSource = shelfInfo;
            furnitureDgv.DataSource = furnitureInfo;
        }

        public void SetViewDefinitions(ColumnGroupsViewDefinition dimensionsVd, ColumnGroupsViewDefinition detailsVd, ColumnGroupsViewDefinition furnitureVd)
        {
            mainInfoDgv.ViewDefinition = dimensionsVd;
            detailsDgv.ViewDefinition = detailsVd;
            furnitureDgv.DataSource = furnitureVd;
        }


    }
}

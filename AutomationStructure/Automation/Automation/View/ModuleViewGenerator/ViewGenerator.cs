using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Automation.View.ModuleViewGenerator
{
    public abstract class ViewGenerator
    {
        public abstract void SetupView(RadGridView dgv, DataTable table);

    }
}

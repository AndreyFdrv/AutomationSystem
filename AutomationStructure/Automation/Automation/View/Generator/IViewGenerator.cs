using System.Data;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public interface IViewGenerator
    {
        void SetupView(RadGridView dgv, DataTable table);
    }
}

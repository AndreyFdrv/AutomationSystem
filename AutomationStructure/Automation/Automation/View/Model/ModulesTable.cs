using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation.View.Model
{
   public static class ModulesTable
    {
       public static void AddProductRowDgv(DataGridView datagrid, string moduleName)
       {
           string[] row = new string[] {moduleName, "0"};
           datagrid.Rows.Add(row);
       }

    }
}

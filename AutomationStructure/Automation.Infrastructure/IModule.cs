using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Infrastructure
{
    public interface IModule
    {
        string Name { get; set; }
        string Scheme { get; set; }
        string ModulePath { get; set; }
        string IconPath { get; set; }

        void Calculate();

        DataTable GetDetails();
        void SetDetails(DataTable moduleDetails);

        //reports
        DataTable GetDetailsReport();
        DataTable GetFurnitureReport();
        DataTable GetMainModuleReport();
        DataTable GetShelfReport();
        
        List<IModuleDetailCollection> GetModuleDetailCollections();       
        
        IModule Clone();
        DataTable GetEmptyTable();
        void SetCommonModuleOptions();
        void GetInfoRows(DataTable emptyTable);
    }
}

using Automation.Infrastructure;
using KitchenUpModule.OneFacade.DTO;
using KitchenUpModule.OneFacade.Formule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Module.KitchenUp.OneFacade
{
    public class KitchenUpModuleOneFacade : IModule
    {
        //Data
        private readonly ModuleData _data;
        private Formules _formules;
        private KitchenUpModule.OneFacade.Reports.Report _report;

        public string Name { get; set; }
        public string Scheme { get; set; }
        public string ModulePath { get; set; }
        public string IconPath { get; set; }


        public KitchenUpModuleOneFacade()
        {
            _data = new ModuleData();
            _formules = new Formules(_data);
            _report = new KitchenUpModule.OneFacade.Reports.Report();
        }

        public void SetCommonModuleOptions()
        {
            _data.SetCommonParams(Name, ModulePath, Scheme, IconPath);
        }


        public void SetModuleDetails(DataTable moduleDetails)
        {
            _data.SetModulesData(moduleDetails);
        }

        public DataTable GetDetails()
        {
            return _data.GetModulesData();
        }

        public void SetDetails(DataTable moduleDetails)
        {
            _data.SetModulesData(moduleDetails);
        }

        public void Calculate()
        {
            IModuleDetailCollection dfsd = new ModuleDetailCollection();

            //  _report.MiddleHeight = _formules.CalculateMidleHeight();
        }

        public DataTable GetMainModuleReport()
        {
            return null;// _report.GetMainModuleReport();
        }

        public DataTable GetDetailsReport()
        {
            throw new NotImplementedException();
        }

        public DataTable GetShelfReport()
        {
            throw new NotImplementedException();
        }

        public DataTable GetFurnitureReport()
        {
            throw new NotImplementedException();
        }

        public List<IModuleDetailCollection> GetModuleDetailCollections()
        {
            return null;
        }


        public DataTable GetInfoTable()
        {
            return _data.GetModulesData();
        }

        public IModule Clone()
        {
            throw new NotImplementedException();
        }

        public DataTable GetEmptyTable()
        {
            return _data.GetEmptyTable();
        }

        public void GetInfoRows(DataTable emptyTable)
        {
            _data.GetInfoRows(emptyTable);
        }
    }
}

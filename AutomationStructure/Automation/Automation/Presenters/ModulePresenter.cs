using System.Data;
using Automation.Infrastructure;
using Automation.Model;
using Automation.View;
using Automation.Services;


namespace Automation.Presenters
{
    public class ModulePresenter
    {
        private readonly  ModuleService _moduleService;
        public ModuleManager _view { get; set; }

        public ModulePresenter()
        {

            _moduleService = ServiceFactory.ModuleServiceInstance;
          
        }


        private void AddNewModule(NewModuleData data)
        {
            _moduleService.AddNewModule(data);
        }

        public void AddSimilarModule(string similarName, ProductType type)
        {
            _moduleService.AddSimilarModule(similarName, type);
            UpdateModuleList(type);
            UpdateTotalModules(type);
        }

        public void DeleteModule(string moduleName, ProductType type)
        {
            if (_moduleService.GetModulesCount(type) > 0)
            {
                _moduleService.DeleteModule(moduleName, type);
                UpdateModuleList(type);
                UpdateTotalModules(type);
                _view.ClearModuleDetailsDatagrid();
            }
        }

        public void UpdateModuleList(ProductType type)
        {
            var modulesNumbers = _moduleService.GetModulesNumbersByType(type);
            _view.UpdateModuleList(modulesNumbers);
        }


        public void UpdateModule(string moduleName, ProductType productType, DataTable moduleInfo)
        {
            UpdateModuleInfo(moduleInfo, moduleName, productType);
            ShowModuleInformation(moduleName, productType);
            UpdateTotalModules(productType);
        }


        private void UpdateModuleInfo(DataTable moduleInfoTable, string moduleNumber, ProductType type)
        {
            _moduleService.UpdateModule(moduleInfoTable, moduleNumber, type);
            UpdateTotalModules(type);
        }

        public void UpdateTotalModules(ProductType type)
        {
            var table = _moduleService.GetAllModulesDetails(type);
            _view.UpdateAllModulesInfo(table);
        }

        public void SetNewModuleInfo(ConfiguratorArgs module, ProductType productType)
        {
            AddNewModule(new NewModuleData
            {
                Name = module.Name,
                Scheme = module.Scheme,               
                ModulePath = module.ModulePath,
                Type = productType
            });
            UpdateModuleList(productType);
            UpdateTotalModules(productType);
          
        }



        public void ShowModuleInformation(string moduleName, ProductType type)
        {
            DataTable table = _moduleService.GetModuleDetails(moduleName, type);
            _view.UpdateModuleDetailsInDatagrid(table);
        }

        public bool IsModuleExist(string moduleNumber, ProductType getTypeProduct)
        {
            return _moduleService.IsModuleExist(moduleNumber, getTypeProduct);
        }


    }
}

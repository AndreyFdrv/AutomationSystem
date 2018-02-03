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
        private readonly ModuleManager _view;

        public ModulePresenter(ModuleManager view)
        {

            _moduleService = ServiceFactory.ModuleServiceInstance;
            _view = view;
        }
        

        public void AddNewModule(NewModuleData data)
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


        public void UpdateModuleInfo(DataTable moduleInfoTable, string moduleNumber, ProductType type)
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
                Number = module.Number,
                Scheme = module.SchemeName,
                SubSchemeIconPath = module.PathToImageSubScheme.Remove(module.PathToImageSubScheme.Length - 4) + "_icon.png",
                SubScheme = module.SubSchemeName,
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

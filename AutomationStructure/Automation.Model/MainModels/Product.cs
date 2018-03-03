using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Automation.Infrastructure;

namespace Automation.Model.MainModels
{
    [Serializable]
    public class Product: IProduct
    {
        public ProductType Type { get; }
        
        private readonly List<IModule> _modules;
        
        
        public Product(string nameProduct)
        {
            _modules = new List<IModule>();
            Type = GetType(nameProduct);
        }


        public void AddModule(NewModuleData data)
        {
            var module = GetModuleByScheme(data.Scheme);
            module.Name = data.Name;
            module.Scheme = data.Scheme;
            module.ModulePath = data.ModulePath;
            module.IconPath = data.ModulePath+ "\\bin\\Debug\\details_images\\icon.png";
            module.SetCommonModuleOptions();
            _modules.Add(module);
        }


        public List<string> GetModulesNames()
        {
            return _modules.Select(module => module.Name).ToList();
        }

        public int GetModulesCount()
        {
            return _modules.Count;
        }

        private IModule GetModuleByScheme(string moduleName)
        {
            return ModuleFactory.ModuleFactory.GetModule(moduleName);
        }
        
        public void DeleteModule(string moduleName)
        {
            var module = _modules.First(x => x.Name == moduleName);
            _modules.Remove(module);

        }

        public void UpdateModule(DataTable data, string number)
        {
            var moduleNumber = int.Parse(number);
            var module = _modules[moduleNumber];
            module.SetDetails(data);       

        }
        
        public ProductType GetType(string nameProduct)
        {
            ProductType type=ProductType.KitchenUp;
            
            switch (nameProduct)
            {
                case "Кухня верхние модули": type=ProductType.KitchenUp;
                    break;
                case "Кухня нижние модули":
                    type = ProductType.KitchenDown;
                    break;
            }
            return type;
        }
      
        public DataTable GetTotalDetailInfo()
        {
            DataTable emptyTable = null;
            if (_modules.Count!=0)
            {
                emptyTable = _modules[0].GetEmptyTable();
                foreach (var module in _modules)
                {
                   module.GetInfoRows(emptyTable);
                }
            }
            return emptyTable;


        }

        public DataTable GetModuleDetailInfoByName(string name)
        {
            var module = _modules.First(x => x.Name == name);
            DataTable table = module.GetDetails();
            return  table;
        }

        public IModule GetCloneLastModule()
        {
            var lastModule =  _modules.Last();
            var newCloneModule =  lastModule.Clone();
            return newCloneModule;
        }

        public void AddSimilarModule(IModule module)
        {
            _modules.Add(module);
        }

        public List<string> GetModulesNumbers()
        {
            return _modules.Select(module => module.Name).ToList();
            // rework
        }

        public bool IsModuleExist(string name)
        {
            return _modules.Exists(module => module.Name == name);

        }

        public List<IModule> GetAllModules()
        {
            return _modules;
          
        }

        public DataTable GetModuleDetailInfoByNumber(string moduleNumber)
        {
            var number = int.Parse(moduleNumber);
            var module = _modules[number];
            return module.GetDetails();
        }
    }
}

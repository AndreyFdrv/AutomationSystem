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
        
        private readonly List<BaseModule> _modules;
        
        
        public Product(string nameProduct)
        {
            _modules = new List<BaseModule>();
            Type = GetType(nameProduct);
        }


        public void AddModule(NewModuleData data)
        {
            var module = GetModuleByType();
            module.Name = data.Name;
            module.Number = data.Number;
            module.SubScheme = data.SubScheme;
            module.Sсheme = data.Scheme;
            module.IconPath = data.SubSchemeIconPath;
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

        private BaseModule GetModuleByType()
        {
            BaseModule module = ModuleFactory.ModuleFactory.GetModule(Type);
            return module;
        }
        
        public void DeleteModule(string moduleName)
        {
            var module = _modules.First(x => x.Number == moduleName);
            _modules.Remove(module);

        }

        public void UpdateModule(DataTable data, string moduleNumber)
        {
            var module = _modules.First(x => x.Number == moduleNumber);
            module.SetupModule(data);
       

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

        public DataTable GetModuleDetailInfoByNumber(string moduleNumber)
        {
            var module = _modules.First(x => x.Number == moduleNumber);
            DataTable table = module.GetInfoTable();
            return table;
        }

        public BaseModule GetCloneLastModule()
        {
            var lastModule =  _modules.Last();
            var newCloneModule =  (BaseModule)lastModule.Clone();
            return newCloneModule;
        }

        public void AddSimilarModule(BaseModule module)
        {
            _modules.Add(module);
        }

        public List<string> GetModulesNumbers()
        {
            return _modules.Select(module => module.Number).ToList();
        }

        public bool IsModuleExist(string number)
        {
            return _modules.Exists(module => module.Number == number);

        }

        public List<BaseModule> GetAllModules()
        {
            return _modules;
          
        }
    }
}

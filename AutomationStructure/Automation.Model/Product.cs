using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Automation.Model.Modules;
using  Automation.Model.Modules.KitchenUpModule;


namespace Automation.Model
{
    [Serializable]
    public class Product
    {
        public ProductTypes Type { get; set; }
        
        private List<AbstractModule> _modules;

        public List<string> GetNamesModules()
        {
            return _modules.Select(module => module.Name).ToList();
        }


        public Product(string nameProduct)
        {
            _modules = new List<AbstractModule>();
            Type = GetType(nameProduct);
        }

        public int GetCountModules()
        {
            return _modules.Count;
        }

        public void AddNewModule(NewModuleData data)
        {
            var module = GetModuleByType();
            module.Name = data.Name;
            module.Number = data.Number;
            module.SubScheme = data.SubScheme;
            module.Sсheme =  data.Scheme;
            module.IconPath = data.SubSchemeIconPath;
            _modules.Add(module);
        }

        private AbstractModule GetModuleByType()
        {
            AbstractModule module = null;
            switch (Type)
            {
               case ProductTypes.KITCHEN_UP:
                    module = new KitchenUp();
                    break;
                    case ProductTypes.KITCHEN_DOWN:
                    module = new KitchenDown();
                    break;
            }
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
        
        public ProductTypes GetType(string nameProduct)
        {
            ProductTypes type=ProductTypes.KITCHEN_UP;
            
            switch (nameProduct)
            {
                case "Кухня верхние модули": type=ProductTypes.KITCHEN_UP;
                    break;
                case "Кухня нижние модули":
                    type = ProductTypes.KITCHEN_DOWN;
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

        public DataTable GetModuleDetailInfoByName(string moduleName)
        {

            var module = _modules.First(x => x.Name == moduleName);
            DataTable table = module.GetInfoTable();
            return table;
        }

        public DataTable GetModuleDetailInfoByNumber(string moduleNumber)
        {
            var module = _modules.First(x => x.Number == moduleNumber);
            DataTable table = module.GetInfoTable();
            return table;
        }

        public AbstractModule GetCloneLastModule()
        {
            var lastModule =  _modules.Last();
            var newCloneModule =  (AbstractModule)lastModule.Clone();
            return newCloneModule;
        }

        public void AddSimilarModule(AbstractModule module)
        {
            _modules.Add(module);
        }

        public List<string> GetNumbersModules()
        {
            return _modules.Select(module => module.Number).ToList();
        }

        public bool IsModuleExist(string number)
        {
            return _modules.Exists(module => module.Number == number);

        }

        public List<AbstractModule> GetAllProducts()
        {
            return _modules;
        }
    }
}

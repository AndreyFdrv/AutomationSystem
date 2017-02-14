using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Automation.Model.Modules;

namespace Automation.Model
{
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
            module.Sсheme =  data.Scheme;
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
            var module = _modules.First(x => x.Name == moduleName);
            _modules.Remove(module);

        }

        public void UpdateModule(object data, string moduleName)
        {
            var module = _modules.First(x => x.Name == moduleName);
            //обновление данных
         //   module.SetupData();

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
            foreach (var module in _modules)
            {
                
            }
            return null;
        }

        public DataTable GetModuleDetailInfo(string moduleName)
        {
            var module = _modules.First(x => x.Name == moduleName);
            DataTable table = module.GetInfoTable();
            return table;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Model.Modules;

namespace Automation.Model
{
    public class Product
    {
        public ProductTypes Type { get; set; }
        
        private List<AbstractModule> _modules;


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
            
        }
        


        public void DeleteModule()
        {
            
        }

        public void UpdateModule()
        {
            
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

       
    }
}

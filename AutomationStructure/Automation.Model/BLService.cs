using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automation.Model
{
    public  class BLService
    {

        private Order _order;


        public void MakeNewProject()
        {
           _order = new Order();
        }

        public void SaveCurrentProject()
        {
            
        }

        public void GetModelToXML()
        {
            
        }

        public void LoadProject()
        {
            
        }

        //большой метод
        public void ApplyChangesToModel()
        {
            
        }

        public void GetViewFromModel()
        {
            
        }

        public string GetTotalCustomerRecord()
        {
            return _order.customersInfoCollection.GetTotalCustomerRecord();
        }


        public void SetCustomer(List<string[]> customerRecord)
        {
            _order.SetCustomer(customerRecord);
        }

        public void AddNewModule(NewModuleData data)
        {
            var product = _order.productsCollection.GetProduct(data);
            product.AddNewModule(data);
        }

        public void AddNewProduct(string nameProduct)
        {
            _order.productsCollection.AddNewProduct(nameProduct);
        }

        public List<string> GetModulesNamesByType(ProductTypes type)
        {
            var product = _order.productsCollection.GetProductByType(type);
            return product.GetNamesModules();
        }

        public List<string> GetModulesNamesByType()
        {
            return null;
        }

        public string GetProductNameByType(ProductTypes type)
        {
            string result = string.Empty;
            switch (type)
            {
                    case ProductTypes.KITCHEN_UP:
                    result = "Кухня верхние модули";
                    break;
                case ProductTypes.KITCHEN_DOWN:
                    result = "Кухня нижние модули";
                    break;
           }
            return result;
        }

        public int GetCountModules(ProductTypes type)
        {
            var count = _order.productsCollection.GetCountModules(GetProductNameByType(type));
            return count;
        }

        public DataTable GetDetailDataForModule(string moduleName, ProductTypes type)
        {
            var product = _order.productsCollection.GetProductByType(type);
            DataTable table = product.GetTotalDetailInfo();
            return table;
        }
    }
}

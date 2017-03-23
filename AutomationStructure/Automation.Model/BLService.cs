using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Automation.Model
{
    public  class BLService
    {

        private Order _order;

        #region Project Methods


        public void MakeNewProject()
        {
            _order = new Order();
        }


        #endregion

        #region Customer Methods

        public string GetTotalCustomerRecord()
        {
            return _order.CustomersCollection.GetTotalCustomerRecord();
        }


        public void SetCustomer(List<string[]> customerRecord)
        {

            _order.CustomersCollection.SetInputData(customerRecord);
        }


        #endregion
        
        #region Product Methods

        public void AddNewProduct(string nameProduct)
        {
            _order.ProductsCollection.AddProduct(nameProduct);
        }

        #endregion
        
        #region Modules Methods


        public void AddNewModule(NewModuleData data)
        {
            var product = _order.ProductsCollection.GetProduct(data);
            product.AddNewModule(data);
        }


        public List<string> GetModulesNamesByType(ProductTypes type)
        {
            var product = _order.ProductsCollection.GetProduct(type);
            return product.GetNamesModules();
        }

        public List<string> GetModulesNumbersByType(ProductTypes type)
        {
            var product = _order.ProductsCollection.GetProduct(type);
            return product.GetNumbersModules();
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
            var count = _order.ProductsCollection.GetCountModules(GetProductNameByType(type));
            return count;
        }

        public DataTable GetDetailDataForModule(string moduleName, ProductTypes type)
        {
            var product = _order.ProductsCollection.GetProduct(type);
            DataTable moduleInfo = product.GetModuleDetailInfoByNumber(moduleName);
            return moduleInfo;
        }

        public DataTable GetTotalModulesInfo(ProductTypes type)
        {
            var product = _order.ProductsCollection.GetProduct(type);
            DataTable table = product.GetTotalDetailInfo();
            return table;
        }

        public void DeleteModule(string nameModule, ProductTypes type)
        {
            var product = _order.ProductsCollection.GetProduct(type);
            product.DeleteModule(nameModule);

        }

        public void AddSimilarModule(string similarName, ProductTypes type)
        {
            var product = _order.ProductsCollection.GetProduct(type);
            var module = product.GetCloneLastModule();
            module.Name = similarName;
            product.AddSimilarModule(module);

        }

        public void UpdateModuleInfo(DataTable moduleInfoTable, string numberModule, ProductTypes type)
        {
            var product = _order.ProductsCollection.GetProduct(type);
            product.UpdateModule(moduleInfoTable, numberModule);
        }

        #endregion

        public Order GetCurrentOrder()
        {
            return _order;
        }

        public void SetCurrentOrder(Order order)
        {
            _order = order;
        }
    }
}

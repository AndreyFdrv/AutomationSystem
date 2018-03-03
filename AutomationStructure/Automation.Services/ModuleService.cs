using System;
using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;
using Automation.Model;
using Automation.Model.MainModels;

namespace Automation.Services
{
    public class ModuleService
    {

        private IProduct GetProduct(ProductType type)
        {
            var order = Order.Instance;
            var productsCollection = order.GetProductsInfoCollection();
            var product = productsCollection.GetProduct(type);
            return product;
        }

        private IProduct GetProduct(NewModuleData data)
        {
            var order = Order.Instance;
            var productsCollection = order.GetProductsInfoCollection();
            var product = productsCollection.GetProduct(data);
            return product;
        }


        public void AddNewModule(NewModuleData data)
        {
            var product = GetProduct(data);
            product.AddModule(data);
        }

        public void AddSimilarModule(string similarName, ProductType type)
        {
            var product = GetProduct(type);
            var module = product.GetCloneLastModule();
            module.Name = similarName;
            product.AddSimilarModule(module);
        }

        public DataTable GetModuleDetails(string moduleName, ProductType type)
        {
            var product = GetProduct(type);
            DataTable moduleInfo = product.GetModuleDetailInfoByNumber(moduleName);
            return moduleInfo;
        }

        public DataTable GetAllModulesDetails(ProductType type)
        {
            var product = GetProduct(type);
            var table = product.GetTotalDetailInfo();
            return table;
        }

        public void UpdateModule(DataTable moduleInfoTable, string numberModule, ProductType type)
        {
            var product = GetProduct(type);
            product.UpdateModule(moduleInfoTable, numberModule);
        }
        
        public void DeleteModule(string nameModule, ProductType type)
        {
         
            var product = GetProduct(type);
            product.DeleteModule(nameModule);
        }
        
        public List<string> GetModulesNamesByType(ProductType type)
        {
            var product = GetProduct(type);
            return product.GetModulesNames();
        }

        public List<string> GetModulesNumbersByType(ProductType type)
        {
            var product = GetProduct(type);
            return product.GetModulesNumbers();
        }
        
        //public string GetProductNameByType(ProductType type)
        //{
        //    string result = string.Empty;
        //    switch (type)
        //    {
        //        case ProductType.KitchenUp:
        //            result = "Кухня верхние модули";
        //            break;
        //        case ProductType.KitchenDown:
        //            result = "Кухня нижние модули";
        //            break;
        //    }
        //    return result;
        //}
        
        public int GetModulesCount(ProductType type)
        {
            var product = GetProduct(type);
            var count = product.GetModulesCount();
            return count;
        }


        public bool IsModuleExist(string moduleNumber, ProductType type)
        {
            var product = GetProduct(type);
            return product.IsModuleExist(moduleNumber);
        }
    }
}

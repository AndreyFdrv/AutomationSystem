using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Model;
using Automation.View;
using Automation.View.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Automation
{
   public class Presenter
    {
        private BLService _blService;
        private MainForm _view;
        public ModuleManager Manager { get; set; }

       

        public Presenter(BLService model, MainForm view)
        {
            _blService = model;
            _view = view;
        }

        public void NewProject()
        {
            _blService.MakeNewProject();
        }

        internal void OpenProject(string pathToFile)
        {
            Order order = null;


            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(pathToFile,FileMode.OpenOrCreate))
            {
                order = (Order)formatter.Deserialize(fs);
            }

            _blService.SetCurrentOrder(order);

        }

        internal void SaveProject(string pathToFile)
        {
            var order = _blService.GetCurrentOrder();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(pathToFile,FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,order);
            }
        }

        public void SetCustomer(List<string[]> customerRecord)
        {
            _blService.SetCustomer(customerRecord);
            UpdateCustomerString();
        }


       public void AddNewModule(NewModuleData data)
       {
           _blService.AddNewModule(data);
           //UpdateModuleList();
          // UpdateModuleDetail();
          // UpdateAllModuleInfo();
       }

       

        #region For Update View

        
        public void UpdateModuleList(ProductTypes type)
        {
            List<string> modulesName = _blService.GetModulesNamesByType(type);
            Manager.UpdateModuleList(modulesName);
        }
        
        private void UpdateCustomerString()
        {
            string customerRecord = _blService.GetTotalCustomerRecord();
            _view.UpdateCustomerString(customerRecord);
        }

        #endregion


       internal void AddNewProduct(string nameProduct)
        {
            _blService.AddNewProduct( nameProduct);
        }

       public void UpdateModulesCount(ProductTypes type)
       {
           var nameProduct = _blService.GetProductNameByType(type);
           var countModules = _blService.GetCountModules(type);
           _view.UpdateProductCount(countModules,nameProduct);
       }

 

        public void ShowModuleInformation(string moduleName, ProductTypes type)
       {
           DataTable table = _blService.GetDetailDataForModule(moduleName, type);
           Manager.UpdateDetailDataDataGrid(table);
       }

       public void UpdateTotalModules(ProductTypes type)
       {
           DataTable table = _blService.GetTotalModulesInfo(type);
           Manager.UpdateAllModuleInfo(table);
       }

       public void DeleteModule(string nameModule, ProductTypes type)
       {
           _blService.DeleteModule(nameModule, type);
            UpdateModuleList(type);
            UpdateTotalModules(type);
           Manager.ClearModuleDetailsDgv();
       }

       public void AddSimilarModule(string similarName, ProductTypes type)
       {
           _blService.AddSimilarModule(similarName, type);
            UpdateModuleList(type);
            UpdateTotalModules(type);
           
       }

       public void UpdateModuleInfo(DataTable moduleInfoTable, string nameModule, ProductTypes type)
       {
           _blService.UpdateModuleInfo(moduleInfoTable, nameModule, type);
            UpdateTotalModules(type);
       }
    }
}

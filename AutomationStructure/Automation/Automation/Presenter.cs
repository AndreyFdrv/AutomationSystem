using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Model;
using Automation.View;
using Automation.View.Model;

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
            
        }

        public void SetCustomer(List<string[]> customerRecord)
        {
            _blService.SetCustomer(customerRecord);
            UpdateCustomerString();
        }


       public void AddNewModule(NewModuleData data)
       {
           _blService.AddNewModule(data);
           UpdateModuleList();
          // UpdateModuleDetail();
          // UpdateAllModuleInfo();
       }



        #region For Update View


        
        private void UpdateModuleList()
        {

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
    }
}

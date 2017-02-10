﻿using System;
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

        public void UpdateCustomerString()
        {
            string customerRecord = _blService.GetTotalCustomerRecord();
            _view.UpdateCustomerString(customerRecord);
        }

       
        

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
            throw new NotImplementedException();
        }

        public void SetCustomer(List<string[]> customerRecord)
        {
            _blService.SetCustomer(customerRecord);
            UpdateCustomerString();
        }


       public void AddNewModule(NewModuleData data)
       {
           _blService.AddNewModule(data);
       }
    }
}

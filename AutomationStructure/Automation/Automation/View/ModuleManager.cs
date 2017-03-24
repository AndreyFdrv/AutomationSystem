﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.Model;
using Automation.View.Model;
using Automation.View.ModuleViewGenerator;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class ModuleManager : Telerik.WinControls.UI.RadForm
    {
        //Presenter 
        public Presenter Presenter { get; set; }
        
        private string _productName;

        public ModuleManager(Presenter presenter, string productName)
        {
           
            Presenter = presenter;
            Presenter.Manager = this;
            _productName = productName;
            InitializeComponent();
            this.Text = "Настройка модулей \"" + productName + "\"";
            LoadModulesList();
            UpdateTotalModulesDatagrid();


        }


        public ModuleManager()
        {
            InitializeComponent();

        }



        private void LoadModulesList()
        {
            Presenter.UpdateModuleList(GetProductType());
        }

        private void UpdateTotalModulesDatagrid()
        {
            Presenter.UpdateTotalModules(GetProductType());
        }

        private ProductTypes GetProductType()
        {
            ProductTypes productType=ProductTypes.KITCHEN_UP;

            switch (_productName)
            {
                case "Кухня верхние модули":
                    productType = ProductTypes.KITCHEN_UP;
                    break;
                case "Кухня нижние модули":
                    productType = ProductTypes.KITCHEN_DOWN;
                    break;
            }

            return productType;

        }




        private void add_Click(object sender, EventArgs e)
        {
            ModuleConfigurator configuratorModule = new ModuleConfigurator(_productName);
            configuratorModule.OnApply += SetNewModuleInfo;
            configuratorModule.ShowDialog();
        }

        private void SetNewModuleInfo(object sender, ConfiguratorArgs e)
        {
            Presenter.Manager = this;

            if (!Presenter.IsModuleExist(e.Number, GetProductType()))
            {
                Presenter.AddNewModule(new NewModuleData
                {
                    Number = e.Number,
                    Scheme = e.SchemeName,
                    SubSchemeIconPath = GetIconPath(e.PathToImageSubScheme),
                    SubScheme = e.SubSchemeName,
                    Type = GetProductType()
                });
                Presenter.UpdateModuleList(GetProductType());
                Presenter.UpdateModulesCount(GetProductType());
                Presenter.UpdateTotalModules(GetProductType());
            }
            else
            {
                MessageBox.Show("Такой модуль уже существует. Измените номер модуля");
            }

         
        }

        private string GetIconPath(string pathToImageSubScheme)
        {
            pathToImageSubScheme = pathToImageSubScheme.Remove(pathToImageSubScheme.Length - 4) + "_icon.png";
            return pathToImageSubScheme;
        }

        private void addSimilarBtn_Click(object sender, EventArgs e)
        {
            SimilarModule similarModule = new SimilarModule();
            similarModule.OnApply += AddSimilarModule;
            similarModule.Show();

        }

        private void AddSimilarModule(object sender, SimilarEventArgs e)
        {
            if (!Presenter.IsModuleExist(e.SimilarName, GetProductType()))
            {
                Presenter.AddSimilarModule(e.SimilarName, GetProductType());
            }
            else MessageBox.Show("Модуль с таким номером уже существует. Введите другой номер");

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count!=0)
            {
                string moduleNameWithNumber = modulesLbx.SelectedItem.ToString();
                string moduleName = moduleNameWithNumber.Remove(0, moduleNameWithNumber.IndexOf(' ') + 1);
                Presenter.DeleteModule(moduleName, GetProductType());
            }
        }

        DataTable _moduleInfoTable;

        private void UpdateModuleInfoBtn(object sender, EventArgs e)
        {
            string moduleNameWithNumber = modulesLbx.SelectedItem.ToString();
            string moduleNumber = moduleNameWithNumber.Remove(0, moduleNameWithNumber.IndexOf(' ') + 1);
            Presenter.UpdateModuleInfo(_moduleInfoTable, moduleNumber, GetProductType());
            Presenter.ShowModuleInformation(moduleNumber, GetProductType());
            Presenter.UpdateTotalModules(GetProductType());
        }
        
        private void modulesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count!=0)
            {
                string moduleNumber = modulesLbx.SelectedItem.ToString();
                Presenter.ShowModuleInformation(moduleNumber,GetProductType());
            }
        }



        public void UpdateModuleList(List<string> modulesNumbers)
        {
            modulesLbx.Items.Clear();
            for (int i = 0; i < modulesNumbers.Count; i++)
            {
                modulesLbx.Items.Add(modulesNumbers[i]);
            }
            

        }
        
        public void UpdateAllModuleInfo(DataTable modulesInfoTbl)
        {

            if (modulesInfoTbl != null && modulesInfoTbl.Rows.Count != 0)
            {
                    var viewGenerator = GetViewGenerator(ProductName);
                    viewGenerator.SetupView(allModulesInformationDgv, modulesInfoTbl);

            }
            else
            {
                allModulesInformationDgv.DataSource = null;
                allModulesInformationDgv.Columns.Clear();
                allModulesInformationDgv.Refresh();
            }

            
          
        }
        
        
        public void UpdateDetailDataDataGrid(DataTable table)
        {
            if (table.Rows.Count!=0)
            {
                _moduleInfoTable = table;
                var viewGenerator = GetViewGenerator(ProductName);
                viewGenerator.SetupView(selectedModuleInformationDgv, table);
            }
            else
            {
                selectedModuleInformationDgv.DataSource = null;
                selectedModuleInformationDgv.Refresh();
                
            }
          

        }

        private ViewGenerator GetViewGenerator(string productName)
        {
            return new KitchenUpView();
        }

   

        public void ClearModuleDetailsDgv()
        {
            
            selectedModuleInformationDgv.ViewDefinition=new TableViewDefinition();
            selectedModuleInformationDgv.DataSource = null;
            selectedModuleInformationDgv.Columns.Clear();
            selectedModuleInformationDgv.Refresh();

      
        }

  
    }
}

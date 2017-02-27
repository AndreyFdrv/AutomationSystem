using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.Model;
using Automation.View.Model;

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
            Presenter.UpdateModuleList(GetTypeProduct());
        }

        private void UpdateTotalModulesDatagrid()
        {
            Presenter.UpdateTotalModules(GetTypeProduct());
        }
        


        private ProductTypes GetTypeProduct()
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




        //Buttons and events


        private void add_Click(object sender, EventArgs e)
        {
            ModuleConfigurator configuratorModule = new ModuleConfigurator();
            configuratorModule.OnApply += SetNewModuleInfo;
            configuratorModule.ShowDialog();
        }

        private void SetNewModuleInfo(object sender, ConfiguratorArgs e)
        {
            Presenter.Manager = this;
            Presenter.AddNewModule(new NewModuleData { Name = e.moduleName, Scheme = e.moduleScheme, Type = GetTypeProduct()});
            Presenter.UpdateModuleList(GetTypeProduct());
            Presenter.UpdateModulesCount(GetTypeProduct());
            Presenter.UpdateTotalModules(GetTypeProduct());
        }

        private void addSimilarBtn_Click(object sender, EventArgs e)
        {
            SimilarModule similarModule = new SimilarModule();
            similarModule.OnApply += AddSimilarModule;
            similarModule.Show();

        }

        private void AddSimilarModule(object sender, SimilarEventArgs e)
        {
            Presenter.AddSimilarModule(e.SimilarName, GetTypeProduct());
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count!=0)
            {
                string moduleNameWithNumber = modulesLbx.SelectedItem.ToString();
                string moduleName = moduleNameWithNumber.Remove(0, moduleNameWithNumber.IndexOf(' ') + 1);
                Presenter.DeleteModule(moduleName, GetTypeProduct());
            }
        }

        DataTable _moduleInfoTable;

        private void UpdateModuleInfoBtn(object sender, EventArgs e)
        {
            string moduleNameWithNumber = modulesLbx.SelectedItem.ToString();
            string moduleName = moduleNameWithNumber.Remove(0, moduleNameWithNumber.IndexOf(' ') + 1);
            Presenter.UpdateModuleInfo(_moduleInfoTable, moduleName, GetTypeProduct());
        }
        
        private void modulesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count!=0)
            {
                string moduleNameWithNumber = modulesLbx.SelectedItem.ToString();
                string moduleName = moduleNameWithNumber.Remove(0, moduleNameWithNumber.IndexOf(' ')+1);
                Presenter.ShowModuleInformation(moduleName,GetTypeProduct());
            }
        }



        //Update view methods


        public void UpdateModuleList(List<string> modulesName)
        {
            modulesLbx.Items.Clear();
            for (int i = 0; i < modulesName.Count; i++)
            {
                modulesLbx.Items.Add((i+1)+". "+modulesName[i]);

            }

        }
        
        public void UpdateAllModuleInfo(DataTable modulesInfoTbl)
        {
            allModulesInformationDgv.DataSource = modulesInfoTbl;
            if (modulesInfoTbl!= null)
            {
              //  allModulesInformationDgv.Columns[0].Frozen = true;
              //  allModulesInformationDgv.Columns[1].Frozen = true;
            }
          
        }
        
        
        public void UpdateDetailDataDataGrid(DataTable table)
        {
            _moduleInfoTable = table;
            selectedModuleInformationDgv.DataSource = _moduleInfoTable;
            selectedModuleInformationDgv.Columns[0].Frozen = true;
            selectedModuleInformationDgv.Columns[1].Frozen = true;
        }

        private void selectedModuleInformationDgv_Scroll(object sender, ScrollEventArgs e)
        {
         
                int h = selectedModuleInformationDgv.HorizontalScrollingOffset;
              //  allModulesInformationDgv.HorizontalScrollingOffset = h;
            
        }

        public void ClearModuleDetailsDgv()
        {
            selectedModuleInformationDgv.DataSource = null;
        }
    }
}

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
    public partial class ModuleManager : Form
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
        

        private void AddNewModule()
        {
            new ModuleConfigurator(this).ShowDialog();
        }

        public void SetNewModuleData(NewModuleData data)
        {
            //data.Type = GetTypeProduct();
            Presenter.Manager = this;
            Presenter.AddNewModule(data);
            Presenter.UpdateModuleList(GetTypeProduct());
            Presenter.UpdateModulesCount(GetTypeProduct());
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
            AddNewModule();
        }

        private void addSimilarBtn_Click(object sender, EventArgs e)
        {
            SimilarModule similarModule = new SimilarModule();
            similarModule.OnApplyedName += AddSimilarModule;
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
                Presenter.DeleteModule(modulesLbx.SelectedItem.ToString(), GetTypeProduct());
            }
        }

        DataTable _moduleInfoTable;

        private void UpdateModuleInfoBtn(object sender, EventArgs e)
        {
            Presenter.UpdateModuleInfo(_moduleInfoTable, modulesLbx.SelectedItem.ToString(), GetTypeProduct());
        }
        
        private void modulesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count!=0)
            {
                Presenter.ShowModuleInformation(modulesLbx.SelectedItem.ToString(),GetTypeProduct());
            }
        }



        //Update view methods


        public void UpdateModuleList(List<string> modulesName)
        {
            modulesLbx.Items.Clear();
            foreach (var name in modulesName)
            {
                modulesLbx.Items.Add(name);
            }
        }
        
        public void UpdateAllModuleInfo(DataTable modulesInfoTbl)
        {
            allModulesInformationDgv.DataSource = modulesInfoTbl;
        }

        public void UpdateModuleDetail(DataTable moduleDetailsTbl)
        {
            selectedModuleInformationDgv.DataSource = moduleDetailsTbl;
        }
        
        public void UpdateDetailDataDataGrid(DataTable table)
        {
            selectedModuleInformationDgv.DataSource = table;
        }

        public void UpdateTotalModulesInfo(DataTable table)
        {
            _moduleInfoTable = table;
            allModulesInformationDgv.DataSource = _moduleInfoTable;
        }
    }
}

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
            _productName = productName;
            InitializeComponent();
        //  LoadModules(productName);
        }

        private void LoadModules(string productName)
        {
            
            
        }


        public ModuleManager()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddNewModule();
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

        public void UpdateModuleList(List<string> modulesName)
        {
            listBox1.Items.Clear();
            foreach (var name in modulesName)
            {
                listBox1.Items.Add(name);
            }
        }

        public void UpdateAllModuleInfo(DataTable modulesInfoTbl)
        {
            dataGridView1.DataSource = modulesInfoTbl;
        }

        public void UpdateModuleDetail(DataTable moduleDetailsTbl )
        {
            dataGridView2.DataSource = moduleDetailsTbl;

        }

        private void addSimilarBtn_Click(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void applyBtn_Click(object sender, EventArgs e)
        {

        }



        //Functions


    }
}

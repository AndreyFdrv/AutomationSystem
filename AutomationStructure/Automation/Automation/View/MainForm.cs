using System;
using System.Windows.Forms;
using Automation.View.Model;

namespace Automation.View
{
    public partial class MainForm : Form
    {


        private readonly Presenter _presenter;
        public MainForm()
        {
            _presenter = new Presenter();
            InitializeComponent();
            InitCustomerTable();
        }

        private void about_Click(object sender, EventArgs e)
        {
            new About().Show();
        }



        private void InitCustomerTable()
        {
            CustomerTable.InitCustomerTable(customerDGV);
            customerDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (customerDGV.Rows[1].Cells[4].Value != null)
            {
                new ThicknessMaterialEssential().Show();
            }

        }







        private void openProjectMI_Click(object sender, EventArgs e)
        {
            string pathToFile = Dialogs.GetOpenProjectPath();
            if (pathToFile.Length == 0)
            {
                return;
            }
            _presenter.OpenProject(pathToFile);
        }

        private void newProjectMI_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            _presenter.NewProject();
        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void saveAs_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        private void kitchenUpModules_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = 50;
            modulesPanel.Visible = true;
            ModulesTable.AddKitchenRow(modulesDGV, "Кухня верхние модули");
        }

        private void kitchenDownModules_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = 50;
            modulesPanel.Visible = true;
            ModulesTable.AddKitchenRow(modulesDGV, "Кухня нижние модули");
        }


        private void turn_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = panelCustomer.Height == 240 ? 50 : 240;
        }
    }
}

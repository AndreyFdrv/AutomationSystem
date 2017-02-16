using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Automation.View.Model;

namespace Automation.View
{
    public partial class MainForm : Form
    {


        public Presenter _presenter;
        public MainForm()
        {

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
            customerDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.customerDGV_EditingControlShowing);
        }


        public void UpdateThicknessColumn(string thicknessExt)
        {
            hideThicknessExt = thicknessExt;
            label2.Text = @"Подробная запись кромки: "+thicknessExt.Substring(0,30)+" ...";

        }

        private string hideThicknessExt;


        public void UpdateCustomerString(string customerRecord)
        {
            label3.Text = customerRecord;
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
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            ModulesTable.AddProductRowDgv(productsDgv, "Кухня верхние модули");
            _presenter.AddNewProduct("Кухня верхние модули");

        }

        private void kitchenDownModules_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            ModulesTable.AddProductRowDgv(productsDgv, "Кухня нижние модули");
            _presenter.AddNewProduct("Кухня нижние модули");
        }


        private void turn_Click(object sender, EventArgs e)
        {
            if (panelCustomer.Height == 263)
            {
                panelCustomer.Height = 55;
                turnBtn.Image = Automation.Properties.Resources.arrow_down_icon;
            }
            else
            {
                panelCustomer.Height = 263;
                turnBtn.Image = Automation.Properties.Resources.arrow_up_icon;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string[]> customerRecord = CustomerTable.GetData(customerDGV,hideThicknessExt);
            _presenter.SetCustomer(customerRecord);
        }

        private void customerDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (customerDGV.CurrentCell.ColumnIndex == 2 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            var extendOption= sendingCB.EditingControlFormattedValue.ToString();
            if (extendOption == "персонально")
            {
                ShowThicknessForm();
            }
        }



        private void ShowThicknessForm()
        {
            Form thicknessForm = Application.OpenForms["ThicknessMaterialEssential"];
            if (thicknessForm==null)
            {
                thicknessForm = new ThicknessMaterialEssential(this);
                thicknessForm.Show();
            }
            else
            {
                thicknessForm.Focus();
            }
        }




        private void customerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ShowCustomerHelpForm();
            }
        }


        private void ShowCustomerHelpForm()
        {
            Form customerHelpForm = Application.OpenForms["CustomerHelp"];
            if (customerHelpForm == null)
            {
                customerHelpForm = new CustomerHelp();
                customerHelpForm.Show();
            }
            else
            {
                customerHelpForm.Focus();
            }
        }

        private void productsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string productName = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                new ModuleManager(_presenter,productName).Show();
            }
        }

        public void UpdateProductCount(int count, string nameProduct)
        {
            for (int i = 0; i < productsDgv.RowCount; i++)
            {
                if (productsDgv.Rows[i].Cells[0].Value.ToString()==nameProduct)
                {
                    productsDgv.Rows[i].Cells[1].Value = count;
                }
            }
            
        }
    }
}

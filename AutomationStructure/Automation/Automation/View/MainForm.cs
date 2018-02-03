using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Automation.Model;
using Automation.Presenters;
using Automation.Properties;
using Automation.View.Helps;
using Automation.View.Model;
using Telerik.WinControls;

namespace Automation.View
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public  ProjectPresenter ProjectPresenter;
        public  CustomerMaterialsPresenter CustomerMaterialsPresenter;
        public  ProductsPresenter ProductsPresenter;
        public  ReportPresenter ReportPresenter;

        public MainForm()
        {
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Office2010Silver";
          
        }


        //project methods

        private void openProjectMI_Click(object sender, EventArgs e)
        {
            string pathToFile = Dialogs.GetOpenProjectPath();
            if (pathToFile.Length != 0)
            {
                ProjectPresenter.OpenProject(pathToFile);
            }
        }

        private void newProjectMI_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            ProjectPresenter.NewProject();
            radMenuItem2.Visibility = ElementVisibility.Visible;
        }

        private void save_Click(object sender, EventArgs e)
        {
            string pathToFile = Dialogs.GetSaveProjectPath();
            if (pathToFile.Length == 0)
            {
                return;
            }
            ProjectPresenter.SaveProject(pathToFile);
            MessageBox.Show(@"Проект сохранён.");
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void about_Click(object sender, EventArgs e)
        {
            new About().Show();
        }



        //customer methods

        private void bindCustomerDGVHandlers()
        {
            customerDGV.EditingControlShowing += (sender, e) =>
            {
                if (customerDGV.CurrentCell.ColumnIndex == 2 && e.Control is ComboBox)
                {
                    var comboBox = (ComboBox) e.Control;
                    comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
                }
            };
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            if (sender is DataGridViewComboBoxEditingControl sendingCb)
            {
                var extendOption = sendingCb.EditingControlFormattedValue.ToString();
                if (extendOption == "персонально")
                {
                    ShowThicknessForm();
                }
            }
        }

        private void ShowThicknessForm()
        {
            var thicknessForm = Application.OpenForms["ThicknessMaterialEssential"];
            if (thicknessForm == null)
            {
                thicknessForm = new ThicknessMaterialEssential(this);
                thicknessForm.Show();
            }
            else
            {
                thicknessForm.Focus();
            }
        }
        
        public void UpdateCustomerString(string customerRecord) => label3.Text = customerRecord;

        private string _hideThicknessExt;
        public void UpdateThicknessColumn(string thicknessExt)
        {
            _hideThicknessExt = thicknessExt;
            label2.Text = @"Подробная запись кромки: "+thicknessExt.Substring(0,30)+@" ...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var customerRecord = ModelThickness.GetData(customerDGV, _hideThicknessExt);
            CustomerMaterialsPresenter.SetCustomer(customerRecord);
            CustomerMaterialsPresenter.SetModuleThickness(customerDGV);
        }
        
        private void customerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (e.RowIndex)
                {
                    case 0:
                        ShowCustomerHelpForm("ЛДСП ПОМОЩЬ", "Ldsp.png", "Ldsp_help.rtf");
                        break;
                    case 1:
                        ShowCustomerHelpForm("ДВП ПОМОЩЬ", "Dvp.png", "Ldsp_help.rtf");
                        break;
                    case 2:
                        ShowCustomerHelpForm("КРОМКА ПОМОЩЬ", "Kromka.png", "Kromka_help.rtf");
                        break;
                    case 3:
                        ShowCustomerHelpForm("ФАСАД ПОМОЩЬ", "Fasad.png", "Fasad_help.rtf");
                        break;
                }

            }
        }

        private void ShowCustomerHelpForm(string title, string imageName, string textName)
        {
            var customerHelpForm = Application.OpenForms["Helper"];
            if (customerHelpForm == null)
            {
                customerHelpForm = new Helper(title, imageName, textName);
                customerHelpForm.Show();
            }
            else
            {
                customerHelpForm.Focus();
            }
        }
        

       

        //view all modules methods
        
        private void kitchenUpModules_Click(object sender, EventArgs e)
        {
            AddNewProduct("Кухня верхние модули");
        }

        private void kitchenDownModules_Click(object sender, EventArgs e)
        {
            AddNewProduct("Кухня нижние модули");
        }

        private void AddNewProduct(string productName)
        {
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            ProductsPresenter.AddProductRow(productsDgv, productName);
            ProductsPresenter.AddNewProduct(productName);
        }

        public void UpdateProductCount(int count, string nameProduct)
        {
            for (int i = 0; i < productsDgv.RowCount; i++)
            {
                if (productsDgv.Rows[i].Cells[0].Value.ToString() == nameProduct)
                {
                    productsDgv.Rows[i].Cells[1].Value = count;
                }
            }

        }

        private void productsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string productName = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
              //  new ModuleManager(_presenter, productName).Show();
            }
        }
        

        //UI methods

        private void turn_Click(object sender, EventArgs e)
        {
            if (panelCustomer.Height == 263)
            {
                panelCustomer.Height = 55;
                turnBtn.Image = Resources.arrow_down_icon;
            }
            else
            {
                panelCustomer.Height = 263;
                turnBtn.Image = Resources.arrow_up_icon;
            }
        }

        private void moduleResultsBtn_Click(object sender, EventArgs e)
        {
            new Results().Show();
        }
  


        //for ui testing

        private void MainForm_Load(object sender, EventArgs e)
        {
            newProjectMI_Click(null, null);
            kitchenUpModules_Click(null, null);

            CustomerMaterialsPresenter.InitCustomerTable(customerDGV);
            bindCustomerDGVHandlers();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Automation.Infrastructure;
using Automation.Model;
using Automation.Presenters;
using Automation.View.ModuleViewGenerator;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class ModuleManager : RadForm
    {
        private readonly ProductsPresenter _productsPresenter;
        private readonly ModulePresenter _modulePresenter;
        private readonly string _productName;
        private readonly ProductType _productType;

        public ModuleManager(ProductsPresenter productsPresenter, ModulePresenter modulePresenter, string productName)
        {
            _productsPresenter = productsPresenter;
            _modulePresenter = modulePresenter;
            _productName = productName;
            _productType = GetProductType();
            modulePresenter._view = this;

            InitializeComponent();
            Text = $@"Настройка модулей ""{productName}""";
            _modulePresenter.UpdateModuleList(_productType);
            _modulePresenter.UpdateTotalModules(_productType);

            InitGrids();
        }

        private void InitGrids()
        {
            selectedModuleInfoDatagrid.EnableFastScrolling = true;
            allModulesInfoDatagrid.EnableFastScrolling = true;
            selectedModuleInfoDatagrid.MasterTemplate.BestFitColumns();
            allModulesInfoDatagrid.EnableFiltering = false;
            allModulesInfoDatagrid.EnableGrouping = false;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
        
        private ProductType GetProductType()
        {
            var productType = ProductType.KitchenUp;

            switch (_productName)
            {
                case "Кухня верхние модули":
                    productType = ProductType.KitchenUp;
                    break;
                case "Кухня нижние модули":
                    productType = ProductType.KitchenDown;
                    break;
            }
            return productType;
        }
        
        private void AddNewModuleButton_Click(object sender, EventArgs e)
        {
            var moduleConfiguratorForm = new ModuleConfigurator(_productName);
            moduleConfiguratorForm.OnApply += OnConfiguratorModuleOnOnApply;
            moduleConfiguratorForm.ShowDialog();

            void OnConfiguratorModuleOnOnApply(object moduleConfiguratorSender, ConfiguratorArgs module)
            {
                if (!_modulePresenter.IsModuleExist(module.Number, _productType))
                {
                    _modulePresenter.SetNewModuleInfo(module, _productType);
                    _productsPresenter.UpdateProductModulesCount(_productType);
                }
                else
                {
                    MessageBox.Show(@"Такой модуль уже существует. Измените номер модуля");
                }
            }
        }


        private void AddSimilarModuleButton_Click(object sender, EventArgs e)
        {
            var similarModuleForm = new SimilarModule();
            similarModuleForm.OnApply += OnSimilarModuleFormOnOnApply;
            similarModuleForm.Show();

            void OnSimilarModuleFormOnOnApply(object similarModuleSender, SimilarEventArgs module)
            {
                if (!_modulePresenter.IsModuleExist(module.SimilarName, _productType))
                {
                    _modulePresenter.AddSimilarModule(module.SimilarName, _productType);
                }
                else
                    MessageBox.Show(@"Модуль с таким номером уже существует. Введите другой номер");
            }
        }


        private void DeleteModuleButton_Click(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count != 0)
            {
                _modulePresenter.DeleteModule(GetModuleName(), _productType);
            }
        }

        private string GetModuleName()
        {
            var moduleNameWithNumber = modulesLbx.SelectedItem.ToString();
            var moduleName = moduleNameWithNumber.Remove(0, moduleNameWithNumber.IndexOf(' ') + 1);
            return moduleName;
        }

        private DataTable _moduleInfo;

        private void UpdateModuleInfoButton_Click(object sender, EventArgs e)
        {
            var moduleName = GetModuleName();
            _modulePresenter.UpdateModule(moduleName,_productType,_moduleInfo);
        }


        private void ModulesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count != 0)
            {
                if (modulesLbx.SelectedItem != null)
                {
                    var moduleNumber = modulesLbx.SelectedItem.ToString();
                    _modulePresenter.ShowModuleInformation(moduleNumber, _productType);
                }

            }
        }


        public void UpdateModuleList(List<string> modulesNumbers)
        {
            modulesLbx.Items.Clear();
            for (var i = 0; i < modulesNumbers.Count; i++)
            {
                modulesLbx.Items.Add(i);
            }
        }

        public void UpdateAllModulesInfo(DataTable modulesInfo)
        {
            if (modulesInfo != null && modulesInfo.Rows.Count != 0)
            {
                var viewGenerator = GetViewGenerator(ProductName);
                viewGenerator.SetupView(allModulesInfoDatagrid, modulesInfo);
            }
            else
            {
                allModulesInfoDatagrid.DataSource = null;
                allModulesInfoDatagrid.Columns.Clear();
                allModulesInfoDatagrid.Refresh();
            }
        }


        public void UpdateModuleDetailsInDatagrid(DataTable moduleInfo)
        {
            if (moduleInfo.Rows.Count != 0)
            {
                _moduleInfo = moduleInfo;
                var viewGenerator = GetViewGenerator(ProductName);
                viewGenerator.SetupView(selectedModuleInfoDatagrid, moduleInfo);
            }
            else
            {
                selectedModuleInfoDatagrid.DataSource = null;
                selectedModuleInfoDatagrid.Refresh();
            }
        }

        private ViewGenerator GetViewGenerator(string productName)
        {
            //mock
            return new KitchenUpView();
        }


        public void ClearModuleDetailsDatagrid()
        {
            selectedModuleInfoDatagrid.ViewDefinition = new TableViewDefinition();
            selectedModuleInfoDatagrid.DataSource = null;
            selectedModuleInfoDatagrid.Columns.Clear();
            selectedModuleInfoDatagrid.Refresh();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.Infrastructure;
using Automation.Model;
using Automation.Services;
using Automation.View;

namespace Automation.Presenters
{
    public class ProductsPresenter
    {
        private readonly ProductService _productService;
        private readonly MainForm _view;

        public ProductsPresenter(MainForm view)
        {
            _productService = ServiceFactory.ProductServiceInstance;
            _view = view;
        }

        internal void AddNewProduct(string productName)
        {
            _productService.AddProduct(productName);
        }

        public void AddProductRow(DataGridView datagrid, string moduleName)
        {
            string[] row = { moduleName, "0" };
            datagrid.Rows.Add(row);
        }

        public void UpdateProductModulesCount(ProductType type)
        {
            var countModules = _productService.GetProductModulesCount(type);
            _view.UpdateProductCount(countModules, type.ToString());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Infrastructure;
using Automation.Model;
using Automation.Model.MainModels;

namespace Automation.Services
{
    public class ProductService
    {
        public void AddProduct(string nameProduct)
        {
            var order = Order.Instance;
            var productsCollection = order.GetProductsInfoCollection();
            productsCollection.AddProduct(nameProduct);
        }

        public Product GetProduct(ProductType type)
        {
            var order = Order.Instance;
            var productsCollection = order.GetProductsInfoCollection();
            return productsCollection.GetProduct(type);
        }

        public void DeleteProduct(ProductType type)
        {
            var order = Order.Instance;
            var productsCollection = order.GetProductsInfoCollection();
            productsCollection.DeleteProduct(type);
        }

        public int GetProductModulesCount(ProductType type)
        {
            var order = Order.Instance;
            var productsCollection = order.GetProductsInfoCollection();
            var product = productsCollection.GetProduct(type);
            return product.GetModulesCount();
        }


    }
}

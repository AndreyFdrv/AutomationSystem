using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    public class ProductsCollection
    {
        private List<Product> _products;

        public ProductsCollection()
        {
            _products = new List<Product>();
        }

        public void AddNewProduct(string nameProduct)
        {
            Product product = new Product();
            product.NameProduct = nameProduct;
            _products.Add(product);
        }

        public void DeleteProduct(string nameProduct)
        {
            Product product = _products.First(x => x.NameProduct == nameProduct);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public int GetCountModules(string nameProduct)
        {
            Product product = _products.First(x => x.NameProduct == nameProduct);
            return product.GetCountModules();

        }

    }

}

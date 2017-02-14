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
            Product product = new Product(nameProduct);
            _products.Add(product);
        }

        public void DeleteProduct(string nameProduct)
        {
            Product product = _products.First(x => x.Type == x.GetType(nameProduct));
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public int GetCountModules(string nameProduct)
        {
            Product product = _products.First(x => x.Type ==x.GetType(nameProduct));
            return product.GetCountModules();

        }

        public Product GetProduct(NewModuleData data)
        {
            return _products.First(x => x.Type == data.Type);
        }

        public Product GetProduct(ProductTypes type)
        {
            return _products.First(x => x.Type == type);
        }
    }

}

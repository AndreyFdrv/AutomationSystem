using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Infrastructure;

namespace Automation.Model.MainModels
{
    [Serializable]
    public class ProductsInfoCollection:IProductsInfoCollection
    {
        private readonly List<Product> _products;

        public ProductsInfoCollection()
        {
            _products = new List<Product>();
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        } 

        public void AddProduct(string nameProduct)
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

        //public int GetCountModules(string nameProduct)
        //{
        //    Product product = _products.First(x => x.Type ==x.GetType(nameProduct));
        //    return product.GetCountModules();
        //}

        public Product GetProduct(NewModuleData data)
        {
            return _products.First(x => x.Type == data.Type);
        }

        public Product GetProduct(ProductType type)
        {
            return _products.First(x => x.Type == type);
        }
    }

}

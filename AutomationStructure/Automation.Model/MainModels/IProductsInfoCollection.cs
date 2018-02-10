using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Infrastructure;

namespace Automation.Model.MainModels
{
    public interface IProductsInfoCollection
    {
        List<Product> GetAllProducts();
        void AddProduct(string nameProduct);
        void DeleteProduct(ProductType type);
        Product GetProduct(NewModuleData data);
        Product GetProduct(ProductType type);
    }
}

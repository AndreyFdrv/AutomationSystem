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

    }

}

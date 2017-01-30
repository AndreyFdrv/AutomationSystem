using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    class Order
    {
        public CustomersInfoCollection customersInfoCollection;
        public ProductsCollection productsCollection;

        public string NameOrder { get; set; }

        public Order()
        {
            customersInfoCollection = new CustomersInfoCollection();
            productsCollection = new ProductsCollection();
        }




    }
}

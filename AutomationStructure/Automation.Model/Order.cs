using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
   [Serializable]
   public class Order
    {
        public CustomersInfoCollection CustomersCollection { get; private set; }
        public ProductsInfoCollection ProductsCollection { get; private set; }

        public Order()
        {
            CustomersCollection = new CustomersInfoCollection();
            ProductsCollection = new ProductsInfoCollection();
        }

    }
}

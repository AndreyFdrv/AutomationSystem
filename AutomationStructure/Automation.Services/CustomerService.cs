using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Model.MainModels;

namespace Automation.Services
{
    public class CustomerService
    {
        public string GetTotalCustomerRecord()
        {
            var customersInfoCollection = GetCustomersInfoCollection();
            return customersInfoCollection.GetTotalCustomerRecord();
        }

        public void SetCustomer(List<string[]> customerRecord)
        {
            var customersInfoCollection = GetCustomersInfoCollection();
            customersInfoCollection.SetInputData(customerRecord);
        }

        private ICustomersInfoCollection GetCustomersInfoCollection()
        {
            var order = Order.Instance;
            var customersInfoCollection = order.GetCustomerInfoCollection();
            return customersInfoCollection;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Model.MainModels;

namespace Automation.Services
{
    public class ProjectService
    {
        public void MakeNewProject()
        {
            var order = Order.Instance;
        }

        public void SetCurrentOrder(Project project)
        {
            var order = Order.Instance;
            order.SetCustomerInfoCollection(project.Customer);
            order.SetProductsInfoCollection(project.Products);
        }

        public object GetCurrentOrder()
        {
            var order = Order.Instance;

            return new Project
            {
                Customer = order.GetCustomerInfoCollection(),
                Products = order.GetProductsInfoCollection()
            };
        }
    }

    public class Project
    {
        public CustomersInfoCollection Customer { get; set; }
        public ProductsInfoCollection Products { get; set; }

    }
}

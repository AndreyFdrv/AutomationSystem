using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automation.Model
{
    public  class BLService
    {

        private Order _order;


        public void MakeNewProject()
        {
           _order = new Order();
        }

        public void SaveCurrentProject()
        {
            
        }

        public void GetModelToXML()
        {
            
        }

        public void LoadProject()
        {
            
        }

        //большой метод
        public void ApplyChangesToModel()
        {
            
        }

        public void GetViewFromModel()
        {
            
        }

        public string GetTotalCustomerRecord()
        {
            return _order.customersInfoCollection.GetTotalCustomerRecord();
        }


        public void SetCustomer(List<string[]> customerRecord)
        {
            _order.SetCustomer(customerRecord);
        }

        public void AddNewModule(NewModuleData data)
        {
            var product = _order.productsCollection.GetProduct(data);
            product.AddNewModule(data);
        }

        public void AddNewProduct(string nameProduct)
        {
            _order.productsCollection.AddNewProduct(nameProduct);
        }
    }
}

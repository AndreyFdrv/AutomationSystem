using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    public  class BLService
    {
        //Действия, которые позволяет выполнить сервис модели
        Order _order;


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
    }
}

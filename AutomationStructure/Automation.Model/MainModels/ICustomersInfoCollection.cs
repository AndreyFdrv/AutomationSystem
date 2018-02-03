using System.Collections.Generic;

namespace Automation.Model.MainModels
{
    public interface ICustomersInfoCollection
    {
        void SetInputData(List<string[]> customerData);

        string GetTotalCustomerRecord();
    }
}
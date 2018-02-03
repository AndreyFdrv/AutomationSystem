using System;
using System.Collections.Generic;
using System.Linq;

namespace Automation.Model.MainModels
{
    [Serializable]
    public class CustomersInfoCollection: ICustomersInfoCollection
    {

        private readonly List<CustomerRecord> _records;


        public CustomersInfoCollection()
        {
            _records = new List<CustomerRecord>();
            InitCustomerRecords();
        }

        private void InitCustomerRecords()
        {
            _records.Add(new CustomerRecord { Material = "ЛДСП" });
            _records.Add(new CustomerRecord { Material = "Кромка для ЛДСП" });
            _records.Add(new CustomerRecord { Material = "Задняя панель" });
            _records.Add(new CustomerRecord { Material = "Фасад" });
        }

        public void SetInputData(List<string[]> customerData)
        {
            for (int i = 0; i < customerData.Count; i++)
            {
                _records[i].Material = customerData[i][0];
                _records[i].Information = customerData[i][1];
                _records[i].ThicknessMaterial = customerData[i][2];
            }
        }

        public string GetTotalCustomerRecord()
        {
            return _records.Aggregate(string.Empty,(current, t) =>
                $"{current}Материал: {t.Material} ,Информация: {t.Information} ,Толщина материала: {t.ThicknessMaterial}\n");
        }


    }
}

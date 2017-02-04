using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    public class CustomersInfoCollection
    {

        private List<CustomerRecord> _records;


        public CustomersInfoCollection()
        {
            _records = new List<CustomerRecord>();
            InitCustomerRecords();
        }

        private void InitCustomerRecords()
        {
            _records.Add(new CustomerRecord { Material = "ЛДСП" });
            _records.Add(new CustomerRecord { Material = "bla" });
            _records.Add(new CustomerRecord { Material = "blabla" });
        }

        public void SetData(List<string[]> customerData)
        {
            for (int i = 0; i < customerData.Count; i++)
            {
                _records[i].Material = customerData[i][0].ToString();
                _records[i].CompanyName = customerData[i][1].ToString();
                _records[i].Color = customerData[i][2].ToString();
                _records[i].CodeColor = customerData[i][3].ToString();
                _records[i].ThicknessMaterial = customerData[i][4].ToString();
            }
        }

        public string GetTotalCustomerRecord()
        {
            return _records.Aggregate(string.Empty,
                (current, t) => current + ("Материал: " + t.Material +
                                           " ,Фирма изготовитель: " + t.CompanyName +
                                           " ,Цвет: "+t.Color+
                                           " ,Код цвета: "+t.CodeColor+
                                           " ,Толщина материала: "+t.ThicknessMaterial+
                                           "\n"));
        }
    }
}

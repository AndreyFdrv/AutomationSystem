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

        public DataTable GetTable()
        {
            DataTable table = new DataTable();
            return table;
        }

        public void SetData()
        {
            //устанавливаем данные
        }
    }
}

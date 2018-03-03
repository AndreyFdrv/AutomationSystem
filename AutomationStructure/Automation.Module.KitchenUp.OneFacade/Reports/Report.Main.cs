using System.Data;

namespace KitchenUpModule.OneFacade.Reports
{
    internal partial class Report
    {
        /// <summary>
        /// Высота
        /// </summary>
        public double Height { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public double D { get; set; }



        public DataTable GetModuleReport()
        {
            DataTable table = new DataTable();
            table.Columns.Add("MiddleHeight");
            var row = table.NewRow();
            row.ItemArray = new object[] { MiddleHeight };
            table.Rows.Add(row);
            return table;
        }

    }
}

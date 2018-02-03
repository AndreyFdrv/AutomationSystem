using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    public static class Report
    {

        public static DataTable GetLdspInfo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Номер");
            table.Columns.Add("Размер вдоль листа");
            table.Columns.Add("Кромка 1.");
            table.Columns.Add("Кромка 2.");
            table.Columns.Add("Размер поперёк листа");
            table.Columns.Add("Кромка 1");
            table.Columns.Add("Кромка 2");
            table.Columns.Add("Количество");
            table.Columns.Add("Примечание");

            return table;
        }

        public static DataTable GetBackWallInfo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Номер");
            table.Columns.Add("Размер вдоль листа, мм");
            table.Columns.Add("Размер поперёк листа, мм");
            table.Columns.Add("Количество");
            table.Columns.Add("Примечание");
                     
            return table;
        }

        public static DataTable GetFurnitureInfo()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName="Loops",Caption="Петли"});
            table.Columns.Add(new DataColumn { ColumnName = "Konfirmat", Caption = "Конфирмат" });
            table.Columns.Add(new DataColumn { ColumnName = "Excentric", Caption = "Эксцентрик" });
            table.Columns.Add(new DataColumn { ColumnName = "PolkoDerz", Caption = "Полко держатели" });
            table.Columns.Add(new DataColumn { ColumnName = "PolkoDerzSteklo", Caption = "Полко держатели для стеклянных полок" });
            table.Columns.Add(new DataColumn { ColumnName = "Handles", Caption = "Ручки" });
            table.Columns.Add(new DataColumn { ColumnName = "SimpleNavesn", Caption = "Обычные навесные" });
            table.Columns.Add(new DataColumn { ColumnName = "RegularNaves", Caption = "Регулируемые навесные" });
            table.Columns.Add(new DataColumn { ColumnName = "Gazlifts", Caption = "Газлифты" });

            return table;
        }


        public static DataTable GetFasadeInfo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Высота");
            table.Columns.Add("Ширина");
            table.Columns.Add("Тип");
            table.Columns.Add("Примечание");

            return table;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation.View.Model
{
    public static class CustomerTable
    {
        public static void InitCustomerTable(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            //
            dataGridView1.Rows[0].Cells[0].Value = "ЛДСП";
            dataGridView1.Rows[1].Cells[0].Value = "Кромка для ЛДСП";
            dataGridView1.Rows[2].Cells[0].Value = "Задняя панель";


            var comboboxCell = (DataGridViewComboBoxCell)dataGridView1.Rows[0].Cells[4];
            comboboxCell.Items.Clear();
            comboboxCell.Value = null;

            comboboxCell.Items.Add("10 мм");
            comboboxCell.Items.Add("16 мм");
            comboboxCell.Items.Add("18 мм");
            comboboxCell.Items.Add("20 мм");
            comboboxCell.Items.Add("22 мм");


            var comboboxCell2 = (DataGridViewComboBoxCell)dataGridView1.Rows[1].Cells[4];
            comboboxCell2.Items.Clear();
            comboboxCell2.Value = null;

            comboboxCell2.Items.Add("10 мм");
            comboboxCell2.Items.Add("16 мм");
            comboboxCell2.Items.Add("18 мм");
            comboboxCell2.Items.Add("20 мм");
            comboboxCell2.Items.Add("22 мм");
            comboboxCell2.Items.Add("подробнее");


            var comboboxCell3 = (DataGridViewComboBoxCell)dataGridView1.Rows[2].Cells[4];
            comboboxCell3.Items.Clear();
            comboboxCell3.Value = null;

            comboboxCell3.Items.Add("нет");
            comboboxCell3.Items.Add("3 мм");
            comboboxCell3.Items.Add("4 мм (станд.) ДВА, фанера");
            comboboxCell3.Items.Add("4,2 мм ДВП импорт.");
            comboboxCell3.Items.Add("6 мм");
            comboboxCell3.Items.Add("8 мм");
            comboboxCell3.Items.Add("10 мм");
            comboboxCell3.Items.Add("12 мм");
            comboboxCell3.Items.Add("16 мм");
        }

        public static List<string[]> GetData(DataGridView dataGridView)
        {
            List<string[]> customerInfo = new List<string[]>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string[] record = new string[5];

                for (int i = 0; i < 5; i++)
                {
                    var item = row.Cells[i].Value;
                    if (item == null)
                    {
                        record[i] = "";
                    }
                    else
                    {
                        record[i] = (string) item;
                    }
                   
                }

                customerInfo.Add(record);
            }
            return customerInfo;
        }

    }
}

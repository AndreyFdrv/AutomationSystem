using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation.View
{
    public partial class ThicknessMaterialEssential : Form
    {
        public ThicknessMaterialEssential()
        {
            InitializeComponent();
            LoadFirstTable();
            LoadSecondTable();
        }

        private void LoadSecondTable()
        {
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();

            dataGridView2.Rows[0].Cells[1].Value = "Перед (видимая)";
            dataGridView2.Rows[1].Cells[1].Value = "Лево/право";
            dataGridView2.Rows[2].Cells[1].Value = "Задняя часть";
        }

        private void LoadFirstTable()
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].Cells[1].Value = "Перед (видимая)";
            dataGridView1.Rows[1].Cells[1].Value = "Верх";
            dataGridView1.Rows[2].Cells[1].Value = "Низ";
            dataGridView1.Rows[3].Cells[1].Value = "Задняя часть";

        }
    }
}

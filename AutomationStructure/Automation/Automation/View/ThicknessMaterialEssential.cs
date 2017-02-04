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
        private MainForm _form;

        public ThicknessMaterialEssential(MainForm mf)
        {
            _form = mf;
            InitializeComponent();
            LoadFirstTable();
            LoadSecondTable();
            LoadThirdTable();
        }

        private void LoadThirdTable()
        {
            dataGridView3.Rows.Add();
            dataGridView3.Rows[0].Cells[1].Value = "Периметр фасада";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string thicknessResult = GetResult();
            _form.UpdateThicknessColumn(thicknessResult);



        }

        private string GetResult()
        {
            string thickness = string.Empty;
            thickness += GetThicknessFromDgv(dataGridView1,"Модули");
            thickness += GetThicknessFromDgv(dataGridView2,"Полка");
            thickness += GetThicknessFromDgv(dataGridView3,"Фасад");
            return thickness;
        }


        private string GetThicknessFromDgv(DataGridView dg, string name)
        {
            string result = string.Empty;
            result += name+"\n";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                result += " Цвет: " + row.Cells[0].Value +",";
                result += " Часть модуля: " + row.Cells[1].Value + ",";
                result += " Толщина: " + row.Cells[2].Value + ",";
                result += "\n";
            }
            result += "\n";
            return result;


        }

       
    }
}

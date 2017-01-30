using System;
using System.Windows.Forms;


namespace Automation.View
{
    public partial class Main : Form
    {

        private Controller _controller;
        public Main()
        {
            _controller = new Controller();
            InitializeComponent();
            LoadCustomerTable();
        }

        private void about_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = panelCustomer.Height == 240 ? 50 : 240;
        }

        private void typeProductPanelBtn_Click(object sender, EventArgs e)
        {

        }



        private void LoadCustomerTable()
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


            var comboboxCell = (DataGridViewComboBoxCell) dataGridView1.Rows[0].Cells[4];
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
            comboboxCell2.Items.Add("ещё...");


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


            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);

     
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            if (dataGridView1.Rows[1].Cells[4].Value != null)
                {
                    new ThicknessMaterialEssential().Show();
                }
       
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()=="Кухня верхние модули")
            {
                string[] row = new string[] {"Кухня верхние модули","0"};
              /*  DataGridViewRow row = new DataGridViewRow();
                row.SetValues(1, 2, 2);*/
                dataGridView2.Rows.Add(row);
                comboBox1.Items.Remove("Кухня верхние модули");
            }
            else
            {
                string[] row = new string[] { "Кухня нижние модули", "0" };
                /*  DataGridViewRow row = new DataGridViewRow();
                  row.SetValues(1, 2, 2);*/
                dataGridView2.Rows.Add(row);
                comboBox1.Items.Remove("Кухня нижние модули");
            }

            dataGridView2.Columns[0].Width = 200;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].Width = 200;
        }

        private void файлToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}

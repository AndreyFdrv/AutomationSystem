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
    public partial class SimilarModule : Form
    {
        public SimilarModule()
        {
            InitializeComponent();
        }

        public event EventHandler<SimilarEventArgs> OnApply;

        private void button1_Click(object sender,EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                SimilarEventArgs ea = new SimilarEventArgs();
                ea.SimilarName = textBox1.Text;
                OnApply(sender, ea);
                Close();
            }
            else
                MessageBox.Show("Введите новое название модуля");
        }
    }

    public class SimilarEventArgs : EventArgs
    {
        public string SimilarName { get; set; }
    }
}

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
    public partial class ModuleManager : Form
    {
        public ModuleManager()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ModuleConfigurator().ShowDialog();
        }
    }
}

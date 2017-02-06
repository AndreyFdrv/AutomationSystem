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
        //Presenter 
        public Presenter Presenter { get; set; }
        


        public ModuleManager(Presenter presenter, string productName)
        {
            Presenter = presenter;
            InitializeComponent();
            LoadModules(productName);
        }

        private void LoadModules(string productName)
        {
            
            
        }


        public ModuleManager()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            new ModuleConfigurator(this).ShowDialog();
        }

        private void addSimilarBtn_Click(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void applyBtn_Click(object sender, EventArgs e)
        {

        }



        //Functions


    }
}

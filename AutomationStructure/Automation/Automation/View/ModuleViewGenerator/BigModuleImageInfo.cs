using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Automation.View.ModuleViewGenerator
{
    public partial class BigModuleImageInfo : Telerik.WinControls.UI.RadForm
    {
        public BigModuleImageInfo(string pathImage)
        {
            InitializeComponent();
            LoadImage(pathImage);
        }

        private void LoadImage(string pathImage)
        {
            pictureBox1.Load(Environment.CurrentDirectory+"\\"+pathImage);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Automation.View
{
    public partial class Results : Telerik.WinControls.UI.RadForm
    {
        public Results()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            pictureBox1.Load(Environment.CurrentDirectory+"\\"+ "Кухня верхние модули\\scheme 1\\kitchen-upper-module-table-type1-subtype1_F1-01-0001_result.png");
        }
    }
}

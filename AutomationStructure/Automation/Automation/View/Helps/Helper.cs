using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Automation.View.Helps
{
    public partial class Helper : Telerik.WinControls.UI.RadForm
    {
        public Helper(string title, string imagePath, string textPath)
        {
            InitializeComponent();
            SetFormTitle(title);
            LoadImage(imagePath);
            LoadFile(textPath);
        }

        private void LoadImage(string imagePath)
        {
            pictureBox1.Load(Environment.CurrentDirectory+"\\HelpInfo\\"+imagePath);
        }

        private void SetFormTitle(string title)
        {
            Text = title;
        }

        private void LoadFile(string textPath)
        {
            richTextBox1.LoadFile(Environment.CurrentDirectory + "\\HelpInfo\\"+textPath);
        }
    }
}

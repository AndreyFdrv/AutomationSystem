using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Automation.View
{
    public partial class ModuleConfigurator : Form
    {
        public ModuleConfigurator()
        {
            InitializeComponent();
            LoadPictures();
        }


        private List<string> _pathesToImages;
        private int _index;

        private void LoadPictures()
        {
            //грузим картинки из папки
            _pathesToImages = new List<string>();
            string[] pathes = Directory.GetFiles(Environment.CurrentDirectory + "\\ModuleTypes");
            _pathesToImages = pathes.ToList();
            _index = 0;
            label3.Text = _index.ToString();
            pictureBox1.ImageLocation = _pathesToImages[_index];
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            //передаём в главную форму и даём команду создать новый модуль
            string moduleName = textBox1.Text;
            string moduleType = _pathesToImages[_index];
            Close();
            
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            //назад
            if (_index > 0)
            {
                _index -= 1;
                label3.Text = _index.ToString();
                pictureBox1.ImageLocation = _pathesToImages[_index];
            }
           
          
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (_index < _pathesToImages.Count)
            {
                _index += 1;
                label3.Text = _index.ToString();
                pictureBox1.ImageLocation = _pathesToImages[_index-1];
            }
   
           
        }
    }
}

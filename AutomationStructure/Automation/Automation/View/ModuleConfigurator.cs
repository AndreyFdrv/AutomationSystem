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
using Automation.Model;
using Automation.View.Model;

namespace Automation.View
{
    public partial class ModuleConfigurator : Form
    {
        private ModuleManager _moduleManager;

        public ModuleConfigurator(ModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
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
            
            if (textBox1.Text.Length==0)
            {
                MessageBox.Show("Введите название нового модуля");
                return;
            }
            string moduleName = textBox1.Text;
            string moduleSheme = GetShemeName(_pathesToImages[_index]);
            NewModuleData data = new NewModuleData() {Name = moduleName, Scheme=moduleSheme};
            _moduleManager.SetNewModuleData(data);
            Close();
            
        }

        private string GetShemeName(string pathesToImage)
        {
            FileInfo file = new FileInfo(pathesToImage);
            return file.Name;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            //назад
            if (_index > 0)
            {
                _index -= 1;
                label3.Text = _index.ToString();
                pictureBox1.ImageLocation = _pathesToImages[_index];
                label4.Text = GetShemeName(_pathesToImages[_index]);
            }
           
          
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (_index < _pathesToImages.Count)
            {
                _index += 1;
                label3.Text = _index.ToString();
                pictureBox1.ImageLocation = _pathesToImages[_index-1];
                label4.Text = GetShemeName(_pathesToImages[_index]);
            }
   
           
        }
    }
}

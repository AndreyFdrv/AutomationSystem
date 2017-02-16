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

        public event EventHandler<ConfiguratorArgs> OnApply;

        public ModuleConfigurator()
        {
          
            InitializeComponent();
            LoadSchemeImagies();
        }

       

        private List<string> _pathesToImages;
        private int _index;

        private void LoadSchemeImagies()
        {
            
            _pathesToImages = new List<string>();
            string[] pathes = Directory.GetFiles(Environment.CurrentDirectory + "\\ModuleTypes");
            _pathesToImages = pathes.ToList();
            _index = 0;
            numberLbl.Text = _index.ToString();
           
            schemesPbx.ImageLocation = _pathesToImages[_index];
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            
            if (moduleNameTxb.Text.Length==0)
            {
                MessageBox.Show(@"Введите название нового модуля");
                return;
            }
            string moduleName = moduleNameTxb.Text;
            string moduleScheme = GetSchemeName(_pathesToImages[_index]);
            ConfiguratorArgs args = new ConfiguratorArgs
            {
                moduleName = moduleName,
                moduleScheme = moduleScheme
            };

            OnApply(this, args);
            Close();
            
        }

        private string GetSchemeName(string pathesToImage)
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
                numberLbl.Text = _index.ToString();
                schemesPbx.ImageLocation = _pathesToImages[_index];
                schemeNameLbl.Text = GetSchemeName(_pathesToImages[_index]);
            }
           
          
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (_index < _pathesToImages.Count)
            {
                _index += 1;
                numberLbl.Text = _index.ToString();
                schemesPbx.ImageLocation = _pathesToImages[_index-1];
                schemeNameLbl.Text = GetSchemeName(_pathesToImages[_index]);
            }
        }
    }

    public class ConfiguratorArgs : EventArgs
    {
        public string moduleName { get; set; }
        public string moduleScheme { get; set; }
    }
}

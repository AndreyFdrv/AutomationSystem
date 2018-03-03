using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class ModuleConfigurator : RadForm
    {

        public event EventHandler<ConfiguratorArgs> OnApply;
        private string modulePath;
        private new string ProductName { get; set; }

        public ModuleConfigurator(string productName)
        {
          
            InitializeComponent();
            ProductName = productName;
            LoadSchemeImagies(productName);
            SetupFirstModule();

            radListView1.AllowRemove = false;
            radListView1.AllowEdit = false;
           
        }

        private void SetupFirstModule()
        {
            if (radListView1.Items.Count!=0)
            {
                schemeTxb.Text = radListView1.SelectedItem.Text;
                modulePath = radListView1.SelectedItem.Tag.ToString();
            }
        }
                  

        private void LoadSchemeImagies(string productName)
        {

            string pathToModules = Environment.CurrentDirectory.Replace("\\Automation\\Automation\\bin\\Debug", "");
            var moduleDirectives = Directory.GetDirectories(pathToModules, "*.Module." + productName+".*");

            radListView1.ItemSize = new Size(200, 200);
            radListView1.ItemSpacing = 10;

            foreach (var moduleDirective in moduleDirectives)
            {
                string pathToMainModuleImage = moduleDirective + "\\bin\\Debug\\module_image";
                var moduleImage = Directory.GetFiles(pathToMainModuleImage, "*.png");
                if (moduleImage.Length > 0)
                {
                    var schemeName = Path.GetFileNameWithoutExtension(moduleImage[0]);

                    ListViewDataItem item = new ListViewDataItem(schemeName)
                    {
                        BackColor = Color.WhiteSmoke,
                        Image = Image.FromFile(moduleImage[0]),
                        Text = schemeName,     
                        Tag = moduleDirective,
                        NumberOfColors = 2,
                        ImageAlignment = ContentAlignment.MiddleCenter,
                        TextImageRelation = TextImageRelation.ImageAboveText,
                        TextAlignment = ContentAlignment.BottomCenter
                    };
                    radListView1.Items.Add(item);
                }
            }

        }



        private void applyBtn_Click(object sender, EventArgs e)
        {
            
            if (moduleNumberTxb.Text.Length==0 | schemeTxb.Text.Length==0 | modulePath == null)
            {
                MessageBox.Show(@"Введите номер нового модуля и выберите форму и подтип формы модуля");
                return;
            }
            string moduleNumber = moduleNumberTxb.Text;
            string moduleSchemeName = schemeTxb.Text;
            ConfiguratorArgs args = new ConfiguratorArgs
            {
                Name = moduleNumber,
                Scheme = moduleSchemeName,
                ModulePath = modulePath
            };

            OnApply(this, args);
            Close();
            
        }

      

        private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            schemeTxb.Text = radListView1.SelectedItem.Text;
            modulePath = radListView1.SelectedItem.Tag.ToString();
        }
    }
             

    public class ConfiguratorArgs : EventArgs
    {
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string ModulePath { get; set; }

    }
}

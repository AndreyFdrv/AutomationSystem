﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using Automation.Model;
using Automation.View.Model;
using Telerik.WinControls.Interfaces;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class ModuleConfigurator : Telerik.WinControls.UI.RadForm
    {

        public event EventHandler<ConfiguratorArgs> OnApply;

        public ModuleConfigurator(string productName)
        {
          
            InitializeComponent();
            ProductName = productName;
            LoadSchemeImagies(productName);

            radListView1.AllowRemove = false;
            radListView1.AllowEdit = false;
           
        }


        private new string ProductName { get; set; }
        private List<string> _pathesToImages;


        XDocument doc;

        private void LoadSchemeImagies(string productName)
        {

            string pathToInfoFile = Environment.CurrentDirectory + "\\"+productName+"\\info.xml";

            doc = XDocument.Load(pathToInfoFile);

            var schemeModules = doc.Root.Elements("type").Select(t => new ModuleItem { Name = t.Attribute("name").Value, Folder = t.Attribute("folder").Value, ImagePath = t.Attribute("imagePath").Value });

            if (schemeModules.Count()!=0)
            {
                radListView1.ItemSize = new Size(200, 200);
                radListView1.ItemSpacing = 10;

                foreach (var scheme in schemeModules)
                {
                    ListViewDataItem item = new ListViewDataItem(scheme.Name)
                    {
                        BackColor = Color.WhiteSmoke,
                        Image = Image.FromFile(Environment.CurrentDirectory + "\\"+productName+"\\"+scheme.Folder+"\\"+scheme.ImagePath),
                        Text = scheme.Name,
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
            
            if (moduleNumberTxb.Text.Length==0 | schemeTxb.Text.Length==0 | subSchemeTxb.Text.Length==0)
            {
                MessageBox.Show(@"Введите номер нового модуля и выберите форму и подтип формы модуля");
                return;
            }
            string moduleNumber = moduleNumberTxb.Text;
            string moduleSchemeName = schemeTxb.Text;
            string modulSubSchemeName = subSchemeTxb.Text;
            ConfiguratorArgs args = new ConfiguratorArgs
            {
                Number = moduleNumber,
                SchemeName = moduleSchemeName,
                SubSchemeName = modulSubSchemeName
            };

         //   OnApply(this, args);
            Close();
            
        }




        private void radButton2_Click(object sender, EventArgs e)
        {
            radListView1.ItemSize = new Size(200,200);
            radListView1.ItemSpacing = 10;
           // radListView1.Padding = Padding()
            //adding item
            ListViewDataItem item = new ListViewDataItem("Module 1")
            {
                BackColor = Color.WhiteSmoke,
                Image = Image.FromFile(Environment.CurrentDirectory + "\\1.png"),
                Font = new Font("Segoe UI",10, FontStyle.Bold),
                Text = "Module 1",
                NumberOfColors = 2,
                ImageAlignment = ContentAlignment.MiddleCenter,
                TextImageRelation = TextImageRelation.ImageAboveText,
                TextAlignment = ContentAlignment.BottomCenter,
            
            };

            ListViewDataItem item2 = new ListViewDataItem("Module 2")
            {
                BackColor = Color.WhiteSmoke,
                Image = Image.FromFile(Environment.CurrentDirectory + "\\1.png"),
                Text = "Module 2",
                NumberOfColors = 2,
                ImageAlignment = ContentAlignment.MiddleCenter,
                TextImageRelation = TextImageRelation.ImageAboveText,
                TextAlignment = ContentAlignment.BottomCenter,
             
            };

            radListView1.Items.Add(item);
            radListView1.Items.Add(item2);

        }

  

        private void radListView1_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {

            OpenSubSchemeSelector();
        }

        private void OpenSubSchemeSelector()
        {
            var typeNode = doc.Root.Elements("type").First(t => t.Attribute("name").Value == schemeTxb.Text);
            var items =
                typeNode.Elements("subType")
                    .Select(
                        t =>
                            new ModuleItem
                            {
                                Name = t.Attribute("name").Value,
                                Folder = t.Attribute("folder").Value,
                                ImagePath = t.Attribute("imagePath").Value
                            })
                    .ToList();
            SubSchemeModule subSchemeSelector = new SubSchemeModule(items,ProductName);
            subSchemeSelector.onTypeChanged += SetSubSchemeType;
            subSchemeSelector.Show();
        }

        private void SetSubSchemeType(object sender, SchemeArgs e)
        {
            subSchemeTxb.Text = e.SubSchemeName;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (schemeTxb.Text!= string.Empty)
            {
                OpenSubSchemeSelector();
            }
            else MessageBox.Show("Сначала выберите форму модуля");
        }

        private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            schemeTxb.Text = radListView1.SelectedItem.Text;
        }
    }

    public class ModuleItem
    {
        public string Name { get; set; }
        public string Folder { get; set; }
        public string ImagePath { get; set; }

    }
        

    public class ConfiguratorArgs : EventArgs
    {
        public string Number { get; set; }
        public string SchemeName { get; set; }
        public string SubSchemeName { get; set; }

    }
}

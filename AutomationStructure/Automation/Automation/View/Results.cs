﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Model.Modules;
using Automation.View.ModuleViewGenerator;
using AutomationControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class Results : Telerik.WinControls.UI.RadForm
    {
        private Presenter Presenter { get; set; }


        public Results(Presenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            HideAllPages();
            LoadProducts();
        }

        private void HideAllPages()
        {
            foreach (var page in radPageView1.Pages)
            {
                page.Item.Visibility = ElementVisibility.Collapsed;
            }
           
            
        }

        private void LoadProducts()
        {
            var products = Presenter.GetAllProducts().Select(x=>x.Type.ToString()).ToList();
            foreach (var page in radPageView1.Pages)
            {
                if (products.Contains(page.Title))
                {
                    LoadModules(page);
                   // LoadReport(page);
                    page.Item.Visibility = ElementVisibility.Visible;
                }
            }
        }

        private void LoadReport(RadPageViewPage page)
        {

        }

        private void LoadModules(RadPageViewPage page)
        {
            var productName = page.Title;
            var product= Presenter.GetProductByName(productName);
            var modules = product.GetAllProducts();
            FlowLayoutPanel panel = flowLayoutPanel2; //get flow control from page
         
            foreach (var module in modules)
            {
                ModuleInfo infoModule = new ModuleInfo();
                var result = module.Calculate();
                infoModule.BindData(result.ModuleName,result.ImagePath,result.DimensionInfo,result.DetailsInfo,result.ShelfInfo,result.FurnitureInfo,result.LoopsInfo);
                infoModule.Width = flowLayoutPanel2.Width - 3;
                panel.Controls.Add(infoModule);
            }
            
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Automation.Controls;
using Automation.Infrastructure;
using Automation.Model;
using Automation.View.ModuleViewGenerator;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Data;
using Automation.Presenters;

namespace Automation.View
{
    public partial class Results : Telerik.WinControls.UI.RadForm
    {
        public ReportPresenter Presenter { get; set; }

        
        public Results()
        {
            InitializeComponent();
            HideAllPages();
            LoadProducts();
            LoadReport();
            this.reportModule.onGroupModeChanged += loadNewReportData;
        }

        private void loadNewReportData(object sender, ReportsArgs e)
        {
            if(e.isGroupMode)
            {
              //  int stop = 10;
            }
            else
            {
                //int stop = 10;
            }
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
            //var products = Presenter.GetAllProducts().Select(x=>x.Type.ToString()).ToList();
            //foreach (var page in radPageView1.Pages)
            //{
            //    if (products.Contains(page.Title))
            //    {
            //        LoadModules(page);
            //        page.Item.Visibility = ElementVisibility.Visible;
            //    }
            //}
        }

        private void LoadReport()
        {
           radPageViewPage3.Item.Visibility = ElementVisibility.Visible;

           List<CalculationItem> detailsItems = MakeFlatList(detailsForModules);
           var ldspTable = BindToLdspTable(Report.GetLdspInfo(), detailsItems);

           List<CalculationItem> backWallItems = MakeFlatList(backItemsForModules);
           var backTable = BindToBackTable(Report.GetBackWallInfo(), backWallItems);

            List<FurnitureCalculationItem> furnitureItems = MakeFlatList(furnitureItemsForModules);
            var furnityreTable = BindToFurnitureTable(Report.GetFurnitureInfo(), furnitureItems);

            List<FasadeCalculationItem> fasadeItems = MakeFlatList(fasadeItemsForModules);
            var fasadeTable = BindToFasadeTable(Report.GetFasadeInfo(), fasadeItems);

           reportModule.BindData(ldspTable, backTable, furnityreTable, fasadeTable);
        }

        private DataTable BindToBackTable(DataTable table, List<CalculationItem> items)
        {
            if (false)
            {
                var result = items.GroupBy(x => new
                {
                    x.DimentionAlong,
                    x.DimentionAcross
                }).Select(x => new
                {
                    DimentionAlong = x.Key.DimentionAlong,
                    DimentionAcross = x.Key.DimentionAcross,
                    Count = x.Sum(t => t.Count)
                }).ToList();

                for (int i = 0; i < result.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = result[i].DimentionAlong;
                    row[2] = result[i].DimentionAcross;
                    row[3] = result[i].Count;
                    row[4] = "";
                    table.Rows.Add(row);
                }

            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = items[i].DimentionAlong;
                    row[2] = items[i].DimentionAcross;
                    row[3] = items[i].Count;
                    row[4] = items[i].Note;
                    table.Rows.Add(row);
                }

            }

            return table;
        }

        private DataTable BindToLdspTable(DataTable table, List<CalculationItem> items)
        {
            
            if(true)
            {
                var result = items.GroupBy(x => new
                {
                    x.DimentionAlong,
                    x.DimentionAcross,
                    x.DimentionAcrossKromka1,
                    x.DimentionAcrossKromka2,
                    x.DimentionAlongKromka1,
                    x.DimentionAlongKromka2
                }).Select(x => new
                {
                    DimentionAlong = x.Key.DimentionAlong,
                    DimentionAcross = x.Key.DimentionAcross,
                    DimentionAcrossKromka1 = x.Key.DimentionAcrossKromka1,
                    DimentionAcrossKromka2 = x.Key.DimentionAcrossKromka2,
                    DimentionAlongKromka1 = x.Key.DimentionAlongKromka1,
                    DimentionAlongKromka2 = x.Key.DimentionAlongKromka2,
                    Count = x.Sum(t=>t.Count)
                }).ToList();

                for (int i = 0; i < result.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = result[i].DimentionAlong;
                    row[2] = result[i].DimentionAlongKromka1;
                    row[3] = result[i].DimentionAlongKromka2;
                    row[4] = result[i].DimentionAcross;
                    row[5] = result[i].DimentionAcrossKromka1;
                    row[6] = result[i].DimentionAcrossKromka2;
                    row[7] = result[i].Count;
                    row[8] = "";
                    table.Rows.Add(row);
                }

            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = items[i].DimentionAlong;
                    row[2] = items[i].DimentionAlongKromka1;
                    row[3] = items[i].DimentionAlongKromka2;
                    row[4] = items[i].DimentionAcross;
                    row[5] = items[i].DimentionAcrossKromka1;
                    row[6] = items[i].DimentionAcrossKromka2;
                    row[7] = items[i].Count;
                    row[8] = "";
                    table.Rows.Add(row);
                }

            }

            return table;
        }

        private DataTable BindToFurnitureTable(DataTable table, List<FurnitureCalculationItem> items)
        {
            if (true)
            {
                var result = items.GroupBy(x => new
                {
                    x.Loops,
                    x.Konfirmat,
                    x.Excentric,
                    x.PolkoDerz,
                    x.PolkoDerzSteklo,
                    x.Handles,
                    x.SimpleNavesn,
                    x.RegularNaves,
                    x.Gazlifts
                }).Select(x => new
                {
                    Loops = x.Sum(t=>int.Parse(t.Loops)),
                    Konfirmat = x.Sum(t=>int.Parse(t.Konfirmat)),
                    Excentric = x.Sum(t=>int.Parse(t.Excentric)),
                    PolkoDerz = x.Sum(t=>int.Parse(t.PolkoDerz)),
                    PolkoDerzSteklo = x.Sum(t=>int.Parse(t.PolkoDerzSteklo)),
                    Handles = x.Sum(t => int.Parse(t.Handles)),
                    SimpleNavesn = x.Sum(t => int.Parse(t.SimpleNavesn)),
                    RegularNaves = x.Sum(t => int.Parse(t.RegularNaves)),
                    Gazlifts = x.Sum(t => int.Parse(t.Gazlifts)),
                }).ToList();

                for (int i = 0; i < result.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = result[i].Loops;
                    row[2] = result[i].Konfirmat;
                    row[3] = result[i].Excentric;
                    row[4] = result[i].PolkoDerz;
                    row[5] = result[i].Handles;
                    row[6] = result[i].SimpleNavesn;
                    row[7] = result[i].RegularNaves;
                    row[8] = result[i].Gazlifts;
                    table.Rows.Add(row);
                }

            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = items[i].Loops;
                    row[2] = items[i].Konfirmat;
                    row[3] = items[i].Excentric;
                    row[4] = items[i].PolkoDerz;
                    row[5] = items[i].Handles;
                    row[6] = items[i].SimpleNavesn;
                    row[7] = items[i].Gazlifts;
                    row[8] = "";
                    table.Rows.Add(row);
                }

            }

            return table;
        }

        private DataTable BindToFasadeTable(DataTable table, List<FasadeCalculationItem> items)
        {
            if (true)
            {
                var result = items.GroupBy(x => new
                {
                    x.DimentionAcross,
                    x.DimentionAcrossKromka1,
                    x.DimentionAcrossKromka2,
                    x.DimentionAlong                    
                }).Select(x => new
                {
                    DimentionAcross = x.Key.DimentionAcross,
                    DimentionAcrossKromka1 = x.Key.DimentionAcrossKromka1,
                    DimentionAcrossKromka2 = x.Key.DimentionAcrossKromka2,
                    DimentionAlong = x.Key.DimentionAlong,
                    Count = x.Sum(t=>t.Count)                    
                }).ToList();

                for (int i = 0; i < result.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = result[i].DimentionAcross;
                    row[2] = result[i].DimentionAcrossKromka1;
                    row[3] = result[i].DimentionAcrossKromka2;
                   
                    table.Rows.Add(row);
                }

            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    row[1] = items[i].DimentionAcross;
                    row[2] = items[i].DimentionAcrossKromka1;
                    row[3] = items[i].DimentionAcrossKromka2;
                    table.Rows.Add(row);
                }

            }

            return table;
        }

        private List<T> MakeFlatList<T>(List<List<T>> modules ) 
        {
            List<T> result = new List<T>();
            foreach (List<T> detailsModule in modules)
            {
                foreach (var item in detailsModule)
                {
                    result.Add(item);
                }
            }
            return result;           
        }
        
        List<List<CalculationItem>> detailsForModules = new List<List<CalculationItem>>();
        List<List<CalculationItem>> backItemsForModules =  new List<List<CalculationItem>>();
        List<List<FurnitureCalculationItem>> furnitureItemsForModules = new List<List<FurnitureCalculationItem>>();
        List<List<FasadeCalculationItem>> fasadeItemsForModules = new List<List<FasadeCalculationItem>>();

        private void LoadModules(RadPageViewPage page)
        {
            //var productName = page.Title;
            //var product= Presenter.GetProductByName(productName);
            //var modules = product.GetAllModules();  
            
            //FlowLayoutPanel panel = flowLayoutPanel2; //get flow control from page
         
            //foreach (var module in modules)
            //{
            //    ModuleInfo infoModule = new ModuleInfo();
            //    var result = module.Calculate();
            //    detailsForModules.Add(module.GetDetailsInfo());
            //    backItemsForModules.Add(module.GetBackItems());
            //    furnitureItemsForModules.Add(module.GetFurnitureItems());
            //    fasadeItemsForModules.Add(module.GetFasadeItems());

            //    infoModule.BindData(result.ModuleName,result.ImagePath,result.DimensionInfo,result.DetailsInfo,result.ShelfInfo,result.FurnitureInfo,result.LoopsInfo);
            //    infoModule.Width = flowLayoutPanel2.Width - 3;
            //    panel.Controls.Add(infoModule);
            //}
            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void reportModule_Load(object sender, System.EventArgs e)
        {

        }
    }
}

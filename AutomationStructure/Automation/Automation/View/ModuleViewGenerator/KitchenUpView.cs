using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Automation.View.ModuleViewGenerator
{
    [Serializable]
    public class KitchenUpView: ViewGenerator
    {



        private void SetSchemeImage(DataGridView dgv, string schemeName)
        {
            string pathToFile = Environment.CurrentDirectory + "\\KitchenUPShemes\\" + schemeName;
            Bitmap image = new Bitmap(pathToFile);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.DataPropertyName = "Форма модуля";
            dgv.Rows[0].Cells["Форма модуля"].Value = image;

        }

        private GridViewComboBoxColumn GetBackWallColumns()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn();

            column.Name = "Задняя стенка2";
            column.HeaderText = "Задняя стенка";
            column.FieldName = "Задняя стенка";
            column.DataSource = new List<string>
            {
                "Гв (Крепление на гвозди)",
                "Ч+Гв (выпиливание четверти под заднюю панель, крепление на гвозди)",
                "ПАЗ (выпиливание штробы, в неё вставляем ДВП",
                "Что это такое"
            };
            return column;
          
        }

        private GridViewComboBoxColumn GetFacadeMaterial()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn();
            column.Name = "Материал фасада2";
            column.HeaderText = "Материал фасада";
            column.FieldName = "Материал фасада";
            column.DataSource = new List<string>
            {
                "нет",
                "Верт (тоже ЛДСП, фактура верт.)",
                "Гориз (тоже ЛДСП, фактура гориз.)",
                "Глухой (фасад глухой)",
                "Стекло (фасад со стеклом)",
                "Что это? (помощь)"
            };
            return column;
        }

        private GridViewComboBoxColumn GetFacadeType()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn();
            column.Name = "Тип фасада2";
            column.HeaderText = "Тип фасада";
            column.FieldName = "Тип фасада";
            column.DataSource = new List<string>
            {
                "накидной"
            };
            return column;
        }

        private GridViewComboBoxColumn GetShelfPO()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn
            {
                Name = "Полка по ширине секции (шт)2",
                HeaderText = "Полка по ширине секции (шт)",
                FieldName = "Полка по ширине секции (шт)",
                DataSource = new List<string>
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "Что это?"
                }
            };
            return column;
        }

        private GridViewComboBoxColumn GetShelfMinus2MM()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn
            {
                Name = "Полка - 2мм (шт)2",
                HeaderText = "Полка - 2мм (шт)",
                FieldName = "Полка - 2мм (шт)",
                DataSource = new List<string>
                {
                    "1",
                    "1 стекло",
                    "2",
                    "2 стекло",
                    "3",
                    "3 стекло",
                    "4",
                    "4 стекло",
                    "5",
                    "5 стекло"
                }
            };
            return column;
        }

        private GridViewImageColumn GetIcon()
        {
            GridViewImageColumn column = new GridViewImageColumn
            {
                Name ="Icon",
                HeaderText = "Изображение"
        };

            return column;

        }

        private  DataTable resultTable;

        public override void SetupView(RadGridView dgv, DataTable table)
        {

            resultTable = table;

            dgv.DataSource = table;

            dgv.MasterTemplate.AllowAddNewRow = false;
            dgv.Rows[0].Height = 40;

          

            //pinned
            dgv.Columns[0].IsPinned = true;
            dgv.Columns[1].IsPinned = true;
            dgv.Columns[2].IsPinned = true;
            //dgv.Columns[3].IsPinned = true;

            dgv.Columns["Номер модуля"].Width = 100;
            dgv.Columns["Форма модуля"].Width = 100;
            

            dgv.Columns["Изображение"].Width = 100;
            dgv.Columns["Изображение"].IsVisible = false;

            dgv.Columns["Высота модуля (мм)"].Width = 100;
            dgv.Columns["Ширина модуля (мм)"].Width = 100;
            dgv.Columns["Глубина модуля (мм)"].Width = 100;
            dgv.Columns["A размер (мм)"].Width = 100;
            dgv.Columns["B размер (мм)"].Width = 100;
            dgv.Columns["C размер (мм)"].Width = 100;
            dgv.Columns["D размер (мм)"].Width = 100;
            dgv.Columns["Задняя стенка"].Width = 100; //10
            dgv.Columns["Задняя стенка"].IsVisible = false;

            dgv.Columns["Полка по ширине секции (шт)"].Width = 100;
            dgv.Columns["Полка по ширине секции (шт)"].IsVisible = false;

            dgv.Columns["Полка - 2мм (шт)"].Width = 100;
            dgv.Columns["Полка - 2мм (шт)"].IsVisible = false;

            dgv.Columns["Полка разделительная (шт)"].Width = 100;
            dgv.Columns["Полка стеклянная (шт)"].Width = 100;
            dgv.Columns["№ схемы фасада"].Width = 100;

            dgv.Columns["Тип фасада"].Width = 100;
            dgv.Columns["Тип фасада"].IsVisible = false;

            dgv.Columns["Горизонтальный размер"].Width = 100;
            dgv.Columns["Вертикальный размер"].Width = 100;

            dgv.Columns["Материал фасада"].Width = 100; //18
            dgv.Columns["Материал фасада"].IsVisible = false;




            var backwall = GetBackWallColumns();
            dgv.Columns.Insert(10,backwall);

            var facadeMaterial = GetFacadeMaterial();
            dgv.Columns.Insert(20,facadeMaterial);

            var facadeType = GetFacadeType();
            dgv.Columns.Insert(16,facadeType);

            var shelfPo = GetShelfPO();
            dgv.Columns.Insert(11,shelfPo);

            var shelfMin = GetShelfMinus2MM();
            dgv.Columns.Insert(12,shelfMin);

            var iconCol = GetIcon();
            dgv.Columns.Insert(3,iconCol);


            foreach (var column in dgv.Columns )
            {
                column.WrapText = true;
                column.Width = 150;
            }

            dgv.Columns[3].IsPinned = true;

            dgv.CellFormatting += Dgv_CellFormatting;

            dgv.CellDoubleClick += Dgv_CellDoubleClick;

            dgv.Refresh();

        }

        private void Dgv_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                var path = resultTable.Rows[e.RowIndex][2].ToString();
                var parts = path.Split('_');
                var bigImagePath = parts[0] + "_" + parts[1] + "_big.png";
                //MessageBox.Show(bigImagePath);
                new BigModuleImageInfo(bigImagePath).Show();

            }
           
        }

        private void Dgv_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (e.CellElement.ColumnIndex == 3 )
                {
                    if (resultTable.Rows[e.RowIndex]["Изображение"].ToString().Length != 0)
                    {
                        var pathToImage = Environment.CurrentDirectory + "\\" + resultTable.Rows[e.RowIndex]["Изображение"];
                        e.CellElement.Image = Image.FromFile(pathToImage);
                    }
                   
                }

            }
            catch (Exception ex)
            {
                
            }
        
        }
    }
}

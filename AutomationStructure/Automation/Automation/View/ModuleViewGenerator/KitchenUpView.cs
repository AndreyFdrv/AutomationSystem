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
            column.Name = "Материал фасада";
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
            column.Name = "Тип фасада";
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
                Name = "Полка по ширине секции (шт)",
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
                Name = "Полка - 2мм (шт)",
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

  

        public override void SetupView(RadGridView dgv, DataTable table)
        {
            dgv.DataSource = table;
            
            

            //pinned
            dgv.Columns[0].IsPinned = true;
            dgv.Columns[1].IsPinned = true;
            dgv.Columns[2].IsPinned = true;

            dgv.Columns["Номер модуля"].Width = 100;
            dgv.Columns["Форма модуля"].Width = 100;
            

            dgv.Columns["Изображение"].Width = 100;
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
            dgv.Columns["Полка - 2мм (шт)"].Width = 100;
            dgv.Columns["Полка разделительная (шт)"].Width = 100;
            dgv.Columns["Полка стеклянная (шт)"].Width = 100;
            dgv.Columns["№ схемы фасада"].Width = 100;
            dgv.Columns["Тип фасада"].Width = 100;
            dgv.Columns["Вертикальный размер"].Width = 100;
            dgv.Columns["Материал фасада"].Width = 100;




            var backwall = GetBackWallColumns();
            dgv.Columns.Insert(10,backwall);

            foreach (var column in dgv.Columns )
            {
                column.WrapText = true;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation.Model.Modules.KitchenUpModule
{
    [Serializable]
    public class KitchenUpViewUtility
    {

        public void GetColumnsForView(DataGridView dataGridView, string schemeName)
        {
            DataGridViewComboBoxColumn backWallColumn = GetBackWallColumns();
            DataGridViewComboBoxColumn facadeMaterialColumn = GetFacadeMaterial();
            DataGridViewComboBoxColumn facadeTypeColumn = GetFacadeType();
            DataGridViewComboBoxColumn shelfPoColumn = GetShelfPO();
            DataGridViewComboBoxColumn shelfMinus = GetShelfMinus2MM();
            SetSchemeImage(dataGridView,schemeName);
            dataGridView.Columns.Add(backWallColumn);
            dataGridView.Columns.Add(facadeMaterialColumn);
            dataGridView.Columns.Add(facadeTypeColumn);
            dataGridView.Columns.Add(shelfPoColumn);
            dataGridView.Columns.Add(shelfMinus);
            
        }

        private void SetSchemeImage(DataGridView dgv, string schemeName)
        {
            string pathToFile = Environment.CurrentDirectory + "\\KitchenUPShemes\\" + schemeName;
            Bitmap image = new Bitmap(pathToFile);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.DataPropertyName = "Форма модуля";
            dgv.Rows[0].Cells["Форма модуля"].Value = image;

        }

        private DataGridViewComboBoxColumn GetBackWallColumns()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            column.Name = "Задняя стенка";
            column.HeaderText = "Задняя стенка";
            column.DataPropertyName = "Задняя стенка";
            column.DataSource = new List<string>
            {
                "Гв (Крепление на гвозди)",
                "Ч+Гв (выпиливание четверти под заднюю панель, крепление на гвозди)",
                "ПАЗ (выпиливание штробы, в неё вставляем ДВП",
                "Что это такое"
            };
            return column;

        }

        private DataGridViewComboBoxColumn GetFacadeMaterial()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Name = "Материал фасада";
            column.HeaderText = "Материал фасада";
            column.DataPropertyName = "Материал фасада";
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

        private DataGridViewComboBoxColumn GetFacadeType()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Name = "Тип фасада";
            column.HeaderText = "Тип фасада";
            column.DataPropertyName = "Тип фасада";
            column.DataSource = new List<string>
            {
                "накидной"
            };
            return column;
        }

        private DataGridViewComboBoxColumn GetShelfPO()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn
            {
                Name = "Полка по ширине секции (шт)",
                HeaderText = "Полка по ширине секции (шт)",
                DataPropertyName = "Полка по ширине секции (шт)",
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

        private DataGridViewComboBoxColumn GetShelfMinus2MM()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn
            {
                Name = "Полка - 2мм (шт)",
                HeaderText = "Полка - 2мм (шт)",
                DataPropertyName = "Полка - 2мм (шт)",
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




    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.View.Helps;
using Telerik.WinControls.UI;

namespace Automation.View.ModuleViewGenerator
{
    [Serializable]
    public class KitchenUpView: ViewGenerator
    {


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
                "Что это?"
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
                "Накладной",
                "Внутренний",
                "Что это?"
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
            dgv.Columns.Clear();
            dgv.DataSource = null;

            resultTable = table;

            dgv.DataSource = table;

            dgv.MasterTemplate.AllowAddNewRow = false;

            foreach (var row in dgv.Rows)
            {
                row.Height = 50;
            }
           // dgv.Rows[0].Height = 40;

          

            //pinned
            //dgv.Columns[0].IsPinned = true;
            //dgv.Columns[1].IsPinned = true;
            //dgv.Columns[2].IsPinned = true;
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

            dgv.Columns[0].Width = 70;
            dgv.Columns[1].Width = 90;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 90;

        

       
            var view = SetColumnGroupsView(dgv);
            dgv.ViewDefinition = view;
       
           

            dgv.CellFormatting += Dgv_CellFormatting;

     
            dgv.CellClick += Dgv_CellClick;

            dgv.CellBeginEdit += Dgv_CellBeginEdit;

            //dgv.Columns[0].IsPinned = true;
            //dgv.Columns[1].IsPinned = true;
            //dgv.Columns[2].IsPinned = true;
            //dgv.Columns[3].IsPinned = true;

            dgv.Refresh();

        }

        private void Dgv_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var path = resultTable.Rows[e.RowIndex][2].ToString();
                var parts = path.Split('_');
                var bigImagePath = parts[0] + "_" + parts[1] + "_big.png";

                Form customerHelpForm = Application.OpenForms["BigModuleImageInfo"];
                if (customerHelpForm == null)
                {
                    customerHelpForm = new BigModuleImageInfo(bigImagePath);
                    customerHelpForm.Show();
                }
                else
                {
                    customerHelpForm.Focus();
                }
               
            }
        }

        private ColumnGroupsViewDefinition SetColumnGroupsView(RadGridView dgv)
        {
            ColumnGroupsViewDefinition view = new ColumnGroupsViewDefinition();

            view.ColumnGroups.Add(new GridViewColumnGroup("Num"));
            view.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[0].Rows[0].Columns.Add(dgv.Columns["Номер модуля"]);
            view.ColumnGroups[0].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("F"));
            view.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[1].Rows[0].Columns.Add(dgv.Columns["Форма модуля"]);
            view.ColumnGroups[1].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("I"));
            view.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[2].Rows[0].Columns.Add(dgv.Columns["Icon"]);
            view.ColumnGroups[2].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("Размеры"));
            view.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[3].Rows[0].Columns.Add(dgv.Columns["Высота модуля (мм)"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(dgv.Columns["Ширина модуля (мм)"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(dgv.Columns["Глубина модуля (мм)"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(dgv.Columns["A размер (мм)"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(dgv.Columns["B размер (мм)"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(dgv.Columns["C размер (мм)"]);
            view.ColumnGroups[3].Rows[0].Columns.Add(dgv.Columns["D размер (мм)"]);

            view.ColumnGroups.Add(new GridViewColumnGroup("z"));
            view.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[4].Rows[0].Columns.Add(dgv.Columns["Задняя стенка2"]);
            view.ColumnGroups[4].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("ppse"));
            view.ColumnGroups[5].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[5].Rows[0].Columns.Add(dgv.Columns["Полка по ширине секции (шт)2"]);
            view.ColumnGroups[5].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("ppmin"));
            view.ColumnGroups[6].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[6].Rows[0].Columns.Add(dgv.Columns["Полка - 2мм (шт)2"]);
            view.ColumnGroups[6].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("ppraz"));
            view.ColumnGroups[7].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[7].Rows[0].Columns.Add(dgv.Columns["Полка разделительная (шт)"]);
            view.ColumnGroups[7].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("ppraz"));
            view.ColumnGroups[8].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[8].Rows[0].Columns.Add(dgv.Columns["Полка стеклянная (шт)"]);
            view.ColumnGroups[8].ShowHeader = false;


            view.ColumnGroups.Add(new GridViewColumnGroup("Фасад"));
            view.ColumnGroups[9].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[9].Rows[0].Columns.Add(dgv.Columns["№ схемы фасада"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(dgv.Columns["Тип фасада2"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(dgv.Columns["Горизонтальный размер"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(dgv.Columns["Вертикальный размер"]);
            view.ColumnGroups[9].Rows[0].Columns.Add(dgv.Columns["Материал фасада2"]);
    


            return view;
        }

        private string _columnName=string.Empty;

        private void Dgv_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {

            if (e.Column.Name == "Задняя стенка2" ||
                e.Column.Name == "Тип фасада2")
            {
                _columnName = e.Column.Name;
                ((RadDropDownListEditorElement)((RadDropDownListEditor)e.ActiveEditor).EditorElement).SelectedIndexChanged-=  Form1_SelectedIndexChanged;
                ((RadDropDownListEditorElement)((RadDropDownListEditor)e.ActiveEditor).EditorElement).SelectedIndexChanged += Form1_SelectedIndexChanged;
            }
        }

        private void Form1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RadDropDownListEditorElement editor = sender as RadDropDownListEditorElement;
          
            if (editor?.SelectedItem != null && editor.SelectedItem.Text == "Что это?")
            {
                ShowHelpForm(_columnName);
                
            }
        }

        private void ShowHelpForm(string columnName)
        {
            var path = resultTable.Rows[0][2].ToString();
            var parts = path.Split('_');
            string bigImagePath = string.Empty;

            switch (columnName)
            {
                case "Задняя стенка2":
                    bigImagePath = parts[0] + "_" + parts[1] + "_stenka-help.png";
                    new BigModuleImageInfo(bigImagePath).Show();
                    break;
                case "Тип фасада2":
                    bigImagePath = parts[0] + "_" + parts[1] + "_fasad-help.png";
                    new BigModuleImageInfo(bigImagePath).Show();
                    break;
                    
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
                // ignored
            }
        }
    }
}

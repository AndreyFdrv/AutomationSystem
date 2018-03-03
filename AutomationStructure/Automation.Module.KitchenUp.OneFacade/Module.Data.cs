using System.Collections.Generic;
using System.Data;

namespace Automation.Module.KitchenUp.OneFacade
{
    internal class ModuleData
    {

        private Dimensions dimentions;
        private List<Facade> _facades;
        private CommonParams commonParams;
        private string _shelfPo;
        private string _shelfMinusTwoMm;
        private string _shelfForRazdel;
        private string _shelfGlass;
        private string _calcMode;
        private string _moduleAssembly;
        private string BackWall;



        public ModuleData()
        {           
            commonParams = new CommonParams();
            SetDefaultValues();            
        }

        public void SetDefaultValues()
        {
            dimentions = new Dimensions
            {
                Length = 800,
                Width = 400,
                Depth = 300,
                A = 0,
                B = 0,
                C = 0,
                D = 0
            };

            _facades = new List<Facade> { new Facade() {
                HorizontalDimension = 0,
                VerticalDimension = 0,
                Type = "Накладной",
                Material = "Верт." } };

            _moduleAssembly = "не разъёмная (конф.)";
            BackWall = "ГВ";
            _shelfMinusTwoMm = "2";
            _shelfForRazdel = "0";
            _shelfGlass = "0";
            _calcMode = "Автоматически";


        }

        public void SetCommonParams(string name, string modulePath, string scheme, string iconPath)
        {
            commonParams.Name = name;
            commonParams.ModulePath = modulePath;
            commonParams.Scheme = scheme;
            commonParams.IconPath = iconPath;
        }

        public DataTable GetEmptyTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Номер модуля");
            table.Columns.Add("Форма модуля");
            table.Columns.Add("Изображение");
            table.Columns.Add("Высота модуля (мм)");
            table.Columns.Add("Ширина модуля (мм)");
            table.Columns.Add("Глубина модуля (мм)");
            table.Columns.Add("A размер (мм)");
            table.Columns.Add("B размер (мм)");
            table.Columns.Add("C размер (мм)");
            table.Columns.Add("D размер (мм)");
            table.Columns.Add("Сборка модуля");
            table.Columns.Add("Задняя стенка");
            table.Columns.Add("Полка по ширине секции (шт)");
            table.Columns.Add("Полка - 2мм (шт)");
            table.Columns.Add("Полка разделительная (шт)");
            table.Columns.Add("Полка стеклянная (шт)");
            table.Columns.Add("№ схемы фасада");
            table.Columns.Add("Тип фасада");
            table.Columns.Add("Режим расчёта");
            table.Columns.Add("Вертикальный размер");
            table.Columns.Add("Горизонтальный размер");
            table.Columns.Add("Материал фасада");
            return table;
        }

        public DataTable GetModulesData()
        {
            DataTable table = GetEmptyTable();
            GetInfoRows(table);
            return table;
        }

        public void GetInfoRows(DataTable table)
        {

            int facadesCount = _facades.Count;           

            DataRow row = table.NewRow();
            row["Номер модуля"] = commonParams.Name;
            row["Форма модуля"] = commonParams.Scheme;
            row["Изображение"] = commonParams.IconPath;
            row["Высота модуля (мм)"] = dimentions.Length;
            row["Ширина модуля (мм)"] = dimentions.Width;
            row["Глубина модуля (мм)"] = dimentions.Depth;
            row["A размер (мм)"] = dimentions.A;
            row["B размер (мм)"] = dimentions.B;
            row["C размер (мм)"] = dimentions.C;
            row["D размер (мм)"] = dimentions.D;
            row["Сборка модуля"] = _moduleAssembly;
            row["Задняя стенка"] = BackWall;
            row["Полка по ширине секции (шт)"] = _shelfPo;
            row["Полка - 2мм (шт)"] = _shelfMinusTwoMm;
            row["Полка разделительная (шт)"] = _shelfForRazdel;
            row["Полка стеклянная (шт)"] = _shelfGlass;

            row["№ схемы фасада"] = 0;
            row["Тип фасада"] = _facades[0].Type;
            row["Режим расчёта"] = _calcMode;
            row["Вертикальный размер"] = _facades[0].VerticalDimension;
            row["Горизонтальный размер"] = _facades[0].HorizontalDimension;
            row["Материал фасада"] = _facades[0].Material;
            table.Rows.Add(row);

            if (facadesCount > 1)
            {
                for (int i = 1; i < facadesCount; i++)
                {
                    DataRow facadeRow = table.NewRow();
                    facadeRow["№ схемы фасада"] = i;
                    facadeRow["Тип фасада"] = _facades[i].Type;
                    facadeRow["Вертикальный размер"] = _facades[i].VerticalDimension;
                    facadeRow["Горизонтальный размер"] = _facades[i].HorizontalDimension;
                    facadeRow["Материал фасада"] = _facades[i].Material;
                    table.Rows.Add(facadeRow);
                }
            }


        }

        public void SetModulesData(DataTable changedInfo)
        {
            int countRows = changedInfo.Rows.Count;
            DataRow row = changedInfo.Rows[0];
            commonParams.Name = row["Номер модуля"].ToString();
            commonParams.IconPath = row["Изображение"].ToString();
            commonParams.Scheme = row["Форма модуля"].ToString();
            dimentions.Length = double.Parse(row["Высота модуля (мм)"].ToString());
            dimentions.Width = double.Parse(row["Ширина модуля (мм)"].ToString());
            dimentions.Depth = double.Parse(row["Глубина модуля (мм)"].ToString());
            dimentions.A = double.Parse(row["A размер (мм)"].ToString());
            dimentions.B = double.Parse(row["B размер (мм)"].ToString());
            dimentions.C = double.Parse(row["C размер (мм)"].ToString());
            dimentions.D = double.Parse(row["D размер (мм)"].ToString());
            _moduleAssembly = row["Сборка модуля"].ToString();
            BackWall = row["Задняя стенка"].ToString();
            _shelfPo = row["Полка по ширине секции (шт)"].ToString();
            _shelfMinusTwoMm = row["Полка - 2мм (шт)"].ToString();

            if (string.IsNullOrEmpty(row["Полка разделительная (шт)"].ToString()))
            {
                _shelfForRazdel = "0";
            }
            else
            {
                _shelfForRazdel = row["Полка разделительная (шт)"].ToString();
            }


            if (string.IsNullOrEmpty(row["Полка стеклянная (шт)"].ToString()))
            {
                _shelfGlass = "0";
            }
            else
            {
                _shelfGlass = row["Полка стеклянная (шт)"].ToString();
            }
            
          
            _facades[0].NumberOnScheme = int.Parse(row["№ схемы фасада"].ToString());
            _facades[0].Type = row["Тип фасада"].ToString();
            _facades[0].Material = row["Материал фасада"].ToString();

            _calcMode = row["Режим расчёта"].ToString();

            if (_calcMode == "Автоматически")
            {
                foreach(var facade in _facades)
                {
                    facade.CalculateDimentions(dimentions);
                }                
            }
            else
            {
                _facades[0].HorizontalDimension = double.Parse(row["Горизонтальный размер"].ToString());
                _facades[0].VerticalDimension = double.Parse(row["Вертикальный размер"].ToString());
            }            

        }




    }
}

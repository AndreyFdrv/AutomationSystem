using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Automation.Infrastructure;
using System.Collections.Generic;


namespace Automation.Module.KitchenUp
{
    [Serializable]
    public class KitchenUp : BaseModule
    {
        public KitchenUp()
        {
            _facade = new Facade();
            dimentions = new Dimensions {
                Lenght = 800,
                Width= 400,
                Depth = 300,
                A = 0,
                B = 0,
                C = 0,
                D = 0               
            };
            setDefaultValues();
           
        }

        private void setDefaultValues()
        {
       
            _moduleAssembly = "не разъёмная (конф.)";
            BackWall = "ГВ";
            _shelfMinusTwoMm = "2";
            _shelfForRazdel = "0";
            _shelfGlass = "0";

            int countFacades = 1;
            _facade.InitFacadeRecords(countFacades);
            _facade._records[0].Type = "Накладной";
            _facade._records[0].HorisontalDimension = 0;
            _facade._records[0].VerticalDimension = 0;
            _calcMode = "Автоматически";
            _facade._records[0].Material = "Верт.";
        

        }

        private Dimensions dimentions;
        private Facade _facade;
        private string _shelfPo;
        private string _shelfMinusTwoMm;
        private string _shelfForRazdel;
        private string _shelfGlass;
        private string _calcMode;
        private string _moduleAssembly;


        List<CalculationItem> detailsItems = new List<CalculationItem>();
        List<CalculationItem> backItems = new List<CalculationItem>();
        List<FurnitureCalculationItem> furnitureItems = new List<FurnitureCalculationItem>();
        List<FasadeCalculationItem> fasadeItems = new List<FasadeCalculationItem>();


        public override void SetupModule(DataTable changedInfo)
        {

            int countRows = changedInfo.Rows.Count;
            DataRow row = changedInfo.Rows[0];
            Number = row["Номер модуля"].ToString();
            IconPath = row["Изображение"].ToString();
            Sсheme = row["Форма модуля"].ToString();
            dimentions.Lenght = double.Parse(row["Высота модуля (мм)"].ToString());
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

            
            if(string.IsNullOrEmpty(row["Полка стеклянная (шт)"].ToString()))
            {
                _shelfGlass = "0";
            }
            else
            {
                _shelfGlass = row["Полка стеклянная (шт)"].ToString();
            }


            var formula = IconPath.Split('_')[1];
            _facade._records[0].NumberOnScheme = int.Parse(row["№ схемы фасада"].ToString());
            _calcMode = row["Режим расчёта"].ToString();

            if (_calcMode == "Автоматически")
            {
                KitchenUpFacadeCalculator calculator = new KitchenUpFacadeCalculator();
                calculator.CalculateDimentions(_facade, dimentions, formula);
            }
            else
            {
                _facade._records[0].HorisontalDimension = double.Parse(row["Горизонтальный размер"].ToString());
                _facade._records[0].VerticalDimension = double.Parse(row["Вертикальный размер"].ToString());
            }
            
            _facade._records[0].Type = row["Тип фасада"].ToString();
            _facade._records[0].Material = row["Материал фасада"].ToString();


        }

        public override void GetInfoRows(DataTable table)
        {

            int countRows = GetCountRows();
            _facade.InitFacadeRecords(countRows);

            DataRow row = table.NewRow();
            row["Номер модуля"] = Number;
            row["Форма модуля"] = Sсheme;
            row["Изображение"] = IconPath;
            row["Высота модуля (мм)"] = dimentions.Lenght;
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

            row["№ схемы фасада"] = _facade._records[0].NumberOnScheme;
            row["Тип фасада"] = _facade._records[0].Type;
            row["Режим расчёта"] = _calcMode;
            row["Вертикальный размер"] = _facade._records[0].VerticalDimension;
            row["Горизонтальный размер"] = _facade._records[0].HorisontalDimension;
            row["Материал фасада"] = _facade._records[0].Material;
            table.Rows.Add(row);

            if (countRows > 1)
            {
                for (int i = 1; i < countRows; i++)
                {
                    DataRow anotherRow = table.NewRow();
                    anotherRow["№ схемы фасада"] = _facade._records[i].NumberOnScheme;
                    anotherRow["Тип фасада"] = _facade._records[i].Type;
                    anotherRow["Вертикальный размер"] = _facade._records[i].VerticalDimension;
                    anotherRow["Горизонтальный размер"] = _facade._records[i].HorisontalDimension;
                    anotherRow["Материал фасада"] = _facade._records[i].Material;
                    table.Rows.Add(anotherRow);
                }
            }


        }

        private int GetCountRows()
        {
            int count = 1;

            switch (Sсheme)
            {
                case "1.jpg":
                    count = 1;
                    break;
                case "2+B.jpg":
                    count = 2;
                    break;

            }

            return count;
        }

        public override DataTable GetInfoTable()
        {
            DataTable table = GetEmptyTable();
            GetInfoRows(table);
            return table;
        }

        public override DataTable GetEmptyTable()
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

        public override object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }


        public override Result Calculate()
        {
            KitchenUpCalculator calculator = new KitchenUpCalculator
            {
                Name = Name,
                Sсheme = Sсheme,
                IconPath = IconPath,
                BackWall = BackWall,
                Number = Number,
                SubScheme = SubScheme,
                _dimentions = dimentions,
                _facade = _facade,
                _shelfPo = _shelfPo,
                _shelfMinusTwoMm = _shelfMinusTwoMm,
                _shelfForRazdel = _shelfForRazdel,
                _shelfGlass = _shelfGlass
            };

            Result result = new Result
            {
                ModuleName = calculator.GetModuleName(),
                ImagePath = calculator.GetImagePath(),
                DimensionInfo = calculator.GetDimensionInfo(),
                DetailsInfo = calculator.GetDetailsInfo(),
                FurnitureInfo = calculator.GetFurnitureInfo(),
                ShelfInfo = calculator.GetShelfInfo(),
                LoopsInfo = calculator.GetLoopsInfo()
            };

            detailsItems = calculator.GetDetailsInfoItems();
            backItems = calculator.GetBackInfoItems();
            furnitureItems = calculator.GetFurnitureInfoItems();
            fasadeItems = calculator.GetFasadeInfoItems();

            return result;

        }

        public override List<CalculationItem> GetBackItems()
        {
            return backItems;
        }

        public override List<CalculationItem> GetDetailsInfo()
        {
            return detailsItems;
        }

        public override List<FurnitureCalculationItem> GetFurnitureItems()
        {
            return furnitureItems;
        }

        public override List<FasadeCalculationItem> GetFasadeItems()
        {
            return fasadeItems;
        }
    }
}

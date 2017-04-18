using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules.KitchenUpModule
{
    [Serializable]
    class KitchenUp : AbstractModule
    {
        public KitchenUp()
        {
            _facade = new Facade();
            _dimentions = new Dimensions();
           
        }


        private Dimensions _dimentions;
        private Facade _facade;
        private string _shelfPo;
        private string _shelfMinusTwoMm;
        private string _shelfForRazdel;
        private string _shelfGlass;


        public override void SetupModule(DataTable changedInfo)
        {

            int countRows = changedInfo.Rows.Count;
            DataRow row = changedInfo.Rows[0];
            Number = row["Номер модуля"].ToString();
            IconPath = row["Изображение"].ToString();
            Sсheme = row["Форма модуля"].ToString();
            _dimentions.Lenght = double.Parse(row["Высота модуля (мм)"].ToString());
            _dimentions.Width = double.Parse(row["Ширина модуля (мм)"].ToString());
            _dimentions.Depth = double.Parse(row["Глубина модуля (мм)"].ToString());
            _dimentions.A = double.Parse(row["A размер (мм)"].ToString());
            _dimentions.B = double.Parse(row["B размер (мм)"].ToString());
            _dimentions.C = double.Parse(row["C размер (мм)"].ToString());
            _dimentions.D = double.Parse(row["D размер (мм)"].ToString());

            BackWall = row["Задняя стенка"].ToString();
            _shelfPo = row["Полка по ширине секции (шт)"].ToString();
            _shelfMinusTwoMm = row["Полка - 2мм (шт)"].ToString();
            _shelfForRazdel = row["Полка разделительная (шт)"].ToString();
            _shelfGlass = row["Полка стеклянная (шт)"].ToString();

            var formula = IconPath.Split('_')[1];
            KitchenUpFacadeCalculator calculator = new KitchenUpFacadeCalculator();
            calculator.CalculateDimentions(_facade, _dimentions, formula);


            _facade._records[0].NumberOnScheme = int.Parse(row["№ схемы фасада"].ToString());
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
            row["Высота модуля (мм)"] = _dimentions.Lenght;
            row["Ширина модуля (мм)"] = _dimentions.Width;
            row["Глубина модуля (мм)"] = _dimentions.Depth;
            row["A размер (мм)"] = _dimentions.A;
            row["B размер (мм)"] = _dimentions.B;
            row["C размер (мм)"] = _dimentions.C;
            row["D размер (мм)"] = _dimentions.D;

            row["Задняя стенка"] = BackWall;
            row["Полка по ширине секции (шт)"] = _shelfPo;
            row["Полка - 2мм (шт)"] = _shelfMinusTwoMm;
            row["Полка разделительная (шт)"] = _shelfForRazdel;
            row["Полка стеклянная (шт)"] = _shelfGlass;

            row["№ схемы фасада"] = _facade._records[0].NumberOnScheme;
            row["Тип фасада"] = _facade._records[0].Type;
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
            table.Columns.Add("Задняя стенка");
            table.Columns.Add("Полка по ширине секции (шт)");
            table.Columns.Add("Полка - 2мм (шт)");
            table.Columns.Add("Полка разделительная (шт)");
            table.Columns.Add("Полка стеклянная (шт)");
            table.Columns.Add("№ схемы фасада");
            table.Columns.Add("Тип фасада");
            table.Columns.Add("Вертикальный размер");
            table.Columns.Add("Горизонтальный размер");
            table.Columns.Add("Материал фасада");
            return table;
        }

        public override object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
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
                _dimentions = _dimentions,
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

            return result;

        }
    }
}

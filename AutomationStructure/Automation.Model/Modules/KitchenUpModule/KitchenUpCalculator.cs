using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules.KitchenUpModule
{
    public class KitchenUpCalculator
    {
        public string Name { get; set; }
        public string Sсheme { get; set; }
        public string BackWall { get; set; }
        public string Number { get; set; }
        public string SubScheme { get; set; }
        public string IconPath { get; set; }

        private string BigImagePath
        {
            get
            {
                var fullImagePath = IconPath.Split('_');
                return  fullImagePath[0] + "_" +
                       fullImagePath[1] + "_result.png";
            }

        }

        public Dimensions _dimentions;
        public Facade _facade;
        public string _shelfPo;
        public string _shelfMinusTwoMm;
        public string _shelfForRazdel;
        public string _shelfGlass;

        private string _bigImage;

        public KitchenUpCalculator(string name,
            string sсheme,
            string backWall, 
            string number, 
            string subScheme, 
            string iconPath,
            Dimensions _dimentions,
            Facade _facade,
            string _shelfPo,
            string _shelfMinusTwoMm,
            string _shelfForRazdel,
            string _shelfGlass)
        {
            Name = name;
            Sсheme = sсheme;
            BackWall = backWall;
            Number = number;
            SubScheme = subScheme;
            IconPath = iconPath;
            this._dimentions = _dimentions;
            this._facade = _facade;
            this._shelfPo = _shelfPo;
            this._shelfMinusTwoMm = _shelfMinusTwoMm;
            this._shelfForRazdel = _shelfForRazdel;
            this._shelfGlass = _shelfGlass;
        }

        public KitchenUpCalculator()
        {
        }

        public string GetModuleName()
        {
            return Number;
        }

        public DataTable GetDimensionInfo()
        {
            DataTable dimensionsInfo = new DataTable();
            dimensionsInfo.Columns.Add("Высота H");
            dimensionsInfo.Columns.Add("Ширина W");
            dimensionsInfo.Columns.Add("Глубина T");
            DataRow row = dimensionsInfo.NewRow();
            row[0] = _dimentions.Lenght;
            row[1] = _dimentions.Width;
            row[2] = _dimentions.Depth;
            dimensionsInfo.Rows.Add(row);

            return dimensionsInfo;
        }

        public string GetImagePath()
        {
            return BigImagePath;
        }


        public DataTable GetDetailsInfo()
        {
            DataTable detailsInfo = new DataTable();
            SetDetailsInfoColumns(detailsInfo);

            detailsInfo.Rows.Add("1","Бока","4","12","5","34","6","7");
            detailsInfo.Rows.Add("2", "Верх-низ", "8", "56", "9", "78", "10", "11");
            detailsInfo.Rows.Add("3 Полки", "Не съёмные", "12", "910", "13", "1112", "14", "15");
            detailsInfo.Rows.Add("", "Съёмные (-2мм)", "16", "1314", "17", "1516", "18", "19");
            detailsInfo.Rows.Add("4", "Разделитель секции", "20","1718", "21", "1920", "22", "23");
            detailsInfo.Rows.Add("5", "Задняя стенка", "41","" , "42", "", "43", "44");

            detailsInfo.Rows.Add("Ф1", "Фасад 1", "24", "21", "25", "21", "", "");
            detailsInfo.Rows.Add("Ф2", "Фасад 2", "26", "", "27", "", "", "");
            detailsInfo.Rows.Add("Ф3", "Фасад 3", "28", "", "29", "", "", "");
            detailsInfo.Rows.Add("Ф4", "Фасад 4", "30", "", "31", "", "", "");
            detailsInfo.Rows.Add("3", "Полка стекло", "32", "", "33", "", "34", "");
            return detailsInfo;

        }

        private void SetDetailsInfoColumns(DataTable detailsInfo)
        {
            detailsInfo.Columns.Add("№");
            detailsInfo.Columns.Add("Наименование");

            DataColumn firstColumn = new DataColumn()
            {
                ColumnName = "firstMM",
                Caption = "ММ"
            };
            detailsInfo.Columns.Add(firstColumn);

            DataColumn secondColumn = new DataColumn
            {
                ColumnName = "firstKromka",
                Caption = "Кромка"
            };
            detailsInfo.Columns.Add(secondColumn);

            DataColumn thirdColumn = new DataColumn()
            {
                ColumnName = "secondMM",
                Caption = "ММ"
            };
            detailsInfo.Columns.Add(thirdColumn);

            DataColumn fourthColumn = new DataColumn
            {
                ColumnName = "secondKromka",
                Caption = "Кромка"
            };
            detailsInfo.Columns.Add(fourthColumn);

            detailsInfo.Columns.Add("Количество");
            detailsInfo.Columns.Add("Примечание");
        }
        

        public DataTable GetFurnitureInfo()
        {
            DataTable furnitureInfo = new DataTable();
            furnitureInfo.Columns.Add("Наименование");
            furnitureInfo.Columns.Add("Петли");
            furnitureInfo.Columns.Add("Конфирмат");
            furnitureInfo.Columns.Add("Эксцентрик");
            furnitureInfo.Columns.Add("Полко держатель");
            furnitureInfo.Columns.Add("Ручки");
            furnitureInfo.Columns.Add("Обычные навесные");
            furnitureInfo.Columns.Add("Регулируемые навесные");
            furnitureInfo.Columns.Add("Газлифты");
            furnitureInfo.Rows.Add("35", "36", "37", "38", "39", "40", "45", "46");

            return furnitureInfo;
        }

        public DataTable GetShelfInfo()
        {
            DataTable shelfInfo = new DataTable();
            shelfInfo.Columns.Add("Полки");
            shelfInfo.Columns.Add("1");
            shelfInfo.Columns.Add("2");
            shelfInfo.Columns.Add("3");
            shelfInfo.Columns.Add("4");
            shelfInfo.Columns.Add("5");
            shelfInfo.Columns.Add("6");
            shelfInfo.Columns.Add("Разд.1");
            shelfInfo.Columns.Add("Разд.2");
          
            shelfInfo.Rows.Add("K", "", "", "", "", "", "", "", "" );
            shelfInfo.Rows.Add("L", "", "", "", "", "", "", "", "" );
            shelfInfo.Rows.Add("M", "", "", "", "", "", "", "", "" );

            return shelfInfo;


        }

        public DataTable GetLoopsInfo()
        {
            DataTable loopsInfo = new DataTable();
            loopsInfo.Columns.Add("Петли");
            loopsInfo.Columns.Add("1");
            loopsInfo.Columns.Add("2");
            loopsInfo.Columns.Add("3");
            loopsInfo.Columns.Add("4");
            loopsInfo.Rows.Add("на фасаде", "", "", "", "");
            loopsInfo.Rows.Add("на модуле", "", "", "", "");


            return loopsInfo;
        }
    }
}

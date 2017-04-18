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

            detailsInfo.Rows.Add("1","Бока",MF4(),DF1()+"|"+DF2(),MF5(), DF3() + "|" + DF4(), MF6(),MF7());
            detailsInfo.Rows.Add("2", "Верх-низ", MF8(), DF5() + "|" + DF6(), MF9(), DF7() + "|" + DF8(), MF10(), MF11());
            detailsInfo.Rows.Add("3 Полки", "Не съёмные", MF12(), DF9() + "|" + DF10(), MF13(), DF11() + "|" + DF12(), MF14(), MF15());
            detailsInfo.Rows.Add("", "Съёмные (-2мм)", MF16(), DF13() + "|" + DF14(), MF17(), DF15() + "|" + DF16(), MF18(), MF19());
            detailsInfo.Rows.Add("4", "Разделитель секции","20" , DF17() + "|" + DF18(), "21", DF19() + "|" + DF20(), "22", "23");
            detailsInfo.Rows.Add("5", "Задняя стенка", MF41(),"" , MF42(), "", MF43(), "44");

            detailsInfo.Rows.Add("Ф1", "Фасад 1", "24", DF21() , "25", DF21(), "", "");
            detailsInfo.Rows.Add("Ф2", "Фасад 2", "26", "", "27", "", "", "");
            detailsInfo.Rows.Add("Ф3", "Фасад 3", "28", "", "29", "", "", "");
            detailsInfo.Rows.Add("Ф4", "Фасад 4", "30", "", "31", "", "", "");
            detailsInfo.Rows.Add("3", "Полка стекло", MF32(), "", MF33(), "", MF34(), "");
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

        #region Calculation formules

        //main formules
        private double MF4()
        {
            return _dimentions.Lenght - (ModuleThickness.H + ModuleThickness.D);
        }

        private double MF5()
        {
            double result = 0;
            switch (BackWall)
            {
                case "ГВ":
                    result = _dimentions.Depth - (ModuleThickness.F + ModuleThickness.DVP + ModuleThickness.B);
                    break;
                case "1/4 ":
                    result = _dimentions.Depth - (ModuleThickness.F + ModuleThickness.B);
                    break;
            }
            return result;
        }

        private double MF6()
        {
            return 2;
        }

        private string MF7()
        {
            string result = string.Empty;
            switch (BackWall)
            {
                case "":
                    result = "Паз под ДВП";
                    break;
                case "1":
                    result = "Четверть";
                    break;
            }
            return result;
        }

        private double MF8()
        {
            return _dimentions.Width - (ModuleThickness.Plate*2);
        }

        private double MF9()
        {
            return MF5();
        }

        private double MF10()
        {
            return 2;
        }

        private double MF11()
        {
            return 7;
        }

        private double MF12()
        {
            return _dimentions.Width - (ModuleThickness.Plate*2);
        }

        private double MF13()
        {
            double result = 0;
            switch (BackWall)
            {
                case "1":
                    result = _dimentions.Depth - 5;
                    break;
                case "2":
                    result = _dimentions.Depth - (5 + ModuleThickness.DVP);
                    break;
                case "3":
                    result = _dimentions.Depth - (5 + 20);
                    break;
                case "4":
                    result = _dimentions.Depth - (5 + ModuleThickness.Plate);
                    break;
            }
            return result;
        }

        private string MF14()
        {
            return _shelfForRazdel;
        }

        private string MF15()
        {
            return "";
        }

        private double MF16()
        {
            return _dimentions.Width - ((ModuleThickness.Plate*2) + 2 + (ModuleThickness.LRP*2));
        }

        private double MF17()
        {
            return MF13();
        }

        private string MF18()
        {
            return _shelfMinusTwoMm;
        }

        private string MF19()
        {
            return "";
        }

        private double MF41()
        {
            double result=0;
            switch (BackWall)
            {
                case "1":
                    result = _dimentions.Lenght - 2;
                    break;
                case "2":
                    result = _dimentions.Lenght - 10;
                    break;
                case "3":
                    result = _dimentions.Lenght - 8;
                    break;
                case "4":
                    result = _dimentions.Lenght - (ModuleThickness.Plate*2);
                    break;
            }
            return result;

        }

        private double MF42()
        {
            double result = 0;
            switch (BackWall)
            {
                case "1":
                    result = _dimentions.Width - 2;
                    break;
                case "2":
                    result = _dimentions.Width - 10;
                    break;
                case "3":
                    result = _dimentions.Width - 8;
                    break;
                case "4":
                    result = _dimentions.Width - (ModuleThickness.Plate * 2);
                    break;
            }
            return result;
        }

        private string MF43()
        {
            return "";
        }

        private double MF32()
        {
            return _dimentions.Width - (ModuleThickness.Plate*2 + 3);
        }

        private double MF33()
        {
            return MF13();
        }

        private string MF34()
        {
            return _shelfGlass;
        }

        #endregion

        #region Calculation dop formules 

        public string DF1()
        {
            string result = string.Empty;
            switch (ModuleThickness.F.ToString())
            {
                case "0":
                    result="";
                    break;
                case "0.4":
                    result= "I";
                    break;
                case "2":
                    result= "V";
                    break;
            }
            return result;
        }

        public string DF2()
        {
            string result = string.Empty;
            switch (ModuleThickness.B.ToString())
            {
                case "0":
                    result="";
                    break;
                case "0.4":
                    result= "I";
                    break;
                case "2":
                    result= "V";
                    break;
            }
            return result;
        }

        public string DF3()
        {
            string result = string.Empty;
            switch (ModuleThickness.H.ToString())
            {
                case "0":
                    result = "";
                    break;
                case "0.4":
                    result = "I";
                    break;
                case "2":
                    result = "V";
                    break;
            }
            return result;
        }

        public string DF4()
        {
            string result = string.Empty;
            switch (ModuleThickness.D.ToString())
            {
                case "0":
                    result = "";
                    break;
                case "0.4":
                    result = "I";
                    break;
                case "2":
                    result = "V";
                    break;
            }
            return result;
        }

        public string DF5()
        {
            return DF1();
        }

        public string DF6()
        {
            return DF2();
        }

        public string DF7()
        {
            return "";
        }

        public string DF8()
        {
            return "";
        }

        public string DF9()
        {
            string result = string.Empty;
            switch (ModuleThickness.FP.ToString())
            {
                case "0":
                    result = "";
                    break;
                case "0.4":
                    result = "I";
                    break;
                case "2":
                    result = "V";
                    break;
            }
            return result;
        }

        public string DF10()
        {
            string result = string.Empty;
            switch (ModuleThickness.BP.ToString())
            {
                case "0":
                    result = "";
                    break;
                case "0.4":
                    result = "I";
                    break;
                case "2":
                    result = "V";
                    break;
            }
            return result;
        }

        public string DF11()
        {
            return "";
        }

        public string DF12()
        {
            return "";
        }

        public string DF13()
        {
            return DF9();
        }

        public string DF14()
        {
            return DF10();
        }

        public string DF15()
        {
            string result = string.Empty;
            switch (ModuleThickness.LRP.ToString())
            {
                case "0":
                    result = "";
                    break;
                case "0.4":
                    result = "I";
                    break;
                case "2":
                    result = "V";
                    break;
            }
            return result;
        }

        public string DF16()
        {
            string result = string.Empty;
            switch (ModuleThickness.LRP.ToString())
            {
                case "0":
                    result = "";
                    break;
                case "0.4":
                    result = "I";
                    break;
                case "2":
                    result = "V";
                    break;
            }
            return result;
        }

        public string DF17()
        {
            return DF9();
        }

        public string DF18()
        {
            return DF10();
        }

        public string DF19()
        {
            return DF11();
        }

        public string DF20()
        {
            return DF12();
        }

        public string DF21()
        {
            string result = string.Empty;

            if (_facade._records[0].Type == "other" || (int)ModuleThickness.FF == 0)
            {
                result = "";
            }

            if (_facade._records[0].Type =="" && ModuleThickness.FF==0.4)
            {
                result = "I";
            }

            if (_facade._records[0].Type == "" && ModuleThickness.FF == 0.4)
            {
                result = "V";
            }

            return result;
        }


        #endregion

    }
}

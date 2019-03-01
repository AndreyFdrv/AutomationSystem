using System;
using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;
using Automation.Model;


namespace Automation.Module.KitchenUp
{
    public class KitchenUpCalculator
    {
        public string Name { get; set; }
        public string Sсheme { get; set; }
        public string BackPanelAssembly { get; set; }
        public string Number { get; set; }
        public string SubScheme { get; set; }
        public string IconPath { get; set; }
        public Dimensions _dimentions;
        public Facade _facade;
        public string _shelfAssembly;
        public string _shelfsCount;

        private string BigImagePath
        {
            get
            {
                var fullImagePath = IconPath.Split('_');
                return  fullImagePath[0] + "_" +
                       fullImagePath[1] + "_result.png";
            }

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
            dimensionsInfo.Columns.Add("A");
            dimensionsInfo.Columns.Add("B");
            dimensionsInfo.Columns.Add("C");
            dimensionsInfo.Columns.Add("D");
            DataRow row = dimensionsInfo.NewRow();
            row[0] = _dimentions.Hight;
            row[1] = _dimentions.Width;
            row[2] = _dimentions.Depth;
            row[3] = _dimentions.A;
            row[4] = _dimentions.B;
            row[5] = _dimentions.C;
            row[6] = _dimentions.D;
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

            detailsInfo.Rows.Add("1", "бока", MF4(), DF1() + "|" + DF2(), MF5(), DF3() + "|" + DF4(), MF6(), MF7());
            detailsInfo.Rows.Add("2", "верх/низ", MF8(), DF5() + "|" + DF6(), MF9(), DF7()+ "|" + DF8(), MF10(), MF11());
            detailsInfo.Rows.Add("3", FA3(), MF12(), DF9() + "|" + DF10(), MF13(), DF11() + "|" + DF12(), "", MF15());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("4", "задняя стенка", MF41(), "", MF42(), "", "", MF43());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("5", "фасад", FL7(), DF17() + "|" + DF18(), FW7(), DF19() + "|" + DF20(), "", FP7());

            detailsInfo.Rows.Add("Ф1", "Фасад 1", MF24(), DF21() ,MF25(), DF21(), "", "");
            detailsInfo.Rows.Add("Ф2", "Фасад 2", "26", "", "27", "", "", "");
            detailsInfo.Rows.Add("Ф3", "Фасад 3", "28", "", "29", "", "", "");
            detailsInfo.Rows.Add("Ф4", "Фасад 4", "30", "", "31", "", "", "");
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
                ColumnName = "firstEdge",
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
                ColumnName = "secondEdge",
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
            furnitureInfo.Columns.Add("Полко держатели");
            furnitureInfo.Columns.Add("Полко держатели для стеклянных полок");
            furnitureInfo.Columns.Add("Ручки");
            furnitureInfo.Columns.Add("Обычные навесные");
            furnitureInfo.Columns.Add("Регулируемые навесные");
            furnitureInfo.Columns.Add("Газлифты");
            furnitureInfo.Rows.Add("Кол-во", MF35(), "", "", "", "", MF39(), MF40(), F45(), "?");

            return furnitureInfo;
        }
        
        private int MF35()
        {
            var facadeHeight = (int) _dimentions.Hight;
            if (facadeHeight>0 && facadeHeight<800)
            {
                return 2;
            }

            if(facadeHeight>=800 && facadeHeight<1200)
            {
                return 3;
            }

            if (facadeHeight>=1200 && facadeHeight<1500)
            {
                return 4;
            }

            if (facadeHeight>=1500 && facadeHeight<=2400)
            {
                return 5;
            }
            return 0;
        }

        //TODO:изменить переменные как надо
        string moduleAssembly = "не разъёмная (конф.)";
        int moduleForm = 1;

        private int MF39()
        {
            switch (moduleForm)
            {
                case 0:
                case 1:
                case 2:
                    return 1;
                   
            }
            return 0;
        }

        private int MF40()
        {
            switch (BackPanelAssembly)
            {
                case "ГВ":
                    return 2;
                case "четверть":
                    return 2;
                case "паз":
                    return 0;
                case "ЛДСП":
                    return 2;
            }
            return 0;
        }

        private int F45()
        {
            switch (BackPanelAssembly)
            {
                case "ГВ":
                    return 0;
                case "четверть":
                    return 0;
                case "паз":
                    return 2;
                case "ЛДСП":
                    return 0;
            }
            return 0;
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

            //вычисление на месте
            //TODO: дописать метод вычисления 
            List<double> Kitems = new List<double>();
            List<double> Litems = new List<double>();
            List<double> Mitems = new List<double>();

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
            loopsInfo.Rows.Add("на фасаде", L1(), L2(), L3(), "");
            loopsInfo.Rows.Add("на модуле", ML1(), ML2(), ML3(), "");
            return loopsInfo;
        }

        private int L1()
        {
            return 100;
        }

        private int ML1()
        {
            return 100 + 2;
        }

        private double L2()
        {
            return _dimentions.Hight - 100;
        }

        private double ML2()
        {
            return _dimentions.Hight - 100 - 2;
        }

        private double L3()
        {
            return (_dimentions.Hight - 4)/2;

        }

        private double ML3()
        {
            return _dimentions.Hight/2;
        }

        #region Calculation formules

        //main formules
        private double MF4()
        {
            return _dimentions.Hight - (ModuleThickness.UpModule + ModuleThickness.DownModule);
        }

        private double MF5()
        {
            double result = 0;
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = _dimentions.Depth - (ModuleThickness.FrontModule + ModuleThickness.BackModule);
                    break;
                case "на гвозди":
                    result = _dimentions.Depth - (ModuleThickness.BackPanel + ModuleThickness.FrontModule + ModuleThickness.BackModule);
                    break;
                case "четверть":
                case "паз":
                case "ЛДСП":
                case "ЛДСП внутрь":
                    result = _dimentions.Depth - (ModuleThickness.FrontModule + ModuleThickness.BackModule);
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
            switch (BackPanelAssembly)
            {
                case "паз":
                    result = "паз 10*4*16";
                    break;
                case "четверть":
                    result = "четверть 10*4 мм";
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

        private string MF11()
        {
            return MF7();
        }

        private string FA3()
        {
            if (_shelfAssembly == "полкодержатель" && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return "полка съёмная";
            if ((_shelfAssembly == "конфирмат" || _shelfAssembly == "эксцентрик" || _shelfAssembly == "конфирмат + нагель" || 
                _shelfAssembly == "нагель") && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return "полка несъёмная";
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return "полка стекло";
            if (_shelfsCount == "нет")
                return "полок нет";
            return "";
        }

        private string MF12()
        {
            if (_shelfsCount == "нет")
                return "";
            if (_shelfAssembly == "полкодержатель" && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return (_dimentions.Width - (ModuleThickness.Plate * 2 + ModuleThickness.SideShelf * 2 + 2)).ToString();
            if ((_shelfAssembly == "конфирмат" || _shelfAssembly == "эксцентрик" || _shelfAssembly == "конфирмат + нагель" ||
                _shelfAssembly == "нагель") && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return (_dimentions.Width - (ModuleThickness.Plate * 2)).ToString();
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return (_dimentions.Width - (ModuleThickness.Plate * 2 + 3)).ToString();
            return "";
        }

        private string MF13()
        {
            string result = "";
            if (_shelfsCount == "нет")
                return result;
            if (_shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
            {
                switch (BackPanelAssembly)
                {
                    case "на гвозди":
                    case "четверть":
                        result = (_dimentions.Depth - (5 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf + 
                            ModuleThickness.BackPanel)).ToString();
                        break;
                    case "паз":
                        result = (_dimentions.Depth - (21 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf +
                            ModuleThickness.BackPanel)).ToString();
                        break;
                    case "ЛДСП внутрь":
                        result = (_dimentions.Depth - (5 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf +
                            ModuleThickness.Plate)).ToString();
                        break;
                }
                return result;
            }
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
            {
                switch (BackPanelAssembly)
                {
                    case "на гвозди":
                    case "четверть":
                        result = (_dimentions.Depth - (5 + ModuleThickness.BackPanel)).ToString();
                        break;
                    case "паз":
                        result = (_dimentions.Depth - (21 + ModuleThickness.BackPanel)).ToString();
                        break;
                    case "ЛДСП внутрь":
                        result = (_dimentions.Depth - (5 + ModuleThickness.Plate)).ToString();
                        break;
                }
                return result;
            }
            return result;
        }

        private string MF15()
        {
            if (_shelfsCount == "нет")
                return "";
            if (_shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return "ЛДСП";
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return "стекло";
            return "";
        }

        private double MF16()
        {
            return _dimentions.Width - ((ModuleThickness.Plate*2) + 2 + (ModuleThickness.SideShelf * 2));
        }

        private string MF17()
        {
            return MF13();
        }

        private string MF19()
        {
            return "";
        }

        private string MF41()
        {
            string result="";
            switch (BackPanelAssembly)
            {
                case "на гвозди":
                    result = (_dimentions.Hight - 4).ToString();
                    break;
                case "четверть":
                case "паз":
                    result = (_dimentions.Hight - 22).ToString();
                    break;
                case "ЛДСП внутрь":
                    result = (_dimentions.Hight - (ModuleThickness.Plate*2)).ToString();
                    break;
            }
            return result;
        }

        private string MF42()
        {
            string result = "";
            switch (BackPanelAssembly)
            {
                case "на гвозди":
                    result = (_dimentions.Width - 4).ToString();
                    break;
                case "четверть":
                case "паз":
                    result = (_dimentions.Width - 22).ToString();
                    break;
                case "ЛДСП внутрь":
                    result = (_dimentions.Width - (ModuleThickness.Plate * 2)).ToString();
                    break;
            }
            return result;
        }

        private string MF43()
        {
            string result = "";
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = "";
                    break;
                case "на гвозди":
                case "четверть":
                case "паз":
                    result = "ДВП/фанера";
                    break;
                case "ЛДСП внутрь":
                    result = "ЛДСП";
                    break;
            }
            return result;
        }

        private string FL7()
        {
            if (_facade._records.Count == 0)
                return "";
            if (_facade._records[0].Material == "нет")
                return "";
            return _facade._records[0].VerticalDimension.ToString();
        }

        private string FW7()
        {
            if (_facade._records.Count == 0)
                return "";
            if (_facade._records[0].Material == "нет")
                return "";
            return _facade._records[0].HorisontalDimension.ToString();
        }

        private string FP7()
        {
            if (_facade._records.Count == 0)
                return "";
            string result = "";
            switch (_facade._records[0].Material)
            {
                case "нет":
                    result = "";
                    break;
                case "ЛДСП вертик. фактура":
                    result = "ЛДСП вертик. факт.";
                    break;
                case "ЛДСП гориз. фактура":
                    result = "ЛДСП гориз. факт.";
                    break;
                case "на заказ глухой":
                    result = "глухой, на заказ";
                    break;
                case "на заказ витрина":
                    result = "витрина, на заказ";
                    break;
                case "на заказ особый":
                    result = "особый, на заказ";
                    break;
            }
            return result;
        }

        private double MF24()
        {
            var moduleForm = 1;
            double result = 0;
            if (_facade._records.Count == 0)
                return result;
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result =_dimentions.Hight - 4;
                        break;
                    case "Гориз.":
                        result =  _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Hight - 4;
                        break;
                }
            }
            else if(moduleForm ==2)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Hight -_dimentions.A - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Hight - _dimentions.A - 4;
                        break;
                }
            }
            else if (moduleForm == 3)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Hight - _dimentions.A - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Hight - _dimentions.A - 4;
                        break;
                }
            }
            return result;

        }

        private double MF25()
        {
            var moduleForm = 1;
            double result = 0;
            if (_facade._records.Count == 0)
                return 0;
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Width - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Hight - 4;
                        break;
                    case "нет":
                        result = _dimentions.Width - 4;
                        break;
                }
            }
            else if (moduleForm == 2)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Width - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Hight - _dimentions.A - 4;
                        break;
                    case "нет":
                        result = _dimentions.Width - 4;
                        break;
                }
            }
            else if (moduleForm == 3)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Width - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Hight - _dimentions.A - 4;
                        break;
                    case "нет":
                        result = _dimentions.Width - 4;
                        break;
                }
            }
            return result;
        }

        public string MF45()
        {
            var moduleForm = 1;
            string result = "";
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = "фактура ЛДСП вертик.";
                        break;
                    case "Гориз.":
                        result = "фактура ЛДСП гориз.";
                        break;
                    case "нет":
                        result = "на заказ";
                        break;
                }
            }
            else if (moduleForm == 2)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = "фактура ЛДСП вертик.";
                        break;
                    case "Гориз.":
                        result = "фактура ЛДСП гориз.";
                        break;
                    case "нет":
                        result = "на заказ";
                        break;
                }
            }
            else if (moduleForm == 3)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = "фактура ЛДСП вертик.";
                        break;
                    case "Гориз.":
                        result = "фактура ЛДСП гориз.";
                        break;
                    case "нет":
                        result = "на заказ";
                        break;
                }
            }
            return result;
        }


        #endregion

        #region Calculation dop formules 

        private string DF1()
        {
            return GetKromkaThickness(ModuleThickness.FrontModule);
        }

        private string DF2()
        {
            return GetKromkaThickness(ModuleThickness.BackModule);
        }

        private string DF3()
        {
            return GetKromkaThickness(ModuleThickness.UpModule);
        }

        private string DF4()
        {
            return GetKromkaThickness(ModuleThickness.DownModule);

        }

        private string DF5()
        {
            return DF1();
        }

        private string DF6()
        {
            return DF2();
        }

        private string DF7()
        {
            return "";
        }

        private string DF8()
        {
            return "";
        }

        private string DF9()
        {
            return GetKromkaThickness(ModuleThickness.FrontShelf);

        }

        private string DF10()
        {
            return GetKromkaThickness(ModuleThickness.BackShelf);
        }

        private string DF11()
        {
            return "";
        }

        private string DF12()
        {
            return "";
        }

        private string DF13()
        {
            return DF9();
        }

        private string DF14()
        {
            return DF10();
        }

        private string DF15()
        {
            return GetKromkaThickness(ModuleThickness.SideShelf);
        }

        private string GetKromkaThickness(double par)
        {
            string result = string.Empty;
            switch (par.ToString())
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

        private string DF16()
        {
            return GetKromkaThickness(ModuleThickness.SideShelf);
        }

        private string DF17()
        {
            return DF9();
        }

        private string DF18()
        {
            return DF10();
        }

        private string DF19()
        {
            return DF11();
        }

        private string DF20()
        {
            return DF12();
        }

        private string DF21()
        {
            string result = string.Empty;
            if (_facade._records.Count == 0)
                return "";
            if (_facade._records[0].Type == "нет" || (int)ModuleThickness.Facade == 0)
            {
                result = "";
            }

            if (_facade._records[0].Type !="нет" && ModuleThickness.Facade == 0.4)
            {
                result = "I";
            }

            if (_facade._records[0].Type != "нет" && ModuleThickness.Facade == 2)
            {
                result = "V";
            }

            return result;
        }


        #endregion

    }
}

using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;
using Automation.Model;
using System.Linq;
using System;

namespace Automation.Module.KitchenUp
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



        public string GetModuleName()
        {
            return Number;
        }

        public DataTable GetDimensionInfo()
        {
            DataTable dimensionsInfo = new DataTable();
            dimensionsInfo.Columns.Add("Height"); //Высота
            dimensionsInfo.Columns.Add("Width"); //Ширина
            dimensionsInfo.Columns.Add("Depth");  //Глубина
            dimensionsInfo.Columns.Add("А");
            dimensionsInfo.Columns.Add("B");
            dimensionsInfo.Columns.Add("C");
            dimensionsInfo.Columns.Add("D");
            DataRow row = dimensionsInfo.NewRow();
            row[0] = _dimentions.Lenght;
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


        List<CalculationItem> detailsInfoItems = new List<CalculationItem>();

        public List<CalculationItem> GetDetailsInfoItems()
        {
            return detailsInfoItems;
        }

        List<CalculationItem> backItems = new List<CalculationItem>();

        public List<CalculationItem> GetBackInfoItems()
        {
            return backItems;
        }

        List<FurnitureCalculationItem> furnitureInfoItems = new List<FurnitureCalculationItem>();
        
        public List<FurnitureCalculationItem> GetFurnitureInfoItems()
        {
            return furnitureInfoItems;
        }

        List<FasadeCalculationItem> fasadeInfoItems = new List<FasadeCalculationItem>();

        public List<FasadeCalculationItem> GetFasadeInfoItems()
        {
            return fasadeInfoItems;
        }

        public DataTable GetDetailsInfo()
        {
            DataTable detailsInfo = new DataTable();
            SetDetailsInfoColumns(detailsInfo);

            CalculationItem item = new CalculationItem()
            {
                DimentionAlong = MF4().ToString(),
                DimentionAlongKromka1 = DF1(),
                DimentionAlongKromka2 = DF2(),
                DimentionAcross = MF5().ToString(),
                DimentionAcrossKromka1 = DF3(),
                DimentionAcrossKromka2 = DF4(),
                Count = int.Parse(MF6().ToString())
            };

            detailsInfo.Rows.Add("1","Бока",item.DimentionAlong,item.DimentionAlongKromka1+"|"+item.DimentionAlongKromka2,
                item.DimentionAcross, item.DimentionAcrossKromka1 + "|" + item.DimentionAcrossKromka2, item.Count,MF7());

            CalculationItem itemUpDown = new CalculationItem()
            {
                DimentionAlong = MF8().ToString(),
                DimentionAlongKromka1 = DF5(),
                DimentionAlongKromka2 = DF6(),
                DimentionAcross = MF9().ToString(),
                DimentionAcrossKromka1 = DF7(),
                DimentionAcrossKromka2 = DF8(),
                Count = int.Parse(MF10().ToString())
            };

            detailsInfo.Rows.Add("2", "Верх-низ", itemUpDown.DimentionAlong, itemUpDown.DimentionAlongKromka1 + "|" + itemUpDown.DimentionAlongKromka2,
                itemUpDown.DimentionAcross, itemUpDown.DimentionAcrossKromka1 + "|" + itemUpDown.DimentionAcrossKromka2, itemUpDown.Count, MF11());

            detailsInfo.Rows.Add("3 Полки", "Не съёмные", MF12(), DF9() + "|" + DF10(), MF13(), DF11() + "|" + DF12(), MF14(), MF15());
            detailsInfo.Rows.Add("", "Съёмные (-2мм)", MF16(), DF13() + "|" + DF14(), MF17(), DF15() + "|" + DF16(), MF18(), MF19());
            detailsInfo.Rows.Add("4", "Разделитель секции","20" , DF17() + "|" + DF18(), "21", DF19() + "|" + DF20(), "22", "23");

            CalculationItem backItem = new CalculationItem()
            {
                DimentionAlong = MF41().ToString(),
                DimentionAcross = MF42().ToString(),
                Count = MF43(),
                Note = "44",
            };

            FasadeCalculationItem fasadeItem = new FasadeCalculationItem()
            {
                DimentionAcross = MF24().ToString(),
                DimentionAcrossKromka1 = DF21().ToString(),
                DimentionAcrossKromka2 = MF25().ToString(),
                DimentionAlong = DF21().ToString()
            };

            detailsInfo.Rows.Add("5", "Задняя стенка", backItem.DimentionAlong, "" , backItem.DimentionAcross, "", MF43(), "");

            detailsInfo.Rows.Add("Ф1", "Фасад 1", MF24(), DF21() ,MF25(), DF21(), "", "");

            //TODO: add sub type module with facade calculation 2, 3, 4,

            detailsInfo.Rows.Add("Ф2", "Фасад 2", "", "", "", "", "", "");
            detailsInfo.Rows.Add("Ф3", "Фасад 3", "", "", "", "", "", "");
            detailsInfo.Rows.Add("Ф4", "Фасад 4", "", "", "", "", "", "");
            detailsInfo.Rows.Add("3", "Полка стекло", MF32(), "", MF33(), "", MF34(), "");

            detailsInfoItems.Add(item);
            detailsInfoItems.Add(itemUpDown);

            backItems.Add(backItem);
            fasadeInfoItems.Add(fasadeItem);
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
            FurnitureCalculationItem item = new FurnitureCalculationItem()
            {
                Loops = MF35().ToString(),
                Konfirmat = MF36().ToString(),
                Excentric = MF37().ToString(),
                PolkoDerz = MF38_1().ToString(),
                PolkoDerzSteklo = MF38_2().ToString(),
                Handles = MF39().ToString(),                
                SimpleNavesn = MF40().ToString(),
                RegularNaves = F45().ToString(),
                Gazlifts = "0",
            };

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
            furnitureInfo.Rows.Add("Кол-во",
               item.Loops, 
               item.Konfirmat , 
               item.Excentric ,
               item.PolkoDerz,
               item.PolkoDerzSteklo,
               item.Handles,
               item.SimpleNavesn,
               item.RegularNaves,
               item.Gazlifts);

            furnitureInfoItems.Add(item);

            return furnitureInfo;
        }
        
        private int MF35()
        {
            var fasadeHeight = (int) _dimentions.Lenght;
            if (fasadeHeight>0 && fasadeHeight<800)
            {
                return 2;
            }

            if(fasadeHeight>=800 && fasadeHeight<1200)
            {
                return 3;
            }

            if (fasadeHeight>=1200 && fasadeHeight<1500)
            {
                return 4;
            }

            if (fasadeHeight>=1500 && fasadeHeight<=2400)
            {
                return 5;
            }
            return 0;
        }

        //TODO:изменить переменные как надо
        string moduleAssembly = "не разъёмная (конф.)";
        int moduleForm = 1;

        private int MF36()
        {
            //"не разъёмная (конф.)",
            //    "разъёмная (эксцентр.)",
            if (moduleAssembly == "разъёмная (эксцентр.)")
            {
                return 0;
            }

            if (moduleAssembly == "не разъёмная (конф.)" && moduleForm == 0)
            {
                return 8 + (int.Parse(_shelfForRazdel) * 4);
            }

            if (moduleAssembly == "не разъёмная (конф.)" && (moduleForm == 1||moduleForm==2) )
            {
                return 8 + (int.Parse(_shelfForRazdel)*4) + 4;
            }

            return 0;

        }

        private int MF37()
        {
            if (moduleAssembly == "не разъёмная (конф.)")
            {
                return 0;
            }

            if (moduleAssembly == "разъёмная (эксцентр.)" && moduleForm == 0)
            {
                return 8 + (int.Parse(_shelfForRazdel) * 4);
            }

            if (moduleAssembly == "разъёмная (эксцентр.)" && (moduleForm == 1 || moduleForm == 2))
            {
                return 8 + (int.Parse(_shelfForRazdel) * 4) + 4;
            }

            return 0;

        }

        private int MF38_1()
        {
            return int.Parse(_shelfMinusTwoMm)*4;
        }

        private int MF38_2()
        {
            return int.Parse(_shelfGlass)*4;
        }

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
            switch (BackWall)
            {
                case "ГВ":
                    return 2;
                case "Четверть":
                    return 2;
                case "ПАЗ":
                    return 0;
                case "ЛДСП":
                    return 2;
            }
            return 0;
        }

        private int F45()
        {
            switch (BackWall)
            {
                case "ГВ":
                    return 0;
                case "Четверть":
                    return 0;
                case "ПАЗ":
                    return 2;
                case "ЛДСП":
                    return 0;
            }
            return 0;
        }

        public DataTable GetShelfInfo()
        {
            var plateE = int.Parse(_shelfGlass) > 0 ? 5 : int.Parse(_shelfForRazdel);


            DataTable shelfInfo = new DataTable();
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "Shelfs", Caption = "Полки" });
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "P_1", Caption = "№ 1" });
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "P_2", Caption = "№ 2" });
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "P_3", Caption = "№ 3" });
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "P_4", Caption = "№ 4" });
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "P_5", Caption = "№ 5" });
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "P_6", Caption = "№ 6" });

            shelfInfo.Columns.Add(new DataColumn { ColumnName = "Razdel_1", Caption =" Разделитель 1" });
            shelfInfo.Columns.Add(new DataColumn { ColumnName = "Razdel_2", Caption = "Разделитель 2" });

            int countShelfs = int.Parse(_shelfMinusTwoMm);
            double Kp = (_dimentions.Lenght - (ModuleThickness.LDSPThickness * 2)) / (countShelfs + 1);

            var Ki = new List<string>();
            var Li = new List<string>();
            var Mi = new List<string>();

            int maxCountShelfs = 8;
            for(int n=1;n<=maxCountShelfs; n++)
            {
                if (n <= countShelfs)
                {
                    Ki.Add(Math.Round(Kp * n + ModuleThickness.LDSPThickness).ToString());
                    Li.Add(Math.Round((Kp * n) + ModuleThickness.LDSPThickness - (ModuleThickness.LDSPThickness / 2)).ToString());
                    Mi.Add(Math.Round((Kp * n) - ModuleThickness.LDSPThickness - (ModuleThickness.LDSPThickness / 2) - 3).ToString());
                }
                else
                {
                    Ki.Add("");
                    Li.Add("");
                    Mi.Add("");
                }
            }            

            shelfInfo.Rows.Add("K", Ki[0], Ki[1], Ki[2], Ki[3], Ki[4], Ki[5], Ki[6], Ki[7] );
            shelfInfo.Rows.Add("L", Mi[0], Mi[1], Mi[2], Mi[3], Mi[4], Mi[5], Mi[6], Mi[7]);
            shelfInfo.Rows.Add("M", Li[0], Li[1], Li[2], Li[3], Li[4], Li[5], Li[6], Li[7]);

            return shelfInfo;
        }       
     

        public DataTable GetLoopsInfo()
        {
            DataTable loopsInfo = new DataTable();
            loopsInfo.Columns.Add(new DataColumn { ColumnName = "Loops", Caption = "Петли" });
            loopsInfo.Columns.Add(new DataColumn { ColumnName = "First", Caption = "№ 1" });
            loopsInfo.Columns.Add(new DataColumn { ColumnName = "Second", Caption = "№ 2" });
            loopsInfo.Columns.Add(new DataColumn { ColumnName = "Third", Caption = "№ 3" });
            loopsInfo.Columns.Add(new DataColumn { ColumnName = "Fourth", Caption = "№ 4" });
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
            return _dimentions.Lenght - 100-4;
        }

        private double ML2()
        {
            return _dimentions.Lenght - 100 + 2;
        }

        private double L3()
        {
            return (_dimentions.Lenght - 4)/2;

        }

        private double ML3()
        {
            return _dimentions.Lenght/2;
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
                case "Четверть":
                case "ПАЗ":
                case "ЛДСП":
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
                case "ПАЗ":
                    result = "Паз под ДВП";
                    break;
                case "Четверть":
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
                case "ГВ":
                    result = _dimentions.Depth - 5;
                    break;
                case "Четверть":
                    result = _dimentions.Depth - (5 + ModuleThickness.DVP);
                    break;
                case "ПАЗ":
                    result = _dimentions.Depth - (5 + 20);
                    break;
                case "ЛДСП":
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
                case "ГВ":
                    result = _dimentions.Lenght - 2;
                    break;
                case "Четверть":
                    result = _dimentions.Lenght - 10;
                    break;
                case "ПАЗ":
                    result = _dimentions.Lenght - 8;
                    break;
                case "ЛДСП":
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
                case "ГВ":
                    result = _dimentions.Width - 2;
                    break;
                case "Четверть":
                    result = _dimentions.Width - 10;
                    break;
                case "ПАЗ":
                    result = _dimentions.Width - 8;
                    break;
                case "ЛДСП":
                    result = _dimentions.Width - (ModuleThickness.Plate * 2);
                    break;
            }
            return result;
        }

        private int MF43()
        {
            return 1;
        }

        private string MF32()
        {
            if (string.IsNullOrEmpty(_shelfGlass))
            {
                _shelfGlass = "0";
            }
          //  _shelfGlass =  _shelfGlass ?? "0";
            return int.Parse(_shelfGlass) > 0 ? MF16().ToString() : "";
        }

        private string MF33()
        {
            return int.Parse(_shelfGlass) > 0 ? MF17().ToString() : "";
        }

        private string MF34()
        {
            return int.Parse(_shelfGlass) > 0 ? _shelfGlass : "";
        }

        private double MF24()
        {
            var moduleForm = 1;
            double result = 0;
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result =_dimentions.Lenght - 4;
                        break;
                    case "Гориз.":
                        result =  _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Lenght - 4;
                        break;
                }
            }
            else if(moduleForm ==2)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Lenght -_dimentions.A - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Lenght - _dimentions.A - 4;
                        break;
                }
            }
            else if (moduleForm == 3)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Lenght - _dimentions.A - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Lenght - _dimentions.A - 4;
                        break;
                }
            }
            return result;

        }

        private double MF25()
        {
            var moduleForm = 1;
            double result = 0;
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Width - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Lenght - 4;
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
                        result = _dimentions.Lenght-_dimentions.A - 4;
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
                        result = _dimentions.Lenght - _dimentions.A - 4;
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
            return GetKromkaThickness(ModuleThickness.F);
        }

        private string DF2()
        {
            return GetKromkaThickness(ModuleThickness.B);
        }

        private string DF3()
        {
            return GetKromkaThickness(ModuleThickness.H);
        }

        private string DF4()
        {
            return GetKromkaThickness(ModuleThickness.D);

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
            return GetKromkaThickness(ModuleThickness.FP);

        }

        private string DF10()
        {
            return GetKromkaThickness(ModuleThickness.BP);
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
            return GetKromkaThickness(ModuleThickness.LRP);
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
            return GetKromkaThickness(ModuleThickness.LRP);
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

            if (_facade._records[0].Type == "нет" || (int)ModuleThickness.FF == 0)
            {
                result = "";
            }

            if (_facade._records[0].Type !="нет" && ModuleThickness.FF==0.4)
            {
                result = "I";
            }

            if (_facade._records[0].Type != "нет" && ModuleThickness.FF == 2)
            {
                result = "V";
            }

            return result;
        }


        #endregion

    }



}

using System;
using System.Collections.Generic;

namespace Automation.Model
{
    public static class ModuleThickness
    {

        public static double LDSPThickness { get; set; }
        public static double LDSPKantThickness { get; set; }
        public static double BackWallThickness { get; set; }
        public static double FasadeThickness { get; set; }

        public static double F { get; set; }
        public static double H { get; set; }
        public static double D { get; set; }
        public static double LR { get; set; }
        public static double B { get; set; }
        public static double FP { get; set; }
        public static double LRP { get; set; }
        public static double BP { get; set; }
        public static double FF { get; set; }

        public static double DVP { get; set; }
        public static double Plate { get; set; }

        public static double InputPlateConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "":
                    break;
                
            }
            return result;
        }

        public static double InputDvpConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "":
                    break;

            }
            return result;
        }

        static ModuleThickness()
        {
            SetAllSameValues("2 мм");
        }

        public static double InputConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 мм":
                    result = 0.4;
                    break;
                case "2 мм":
                    result = 2;
                    break;
                case "эконом. 2мм":
                    result = 2;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

     
        public static void SetAllSameValues(string value)
        {
            F = InputConverter(value);
            H = InputConverter(value);
            D = InputConverter(value);
            LR = InputConverter(value);
            B = InputConverter(value);
            FP = InputConverter(value);
            LRP = InputConverter(value);
            BP = InputConverter(value);
            FF = InputConverter(value);
        }

        public static double GetLDSPThicknessValue(string LDSPThickness)
        {
            double ldspThickness = 0;
            if (LdspThicknessValues.ContainsKey(LDSPThickness))
            {
                ldspThickness = LdspThicknessValues[LDSPThickness];
            }

            return ldspThickness;
        }
        
        public static double GetBackWallThickness(string value)
        {
            double backwallThickness = 0;
            if (LdspThicknessValues.ContainsKey(value))
            {
                backwallThickness = LdspThicknessValues[value];
            }

            return backwallThickness;
        }

        public static double GetFasadeThickness(string value)
        {
            double fasadeThickness = 0;
            if (LdspThicknessValues.ContainsKey(value))
            {
                fasadeThickness = LdspThicknessValues[value];
            }

            return fasadeThickness;
        }
        

        public static Dictionary<string, int> LdspThicknessValues { get; } = new Dictionary<string, int>
        {
            {"10 мм", 10},
            {"16 мм", 16},
            {"18 мм", 18},
            {"20 мм", 20},
            {"22 мм", 22}
        };

        public static Dictionary<string, double> KromkaThicknessValues { get; } = new Dictionary<string, double>
        {
            {"нет", 0},
            {"0.4 мм", 0.4},
            {"2 мм", 2},
            {"эконом. 2 мм", 2},
            {"персонально", 0}
        };

        public static Dictionary<string, double> BackWallThicknessValues { get; } = new Dictionary<string, double>
        {
            {"нет", 0},
            {"3 мм", 3},
            {"4 мм (станд.) ДВА, фанера", 4},
            {"4,2 мм ДВП импорт.", 4.2},
            {"6 мм", 6},
            {"8 мм", 8},
            {"10 мм", 10},
            {"12 мм", 12},
            {"16 мм", 16}
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    public static class ModuleThickness
    {

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
    }
}

namespace Automation.Model
{
    public static class ModuleThickness
    {

        public static double FrontModule { get; set; }
        public static double UpModule { get; set; }
        public static double DownModule { get; set; }
        public static double SideModule { get; set; }
        public static double BackModule { get; set; }
        public static double FrontShelf { get; set; }
        public static double SideShelf { get; set; }
        public static double BackShelf { get; set; }
        public static double Facade { get; set; }

        public static double BackPanel { get; set; }
        public static double Plate { get; set; }

        private static bool UseDefaultValues = false;

        public static double InputPlateConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "10 мм":
                    result = 10;
                    break;
                case "16 мм":
                    result = 16;
                    break;
                case "18 мм":
                    result = 18;
                    break;
                case "20 мм":
                    result = 20;
                    break;
                case "22 мм":
                    result = 22;
                    break;
            }
            return result;
        }

        public static double InputBackPanelConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "3,2 мм":
                    result = 3.2;
                    break;
                case "4 мм":
                    result = 4;
                    break;
                case "4,2 мм":
                    result = 4.2;
                    break;
                case "6 мм":
                    result = 6;
                    break;
                case "8 мм":
                    result = 8;
                    break;
                case "10 мм":
                    result = 10;
                    break;
                case "12 мм":
                    result = 12;
                    break;
                case "16 мм":
                    result = 16;
                    break;
            }
            return result;
        }

        static ModuleThickness()
        {
            SetAllSameValues("2 мм");
            SetPlateThickness("10 мм");
            SetBackPanelThickness("нет");
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

        public static void SetBackPanelThickness(string value)
        {
            BackPanel = InputBackPanelConverter(value);
        }

        public static void SetPlateThickness(string value)
        {
            Plate = InputPlateConverter(value);
        }

        public static void SetAllSameValues(string value)
        {
            FrontModule = InputConverter(value);
            UpModule = InputConverter(value);
            DownModule = InputConverter(value);
            SideModule = InputConverter(value);
            BackModule = InputConverter(value);
            FrontShelf = InputConverter(value);
            SideShelf = InputConverter(value);
            BackShelf = InputConverter(value);
            Facade = InputConverter(value);
        }
    }
}
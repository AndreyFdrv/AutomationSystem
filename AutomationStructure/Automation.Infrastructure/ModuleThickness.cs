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
            FrontModule = InputConverter(value);
            UpModule = InputConverter(value);
            DownModule = InputConverter(value);
            SideModule = InputConverter(value);
            BackModule = InputConverter(value);
            FrontShelf = InputConverter(value);
            SideShelf = InputConverter(value);
            BackShelf = InputConverter(value);
            Facade = InputConverter(value);
            BackPanel = InputConverter(value);
            Plate = InputConverter(value);
        }
    }
}

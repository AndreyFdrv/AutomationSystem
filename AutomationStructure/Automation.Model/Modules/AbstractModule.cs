using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace Automation.Model.Modules
{
    abstract class AbstractModule
    {

        //поля состояния

        public string Name { get; set; }
        public string Sсheme { get; set; }

        protected Dimensions dimentions;

        protected string BackWall { get; set;}

        public abstract DataTable GetModuleView();

        public abstract void SetupData();

        public abstract DataTable GetView();

        public abstract DataTable GetInfoTable();


    }


    class Dimensions
    {

        public Dimensions()
        {
            
        }

        public double Depth { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }


        public double Calculate()
        {
            return 0;
        }

    }

    class Facade
    {
        List<FacadeRecord> _records;

        public Facade()
        {
           _records = new List<FacadeRecord>();
        }

        public void InitFacadeRecords(int numberRecords)
        {
            for (int i = 0; i < numberRecords; i++)
            {
                _records.Add(new FacadeRecord { NumberOnScheme = i+1});
            }
            
        }

    }

    class FacadeRecord
    {
        public int NumberOnScheme { get; set; }

        public string Type { get; set; }

        public double VerticalDimension { get; set; }

        public double HorisontalDimension { get; set; }

        public string Material { get; set; }

    }
}

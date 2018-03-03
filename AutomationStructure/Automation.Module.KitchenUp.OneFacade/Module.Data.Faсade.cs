using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Module.KitchenUp.OneFacade
{
    class Facade
    {
        public int NumberOnScheme { get; set; }
        public double HorizontalDimension { get; set; }
        public double VerticalDimension { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }

        public void CalculateDimentions(Dimensions dimensions)
        {

        }
    }
}

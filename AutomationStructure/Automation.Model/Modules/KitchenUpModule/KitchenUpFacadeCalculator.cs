using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules.KitchenUpModule
{
    [Serializable]
    class KitchenUpFacadeCalculator
    {
        public void CalculateDimentions(Facade _facade, Dimensions _dimentions, string formula)
        {
            switch (formula)
            {
                case "F1-01-0001":

                    _facade._records[0].HorisontalDimension = _dimentions.Width - 4;
                    _facade._records[0].VerticalDimension = _dimentions.Lenght - 4;

                    break;
            }
           
        }


    }
}

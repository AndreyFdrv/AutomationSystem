using System;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUp
{
    [Serializable]
    class KitchenUpFacadeCalculator
    {
        public void CalculateDimentions(Facade _facade, Dimensions _dimentions, string formula, int index)
        {
            switch (formula)
            {
                case "F1-01-0001":

                    _facade._records[index].HorisontalDimension = _dimentions.Width - 4;
                    _facade._records[index].VerticalDimension = _dimentions.Hight - 4;

                    break;
            }
           
        }


    }
}

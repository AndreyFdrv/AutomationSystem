using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules
{
    class KitchenUpModule: AbstractModule
    {
        public KitchenUpModule()
        {
           _facade = new Facade();
        }

        public override void SetupData()
        {
            
        }

        public override DataTable GetView()
        {
            return null;
        }


        public string ShelfPO { get; set; }

        public string ShelfMinusTwoMM { get; set; }

        public string ShelfForRazdel { get; set; }

        public string ShelfGlass { get; set; }


        Facade _facade;



        public override DataTable GetModuleView()
        {
            return  new DataTable();
        }
    }
}

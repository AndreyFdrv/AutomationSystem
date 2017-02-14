using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules
{
    class KitchenDown:AbstractModule
    {
        public KitchenDown()
        {
            _facade = new Facade();
        }


        public string ShelfPO { get; set; }

        public string ShelfMinusTwoMM { get; set; }

        public string ShelfForRazdel { get; set; }

        public string ShelfGlass { get; set; }
        
        Facade _facade;
        

   

        public override void SetupModule(DataTable changedInfo)
        {
            throw new NotImplementedException();
        }

        public override void GetInfoRows(DataTable table)
        {
            throw new NotImplementedException();
        }

        public override DataTable GetInfoTable()
        {
            throw new NotImplementedException();
        }

        public override DataTable GetEmptyTable()
        {
            throw new NotImplementedException();
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        //TODO:Мб принимать строки?
        public void SetupData(params string[] parameters )
        {
            //присваиваем значения переменным
        }
    }

   
}

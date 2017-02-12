using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules
{
    class KitchenDownModule:AbstractModule
    {
        public KitchenDownModule()
        {
            _facade = new Facade();
        }


        public string ShelfPO { get; set; }

        public string ShelfMinusTwoMM { get; set; }

        public string ShelfForRazdel { get; set; }

        public string ShelfGlass { get; set; }
        
        Facade _facade;
        

        public override DataTable GetModuleView()
        {
            return new DataTable();
        }

        public override void SetupData()
        {
            throw new NotImplementedException();
        }

        public override DataTable GetView()
        {
            //TODO:Добавить колонки к таблице. мб передавать список строк?
            DataTable viewTbl = new DataTable();
            viewTbl.Columns.Add("Название модуля");
            viewTbl.Columns.Add("Схема модуля");
           // viewTbl.Columns.Add("Ещё одна колонка");

            DataRow row = viewTbl.NewRow();
            row[0] = Name;
            row[1] = Sсheme;

            viewTbl.Rows.Add(row);

            return viewTbl;
        }

        //TODO:Мб принимать строки?
        public void SetupData(params string[] parameters )
        {
            //присваиваем значения переменным
        }
    }

   
}

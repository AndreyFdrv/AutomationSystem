using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules
{
    class KitchenUp: AbstractModule
    {
        public KitchenUp()
        {
           _facade = new Facade();
           _dimentions = new Dimensions();
        }


        Dimensions _dimentions;
        Facade _facade;
        public string ShelfPO { get; set; }
        public string ShelfMinusTwoMM { get; set; }
        public string ShelfForRazdel { get; set; }
        public string ShelfGlass { get; set; }
        

        public override void SetupModule(DataTable changedInfo)
        {
            //TODO:Дописать обновление данных модуля
            int countRows = changedInfo.Rows.Count;
            DataRow row = changedInfo.Rows[0];
            Name = row[0].ToString();
            Sсheme = row[1].ToString();
            _dimentions.Lenght = double.Parse(row[2].ToString());
            _dimentions.Width = double.Parse(row[3].ToString());
            _dimentions.Depth = double.Parse(row[4].ToString()) ;
            _dimentions.A = double.Parse(row[5].ToString());
            _dimentions.B = double.Parse(row[6].ToString()); 
            _dimentions.C = double.Parse(row[7].ToString());
            _dimentions.D = double.Parse(row[8].ToString());
             Material = row[9].ToString();
            BackWall = row[10].ToString();
            ShelfPO = row[11].ToString();
            ShelfMinusTwoMM = row[12].ToString();
            ShelfForRazdel = row[13].ToString();
            ShelfGlass = row[14].ToString();

            if (_dimentions.A > 0 & _dimentions.B > 0 & _dimentions.C > 0)
            {
                CalculateFacade();
            }

            _facade._records[0].NumberOnScheme = int.Parse(row[15].ToString());
            _facade._records[0].HorisontalDimension = double.Parse(row[16].ToString());
            //row[17] = _facade._records[0].VerticalDimension= double.
           // row[18] = _facade._records[0].Material;


        }

        public override void GetInfoRows(DataTable table)
        {
          
            int countRows = GetCountRows();
            _facade.InitFacadeRecords(countRows);

            DataRow row = table.NewRow();
            row[0] = Name;
            row[1] = Sсheme;
            row[2] = _dimentions.Lenght;
            row[3] = _dimentions.Width;
            row[4] = _dimentions.Depth;
            row[5] = _dimentions.A;
            row[6] = _dimentions.B;
            row[7] = _dimentions.C;
            row[8] = _dimentions.D;
            row[9] = Material;
            row[10] = BackWall;
            row[11] = ShelfPO;
            row[12] = ShelfMinusTwoMM;
            row[13] = ShelfForRazdel;
            row[14] = ShelfGlass;
            if (_dimentions.A > 0 & _dimentions.B > 0 & _dimentions.C > 0)
            {
                CalculateFacade();
            }
            row[15] = _facade._records[0].NumberOnScheme;
            row[16] = _facade._records[0].HorisontalDimension;
            row[17] = _facade._records[0].VerticalDimension;
            row[18] = _facade._records[0].Material;
            table.Rows.Add(row);

            if (countRows>1)
            {
                for (int i = 1; i < countRows; i++)
                {
                    DataRow anotherRow = table.NewRow();
                    anotherRow[15] = _facade._records[i].NumberOnScheme;
                    anotherRow[16] = _facade._records[i].HorisontalDimension;
                    anotherRow[17] = _facade._records[i].VerticalDimension;
                    anotherRow[18] = _facade._records[i].Material;
                    table.Rows.Add(anotherRow);
                }

            }
        }

        private void CalculateFacade()
        {
            if (_dimentions.A>0 & _dimentions.B>0 & _dimentions.C>0)
            {
                _facade._records[0].HorisontalDimension = _dimentions.A + 1;
                _facade._records[1].VerticalDimension = _dimentions.B + 1;
            }
        }

        private int GetCountRows()
        {
            int count = 1;
        
            switch (Sсheme)
            {
                case "1.jpg":
                    count = 1;
                    break;
                case "2+B.jpg":
                    count = 2;
                    break;
                    
            }

            return count;
        }
        
        public override DataTable GetInfoTable()
        {
            DataTable table = GetEmptyTable();
            GetInfoRows(table);
            return table;
        }

        public override DataTable GetEmptyTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Название модуля");
            table.Columns.Add("Схема");
            table.Columns.Add("В размер");
            table.Columns.Add("Ш размер");
            table.Columns.Add("Г размер");
            table.Columns.Add("A размер");
            table.Columns.Add("B размер");
            table.Columns.Add("C размер");
            table.Columns.Add("D размер");

            table.Columns.Add("Материал");
            table.Columns.Add("Задняя стенка");
            table.Columns.Add("Полки по");
            table.Columns.Add("Полка - 2мм");
            table.Columns.Add("Полка раздел");
            table.Columns.Add("Полка стекло");
            table.Columns.Add("№ схемы фасада");
            table.Columns.Add("Вертикальный размер");
            table.Columns.Add("Горизонтальный размер");
            table.Columns.Add("Материал фасада");
            return table;
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}

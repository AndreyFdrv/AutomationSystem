using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model.Modules.KitchenUpModule
{
    [Serializable]
    class KitchenUp: AbstractModule
    {
        public KitchenUp()
        {
           _facade = new Facade();
           _dimentions = new Dimensions();
           _calculator = new KitchenUpFacadeCalculator();
        }

        private KitchenUpFacadeCalculator _calculator;
        private Dimensions _dimentions;
        private Facade _facade;
        private string ShelfPo { get; set; }
        private string ShelfMinusTwoMm { get; set; }
        private string ShelfForRazdel { get; set; }
        private string ShelfGlass { get; set; }
        

        public override void SetupModule(DataTable changedInfo)
        {
            //todo
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
            
            BackWall = row[10].ToString();
            ShelfPo = row[11].ToString();
            ShelfMinusTwoMm = row[12].ToString();
            ShelfForRazdel = row[13].ToString();
            ShelfGlass = row[14].ToString();

            if (_dimentions.A > 0 & _dimentions.B > 0 & _dimentions.C > 0)
            {
                CalculateFacade();
            }

            _facade._records[0].NumberOnScheme = int.Parse(row[15].ToString());
           // _facade._records[0].HorisontalDimension = double.Parse(row[16].ToString());
            //row[17] = _facade._records[0].VerticalDimension= double.
           // row[18] = _facade._records[0].Material;


        }

        public override void GetInfoRows(DataTable table)
        {
          
            int countRows = GetCountRows();
            _facade.InitFacadeRecords(countRows);


            //table.Columns.Add("Название модуля");     0
            //table.Columns.Add("Форма модуля");        1
            //table.Columns.Add("Высота модуля (мм)");  2   
            //table.Columns.Add("Ширина модуля (мм)");  3
            //table.Columns.Add("Глубина модуля (мм)"); 4
            //table.Columns.Add("A размер (мм)");       5
            //table.Columns.Add("B размер (мм)");       6
            //table.Columns.Add("C размер (мм)");       7
            //table.Columns.Add("D размер (мм)");       8
            //table.Columns.Add("Задняя стенка");       9

            //table.Columns.Add("Полка по ширине секции (шт)");  10
            //table.Columns.Add("Полка - 2мм (шт)");             11
            //table.Columns.Add("Полка разделительная (шт)");    12
            //table.Columns.Add("Полка стеклянная (шт)");        13
            //table.Columns.Add("№ схемы фасада");               14
            //table.Columns.Add("Тип фасада");                   15
            //table.Columns.Add("Вертикальный размер");          16
            //table.Columns.Add("Горизонтальный размер");        17
            //table.Columns.Add("Материал фасада");              18


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
           
            row[9] = BackWall;
            row[10] = ShelfPo;
            row[11] = ShelfMinusTwoMm;
            row[12] = ShelfForRazdel;
            row[13] = ShelfGlass;

            if (_dimentions.A > 0 & _dimentions.B > 0 & _dimentions.C > 0)
            {
                CalculateFacade();
            }

            row[14] = _facade._records[0].NumberOnScheme;
            row[15] = _facade._records[0].Type;
            row[16] = _facade._records[0].VerticalDimension;
            row[17] = _facade._records[0].HorisontalDimension;
            row[18] = _facade._records[0].Material;
            table.Rows.Add(row);

            if (countRows>1)
            {
                for (int i = 1; i < countRows; i++)
                {
                    DataRow anotherRow = table.NewRow();
                    anotherRow[14] = _facade._records[i].NumberOnScheme;
                    anotherRow[15] = _facade._records[i].Type;
                    anotherRow[16] = _facade._records[i].VerticalDimension;
                    anotherRow[17] = _facade._records[i].HorisontalDimension;
                    anotherRow[18] = _facade._records[i].Material;
                    table.Rows.Add(anotherRow);
                }
            }


        }
        

        private void CalculateFacade()
        {
            if (_dimentions.A>0 & _dimentions.B>0 & _dimentions.C>0)
            {
                _calculator.CalculateDimentions(_facade, _dimentions, base.Sсheme);
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
            table.Columns.Add("Форма модуля");
            table.Columns.Add("Высота модуля (мм)");
            table.Columns.Add("Ширина модуля (мм)");
            table.Columns.Add("Глубина модуля (мм)");
            table.Columns.Add("A размер (мм)");
            table.Columns.Add("B размер (мм)");
            table.Columns.Add("C размер (мм)");
            table.Columns.Add("D размер (мм)");
            table.Columns.Add("Задняя стенка");
            table.Columns.Add("Полка по ширине секции (шт)");
            table.Columns.Add("Полка - 2мм (шт)");
            table.Columns.Add("Полка разделительная (шт)");
            table.Columns.Add("Полка стеклянная (шт)");
            table.Columns.Add("№ схемы фасада");
            table.Columns.Add("Тип фасада");
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

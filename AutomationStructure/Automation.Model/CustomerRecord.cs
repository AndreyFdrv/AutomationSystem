using System;
using System.Globalization;

namespace Automation.Model
{
    public class CustomerRecord
    {
        public CustomerRecord()
        { }

        public string Material { get; set; }
        public string CompanyName { get; set; }
        public string Color { get; set; }
        public string CodeColor { get; set; }
        public string ThicknessMaterial { get; set; }
        public bool HaveSpecificThickness { get; set; }


        public ThicknessSpecificData GetSpecificData()
        {
            //Возвращаем объект для 
            return null;
        }

       
        public override string ToString()
        {
            return "Материал: " + Material +
                   "Заказчик:" + CompanyName +
                   "Цвет:" + Color +
                   "Код цвета:" + CodeColor +
                   "Толщина" + ThicknessMaterial;
        }
    }
}
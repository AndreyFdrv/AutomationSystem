using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Model.Modules;

namespace Automation.Model
{
    class Product
    {
        public string NameProduct { get; set; }
        // public List<> 
        //список модулей
        private List<AbstractModule> _modules;

        public Product()
        {
            _modules = new List<AbstractModule>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Infrastructure;

namespace KitchenUpModule.OneFacade.DTO
{
    class ModuleDetailCollection:IModuleDetailCollection
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public string LengthEdgeBandingTape { get; set; }
        public double Width { get; set; }
        public string WidthEdgeBandingTape { get; set; }
        public int Count { get; set; }
        public string Note { get; set; }
    }
}

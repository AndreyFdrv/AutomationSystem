using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Infrastructure
{
    public interface IModuleDetailCollection
    {
        string Name { get; set; }
        double Length { get; set; }
        string LengthEdgeBandingTape { get; set; }
        double Width { get; set; }
        string WidthEdgeBandingTape { get; set; }
        int Count { get; set; }
        string Note { get; set; }
    }
}

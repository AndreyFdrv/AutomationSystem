using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    class CalculationDetailsItem
    {
        public string DimentionAlong { get; set; }
        public string DimentionAcross { get; set; }
        public string DimentionAlongKromka1 { get; set; }
        public string DimentionAlongKromka2 { get; set; }
        public string DimentionAcrossKromka1 { get; set; }
        public string DimentionAcrossKromka2 { get; set; }
        public int Count { get; set; }
        public string Note { get; set; }
    }
}

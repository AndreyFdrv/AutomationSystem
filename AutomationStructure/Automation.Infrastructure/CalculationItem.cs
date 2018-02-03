using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Infrastructure
{
    [Serializable]
    public class CalculationItem
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

    [Serializable]
    public class FurnitureCalculationItem
    {
        public string Loops { get; set; }
        public string Konfirmat { get; set; }
        public string Excentric { get; set; }
        public string PolkoDerz { get; set; }
        public string PolkoDerzSteklo { get; set; }
        public string Handles { get; set; }
        public string SimpleNavesn { get; set;}
        public string RegularNaves { get; set; }
        public string Gazlifts { get; set; }
    }

    [Serializable]
    public class FasadeCalculationItem
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

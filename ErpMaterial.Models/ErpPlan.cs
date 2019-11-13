using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class ErpPlan
    {
        public int ErpPlanId { get; set; }
        public string Rsnum { get; set; }
        public string Rspos { get; set; }
        public string Matnr { get; set; }
        public string Maktx { get; set; }
        public double? Bdmng { get; set; }
        public string Ztbdw { get; set; }
        public string Rkpf { get; set; }
        public string Ztbrq { get; set; }
    }
}

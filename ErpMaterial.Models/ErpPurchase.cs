using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class ErpPurchase
    {
        public int ErpPurchaseId { get; set; }
        public string Ebeln { get; set; }
        public string Ebelp { get; set; }
        public string Matnr { get; set; }
        public string Maktx { get; set; }
        public double? Menge { get; set; }
        public string MengeUnit { get; set; }
        public string Lifnr { get; set; }
        public string LifnrDesc { get; set; }
        public string Interiorcode { get; set; }
        public string ReleaseDate { get; set; }
        public string Bldat { get; set; }
        public double? Netpr { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}

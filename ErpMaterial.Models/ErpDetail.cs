using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class ErpDetail
    {
        public int ErpDetailId { get; set; }
        public string Mblnr { get; set; }
        public string Mjahr { get; set; }
        public string Budat { get; set; }
        public string Bldat { get; set; }
        public string Belnr { get; set; }
        public string Bwart { get; set; }
        public string Matnr { get; set; }
        public string Maktx { get; set; }
        public string Matkl { get; set; }
        public string Werks { get; set; }
        public string Lgort { get; set; }
        public string LgortDesc { get; set; }
        public string Sobkz { get; set; }
        public string Lifnr { get; set; }
        public string LifnrDesc { get; set; }
        public string Kunnr { get; set; }
        public double? Menge { get; set; }
        public string Meins { get; set; }
        public string Ebeln { get; set; }
        public string Ebelp { get; set; }
        public string Rsnum { get; set; }
        public string Rspos { get; set; }
        public string Umwrk { get; set; }
        public string Umlgo { get; set; }
        public string UmlgoDesc { get; set; }
        public string Kostl { get; set; }
        public string Ktext { get; set; }
        public string Pspel { get; set; }
        public string Zthdw { get; set; }
    }
}

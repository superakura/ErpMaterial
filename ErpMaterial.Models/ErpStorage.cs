using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class ErpStorage
    {
        public int ErpStorageId { get; set; }
        public string Werks { get; set; }
        public string Lgort { get; set; }
        public string Lgnum { get; set; }
        public string Lgtyp { get; set; }
        public string Lgpla { get; set; }
        public string Matnr { get; set; }
        public string Maktx { get; set; }
        public string Matkl { get; set; }
        public double? Verme { get; set; }
        public double? Salk { get; set; }
        public string Msehl { get; set; }
        public string Wdatu { get; set; }
        public string NameTextc { get; set; }
        public string Aging { get; set; }
    }
}

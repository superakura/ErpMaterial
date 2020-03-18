using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class MaterialProcurement
    {
        public int MaterialProcurementId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int? MaterialCount { get; set; }
        public string Supplier { get; set; }
        public string ContractNo { get; set; }
        public string ContractDate { get; set; }
        public string ProcurementPrice { get; set; }
        public DateTime? MaterialArrivalDate { get; set; }
    }
}

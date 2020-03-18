using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class MaterialStorage
    {
        public int MaterialStorageId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDesc { get; set; }
        public int? MaterialCount { get; set; }
        public DateTime? StorageTime { get; set; }
        public DateTime? TransferTime { get; set; }
        public string Supplier { get; set; }
        public string ContractNo { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PlanReportDept { get; set; }
        public string PlanReportPerson { get; set; }
        public DateTime? PlanReportDateTime { get; set; }
        public DateTime? MaterialAge { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class MaterialUse
    {
        public int MaterialUseId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDesc { get; set; }
        public int? MaterialCount { get; set; }
        public string ContractNo { get; set; }
        public DateTime? StorageTime { get; set; }
        public DateTime? TransferTime { get; set; }
        public DateTime? OutStockTime { get; set; }
        public string UsePerson { get; set; }
        public string UserDept { get; set; }
        public string DeviceNo { get; set; }
        public string MaterialAge { get; set; }
    }
}

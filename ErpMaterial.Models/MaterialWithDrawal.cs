using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class MaterialWithDrawal
    {
        public int MaterialWithDrawalId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDesc { get; set; }
        public string MaterialCount { get; set; }
        public string StorageTime { get; set; }
        public string TransferTime { get; set; }
        public string OutStockTime { get; set; }
        public string UsePerson { get; set; }
        public string UserDept { get; set; }
        public string Custodian { get; set; }
        public string ReturnDate { get; set; }
        public string ProjectName { get; set; }
    }
}

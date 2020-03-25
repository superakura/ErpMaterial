using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class MaterialUrgentContract
    {
        public int UrgentContractId { get; set; }
        public string UrgentContractNum { get; set; }
        public string UrgentContractName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int? CreateUserId { get; set; }
        public int? EditUserId { get; set; }
        public string IsDel { get; set; }
    }
}

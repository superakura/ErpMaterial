using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class MaterialFrameContract
    {
        public int FrameContractId { get; set; }
        public string FrameContractNum { get; set; }
        public string FrameContractName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int? CreateUserId { get; set; }
        public int? EditUserId { get; set; }
        public string IsDel { get; set; }
    }
}

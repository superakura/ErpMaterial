using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class SysDeptInfo
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int? DeptFatherId { get; set; }
        public string DeptState { get; set; }
        public string DeptRemark { get; set; }
        public int? DeptOrder { get; set; }
        public byte? IsOpen { get; set; }
        public DateTime? DeptCreateDate { get; set; }
    }
}

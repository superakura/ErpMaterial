using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class PlanReport
    {
        public int PlanReportId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDesc { get; set; }
        public int? MaterialCount { get; set; }
        public string PlanReportDept { get; set; }
        public string PlanReportPerson { get; set; }
        public DateTime? PlanReportDateTime { get; set; }
        public string MaterialAge { get; set; }
    }
}

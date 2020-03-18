using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class SysLog
    {
        public int LogId { get; set; }
        public DateTime? LogDate { get; set; }
        public string LogType { get; set; }
        public string LogLevel { get; set; }
        public int? LogPersonId { get; set; }
        public string LogPersonName { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
    }
}

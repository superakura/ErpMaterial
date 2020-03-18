using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class SysNoticeInfo
    {
        public int NoticeId { get; set; }
        public string NoticeTitle { get; set; }
        public string ContentInfo { get; set; }
        public string ContentType { get; set; }
        public int? ContentCount { get; set; }
        public string InsertPersonNum { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}

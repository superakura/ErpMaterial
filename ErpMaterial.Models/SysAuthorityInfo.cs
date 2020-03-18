using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class SysAuthorityInfo
    {
        public SysAuthorityInfo()
        {
            SysRoleAuthority = new HashSet<SysRoleAuthority>();
        }

        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }
        public string AuthorityDescribe { get; set; }
        public string AuthorityGroup { get; set; }
        public string AuthorityType { get; set; }
        public int ConflictCode { get; set; }
        public string MenuUrl { get; set; }
        public int? MenuOrder { get; set; }
        public int? MenuFatherId { get; set; }
        public string MenuIcon { get; set; }
        public string MenuName { get; set; }

        public virtual ICollection<SysRoleAuthority> SysRoleAuthority { get; set; }
    }
}

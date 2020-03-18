using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class SysRoleAuthority
    {
        public int RoleAuthorityId { get; set; }
        public int RoleId { get; set; }
        public int AuthorityId { get; set; }

        public virtual SysAuthorityInfo Authority { get; set; }
        public virtual SysRoleInfo Role { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class SysRoleInfo
    {
        public SysRoleInfo()
        {
            SysRoleAuthority = new HashSet<SysRoleAuthority>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescribe { get; set; }
        public string IsDefaultRole { get; set; }

        public virtual ICollection<SysRoleAuthority> SysRoleAuthority { get; set; }
    }
}

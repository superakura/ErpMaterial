using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class SysUserRole
    {
        public int UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }
}

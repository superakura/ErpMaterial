using System;
using System.Collections.Generic;

namespace ErpMaterial.Service.ViewModel
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserNum { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int? UserDeptId { get; set; }
        public string UserPhone { get; set; }
        public string UserMobile { get; set; }
        public string UserDuty { get; set; }
        public string UserEmail { get; set; }
        public string UserRemark { get; set; }
        public string UserState { get; set; }
        public string UserRoleList { get; set; }
        public string UserAuthorityList { get; set; }
        public string UserDeptCtrlList { get; set; }
        public string UserDeptCtrlChildList { get; set; }
        public string UserDeptName { get; set; }
    }
}

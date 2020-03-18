using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface ISysRoleAuthService
    {
        PageLayUI<RoleAuty> listPage(int page, int limit, Dictionary<string, object> whereList);

        bool Update(SysRoleAuthority info);

        bool Del(int id);

        /// <summary>
        /// 根据权限ID和角色ID判断权限是否已经存在，true表示不存在
        /// </summary>
        /// <param name="authID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        bool CheckAuth(int authID, int roleID);

        int[] GetAuthIdListByRoleID(int[] roldID);

        string GetAuthIdListByRoleID(string roldIdList);
    }
}

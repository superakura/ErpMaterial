using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface ISysRoleService
    {
        PageLayUI<SysRoleInfo> listPage(int page, int limit, Dictionary<string, object> whereList);

        bool Update(SysRoleInfo info);

        bool Del(int id);

        SysRoleInfo GetOne(int id);

        List<SysRoleInfo> GetAllList(string idList);
    }
}

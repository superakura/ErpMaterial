using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface ISysAuthorityService
    {
        PageLayUI<SysAuthorityInfo> listPage(int page, int limit, Dictionary<string, object> whereList);

        bool Update(SysAuthorityInfo sysAuthorityInfo);

        bool Del(int id);

        MenuLayUI memuList(List<int> userMenuID);
    }
}

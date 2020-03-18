using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface ISysNoticeService
    {
        PageLayUI<SysNoticeInfo> listPage(int page, int limit, Dictionary<string, object> conditions);

        bool Update(SysNoticeInfo info);

        bool Del(int id);

        SysNoticeInfo GetOne(int id);
    }
}

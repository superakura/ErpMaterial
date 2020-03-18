﻿using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface ISysUserService
    {
        PageLayUI<UserInfo> listPage(int page, int limit, Dictionary<string, object> whereList);

        bool Update(SysUserInfo info);

        bool Del(int id);

        UserInfo GetOne(int id);
    }
}

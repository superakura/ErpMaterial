using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface ISysDeptService
    {
        List<DeptLayUI> ListAll(string selectDeptList);

        bool Update(SysDeptInfo info);

        bool Del(int id);

        SysDeptInfo GetOne(int id);
    }
}

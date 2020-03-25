using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface IMaterialUrgentContractService
    {
        PageLayUI<MaterialUrgentContract> listPage(int page, int limit, Dictionary<string, object> whereList);

        MaterialUrgentContract GetOne(int id);

        bool Update(MaterialUrgentContract info);

        bool Del(int id);
    }
}

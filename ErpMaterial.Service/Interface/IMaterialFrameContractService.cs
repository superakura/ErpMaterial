using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface IMaterialFrameContractService
    {
        PageLayUI<MaterialFrameContract> listPage(int page, int limit, Dictionary<string, object> whereList);

        MaterialFrameContract GetOne(int id);

        bool Update(MaterialFrameContract info);

        bool Del(int id);
    }
}

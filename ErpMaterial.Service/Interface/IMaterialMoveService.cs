using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface IMaterialMoveService
    {
        PageLayUI<ViewMaterialBack> listPage(int page, int limit, Dictionary<string, object> whereList);
    }
}

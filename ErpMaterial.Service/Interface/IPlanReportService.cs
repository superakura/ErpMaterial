using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface IPlanReportService
    {
        PageLayUI<PlanReport> listPage(int page, int limit,Dictionary<string,object> whereList);

        bool Update(Models.PlanReport planReport);

        bool Del(int id);
    }
}

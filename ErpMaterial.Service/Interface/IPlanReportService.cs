using System;
using System.Collections.Generic;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service.Interface
{
    public interface IPlanReportService
    {
        List<PlanReport> list();
        PageLayUI<PlanReport> listPage(int page,int limit);
    }
}

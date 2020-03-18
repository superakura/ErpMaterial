using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Repository;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service
{
    public class PlanReportService : Interface.IPlanReportService
    {
        private IGenericRepository<PlanReport> _repo;
        public PlanReportService(IGenericRepository<PlanReport> repo)
        {
            this._repo = repo;
        }

        public bool Del(int id)
        {
            return _repo.Delete(_repo.GetEntity(w=>w.PlanReportId==id)).Result;
        }

        public PageLayUI<PlanReport> listPage(int page, int limit, Dictionary<string, object> whereList)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            var planReport = _repo.GetEntities(w=>w.PlanReportId>0);
            if (!string.IsNullOrEmpty(whereList["tbxMaterialName"].ToString()))
            {
                planReport = planReport.Where(w => w.MaterialCode.Contains(whereList["tbxMaterialName"].ToString()));
            }
            if (!string.IsNullOrEmpty(whereList["tbxMaterialNum"].ToString()))
            {
                planReport = planReport.Where(w => w.MaterialDesc.Contains(whereList["tbxMaterialNum"].ToString()));
            }

            PageLayUI<PlanReport> pageLayUI = new PageLayUI<PlanReport>();
            pageLayUI.count = planReport.Count();
            pageLayUI.data = planReport.OrderBy(o => o.PlanReportId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }

        public bool Update(PlanReport planReport)
        {
            if (planReport.PlanReportId != 0)
            {
                return _repo.Update(planReport).Result;
            }
            else
            {
                return _repo.Add(planReport).Result;
            }
        }
    }
}

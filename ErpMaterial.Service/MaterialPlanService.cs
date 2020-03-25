using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Repository;
using ErpMaterial.Service.ViewModel;
using LinqKit;

namespace ErpMaterial.Service
{
    public class MaterialPlanService : Interface.IMaterialPlanService
    {
        private IGenericRepository<ErpPlan> _repo;
        public MaterialPlanService(IGenericRepository<ErpPlan> repo)
        {
            this._repo = repo;
        }

        public ErpPlan GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public PageLayUI<ErpPlan> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            Expression<Func<ErpPlan, bool>> exp = w => 1 == 1;
            //if (!string.IsNullOrEmpty(conditions["searchLogMessage"].ToString()))
            //{
            //    exp = exp.And(w=>w.Message.Contains(conditions["searchLogMessage"].ToString()));
            //}
            //if (!string.IsNullOrEmpty(conditions["searchLogType"].ToString()))
            //{
            //    exp = exp.And(w => w.LogType == conditions["searchLogType"].ToString());
            //}
            //if (!string.IsNullOrEmpty(conditions["searchLogDateTime"].ToString()))
            //{
            //    exp = exp.And(w=>w.LogDate==Convert.ToDateTime(conditions["searchLogDateTime"].ToString()));
            //}

            PageLayUI<ErpPlan> pageLayUI = new PageLayUI<ErpPlan>();
            pageLayUI.count = _repo.GetList(exp).Count();
            pageLayUI.data = _repo.GetList(exp).OrderByDescending(o => o.ErpPlanId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }
    }
}

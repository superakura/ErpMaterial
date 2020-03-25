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
    public class MaterialPurchaseService : Interface.IMaterialPurchaseService
    {
        private IGenericRepository<ErpPurchase> _repo;
        public MaterialPurchaseService(IGenericRepository<ErpPurchase> repo)
        {
            this._repo = repo;
        }

        public ErpPurchase GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public PageLayUI<ErpPurchase> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            Expression<Func<ErpPurchase, bool>> exp = w => 1 == 1;
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

            PageLayUI<ErpPurchase> pageLayUI = new PageLayUI<ErpPurchase>();
            pageLayUI.count = _repo.GetList(exp).Count();
            pageLayUI.data = _repo.GetList(exp).OrderByDescending(o => o.ErpPurchaseId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }
    }
}

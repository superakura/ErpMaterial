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
    public class MaterialsOutService : Interface.IMaterialsOutService
    {
        private IGenericRepository<ErpDetail> _repo;
        public MaterialsOutService(IGenericRepository<ErpDetail> repo)
        {
            this._repo = repo;
        }

        public ErpDetail GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public PageLayUI<ErpDetail> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;
            var bwartList = new List<string> { " 201"," 301"," z03"};
            Expression<Func<ErpDetail, bool>> exp = w => bwartList.Contains(w.Bwart);
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

            PageLayUI<ErpDetail> pageLayUI = new PageLayUI<ErpDetail>();
            pageLayUI.count = _repo.GetList(exp).Count();
            pageLayUI.data = _repo.GetList(exp).OrderByDescending(o => o.CreateTime).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }
    }
}

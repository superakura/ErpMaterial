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
    public class SysLogService : Interface.ISysLogService
    {
        private IGenericRepository<SysLog> _repo;
        public SysLogService(IGenericRepository<SysLog> repo)
        {
            this._repo = repo;
        }

        public PageLayUI<SysLog> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            Expression<Func<SysLog, bool>> exp = w => 1 == 1;
            if (!string.IsNullOrEmpty(conditions["searchLogMessage"].ToString()))
            {
                exp = exp.And(w=>w.Message.Contains(conditions["searchLogMessage"].ToString()));
            }
            if (!string.IsNullOrEmpty(conditions["searchLogType"].ToString()))
            {
                exp = exp.And(w => w.LogType == conditions["searchLogType"].ToString());
            }
            if (!string.IsNullOrEmpty(conditions["searchLogDateTime"].ToString()))
            {
                exp = exp.And(w=>w.LogDate==Convert.ToDateTime(conditions["searchLogDateTime"].ToString()));
            }

            PageLayUI<SysLog> pageLayUI = new PageLayUI<SysLog>();
            pageLayUI.count = _repo.GetList(exp).Count();
            pageLayUI.data = _repo.GetList(exp).OrderByDescending(o => o.LogId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }
    }
}

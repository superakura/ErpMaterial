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
    public class MaterialStockService : Interface.IMaterialStockService
    {
        private IGenericRepository<ErpStorage> _repo;
        private IGenericRepository<SysUserKq> _repoUserKq;
        public MaterialStockService(IGenericRepository<ErpStorage> repo, IGenericRepository<SysUserKq> repoUserKq)
        {
            this._repo = repo;
            this._repoUserKq = repoUserKq;
        }

        public ErpStorage GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public PageLayUI<ViewErpStorage> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            Expression<Func<ErpStorage, bool>> exp = w => 1 == 1;
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
            var stock = _repo.GetList(exp);
            var userKq = _repoUserKq.GetList(w => 1 == 1);
            var result = from s in stock
                         join u in userKq on s.NameTextc.Trim() equals u.UserNum
                         select new ViewErpStorage{
                             ErpStorageId=s.ErpStorageId,
                             Werks=s.Werks,
                             Lgort=s.Lgort,
                             Lgnum=s.Lgnum,
                             Lgtyp=s.Lgtyp,
                             Lgpla=s.Lgpla,
                             Matnr=s.Matnr,
                             Maktx=s.Maktx,
                             Matkl=s.Matkl,
                             Verme=s.Verme,
                             Salk=s.Salk,
                             Msehl=s.Msehl,
                             Wdatu=s.Wdatu,
                             NameTextc=s.NameTextc,
                             Aging=s.Aging,
                             userDept=u.UserDept,
                             userName=u.UserName
                         };

            PageLayUI<ViewErpStorage> pageLayUI = new PageLayUI<ViewErpStorage>();
            pageLayUI.count = result.Count();
            pageLayUI.data = result.OrderByDescending(o => o.ErpStorageId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }
    }
}

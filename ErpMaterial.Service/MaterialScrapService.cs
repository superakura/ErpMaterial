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
    public class MaterialScrapService : Interface.IMaterialScrapService
    {
        private IGenericRepository<ErpDetail> _repo;
        private IGenericRepository<SysUserKq> _repoUserKq;
        public MaterialScrapService(IGenericRepository<ErpDetail> repo, IGenericRepository<SysUserKq> repoUserKq)
        {
            this._repo = repo;
            this._repoUserKq = repoUserKq;
        }

        public PageLayUI<ViewMaterialScrap> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;
            var bwartList = new List<string> { " 555" };
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
            var backErp = _repo.GetList(exp);
            var userKq = _repoUserKq.GetList(w => 1 == 1);

            var result = from s in backErp
                         join u in userKq on s.UserNum.Trim() equals u.UserNum
                         select new ViewMaterialScrap
                         {
                             ErpDetailId = s.ErpDetailId,
                             Mblnr=s.Mblnr,
                             Mjahr=s.Mjahr,
                             Bldat=s.Bldat,
                             Matnr=s.Matnr,
                             Maktx=s.Maktx,
                             LgortDesc=s.LgortDesc,
                             LifnrDesc=s.LifnrDesc,
                             Menge=s.Menge,
                             Meins=s.Meins,
                             Rsnum=s.Rsnum,
                             Ktext=s.Ktext,
                             Pspel=s.Pspel,
                             GdNum=s.GdNum,
                             Zthdw=s.Zthdw,
                             UserNum=s.UserNum,
                             CreateTime=s.CreateTime,

                             userDept = u.UserDept,
                             userName = u.UserName
                         };

            PageLayUI<ViewMaterialScrap> pageLayUI = new PageLayUI<ViewMaterialScrap>();
            pageLayUI.count = result.Count();
            pageLayUI.data = result.OrderByDescending(o => o.CreateTime).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }
    }
}

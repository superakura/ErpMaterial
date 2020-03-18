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
    public class SysNoticeService : Interface.ISysNoticeService
    {
        private IGenericRepository<SysNoticeInfo> _repo;
        public SysNoticeService(IGenericRepository<SysNoticeInfo> repo)
        {
            this._repo = repo;
        }

        public bool Del(int id)
        {
            var info = _repo.GetEntity(w => w.NoticeId == id);
            return _repo.Delete(info).Result;
        }

        public SysNoticeInfo GetOne(int id)
        {
            Expression<Func<SysNoticeInfo, bool>> exp = w => w.NoticeId==id;
            return _repo.GetEntity(exp);
        }

        public PageLayUI<SysNoticeInfo> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            Expression<Func<SysNoticeInfo, bool>> exp = w => 1 == 1;
            if (!string.IsNullOrEmpty(conditions["searchNoticeTitle"].ToString()))
            {
                exp = exp.And(w=>w.NoticeTitle.Contains(conditions["searchNoticeTitle"].ToString()));
            }
            if (!string.IsNullOrEmpty(conditions["searchNoticeType"].ToString()))
            {
                exp = exp.And(w=>w.ContentType== conditions["searchNoticeType"].ToString());
            }

            PageLayUI<SysNoticeInfo> pageLayUI = new PageLayUI<SysNoticeInfo>();
            pageLayUI.count = _repo.GetList(exp).Count();
            pageLayUI.data = _repo.GetList(exp).OrderBy(o => o.NoticeId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }

        public bool Update(SysNoticeInfo info)
        {
            if (info.NoticeId != 0)
            {
                return _repo.Update(info).Result;
            }
            else
            {
                return _repo.Add(info).Result;
            }
        }
    }
}

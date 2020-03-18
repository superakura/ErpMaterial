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
    public class SysRoleService : Interface.ISysRoleService
    {
        private IGenericRepository<SysRoleInfo> _repo;
        public SysRoleService(IGenericRepository<SysRoleInfo> repo)
        {
            this._repo = repo;
        }

        public bool Del(int id)
        {
            var info = _repo.GetEntity(w => w.RoleId == id);
            return _repo.Delete(info).Result;
        }

        public List<SysRoleInfo> GetAllList(string idList)
        {
            var idListStr = idList.Split(',');
            var idListInt = new List<int>();
            foreach (var item in idListStr)
            {
                idListInt.Add(Convert.ToInt32(item));
            }
            return _repo.GetEntities(w => idListInt.Contains(w.RoleId)).ToList();
        }

        public SysRoleInfo GetOne(int id)
        {
            return _repo.GetEntity(w => w.RoleId == id);
        }

        public PageLayUI<SysRoleInfo> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            Expression<Func<SysRoleInfo, bool>> exp = w => 1 == 1;
            if (!string.IsNullOrEmpty(conditions["searchRoleName"].ToString()))
            {
                exp = exp.And(w =>w.RoleName.Contains(conditions["searchRoleName"].ToString()));
            }

            PageLayUI<SysRoleInfo> pageLayUI = new PageLayUI<SysRoleInfo>();
            pageLayUI.count = _repo.GetList(exp).Count();
            pageLayUI.data = _repo.GetList(exp).OrderBy(o => o.RoleId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }

        public bool Update(SysRoleInfo info)
        {
            if (info.RoleId != 0)
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

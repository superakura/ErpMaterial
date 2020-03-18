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
    public class SysRoleAuthService : Interface.ISysRoleAuthService
    {
        private IGenericRepository<SysRoleAuthority> _repo;
        private IGenericRepository<SysAuthorityInfo> _repoAuth;
        public SysRoleAuthService(IGenericRepository<SysRoleAuthority> repo, IGenericRepository<SysAuthorityInfo> repoAuth)
        {
            this._repo = repo;
            this._repoAuth = repoAuth;
        }

        public bool Del(int id)
        {
            var info = _repo.GetEntity(w => w.RoleAuthorityId == id);
            return _repo.Delete(info).Result;
        }

        public bool CheckAuth(int authID,int roleID)
        {
            return _repo.GetEntity(w => w.RoleId == roleID && w.AuthorityId == authID)==null? true:false;
        }

        public PageLayUI<RoleAuty> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            int.TryParse(conditions["roleID"].ToString(), out int roleid);
            var auth = _repoAuth.GetList(w => w.AuthorityId > 0);
            var roleAuth = _repo.GetList(w => w.RoleId == roleid);

            var authList = from a in auth
                           join r in roleAuth on a.AuthorityId equals r.AuthorityId
                           select new RoleAuty
                           {
                               authorityID = a.AuthorityId,
                               roleAuthorityID = r.RoleAuthorityId,
                               authorityDescribe = a.AuthorityDescribe,
                               authorityName = a.AuthorityName,
                               authorityType = a.AuthorityType,
                               conflictCode = a.ConflictCode
                           };

            PageLayUI<RoleAuty> pageLayUI = new PageLayUI<RoleAuty>();
            pageLayUI.count = authList.Count();
            pageLayUI.data = authList.OrderByDescending(o => o.roleAuthorityID).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }

        public bool Update(SysRoleAuthority info)
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

        public int[] GetAuthIdListByRoleID(int[] roldID)
        {
            return _repo.GetEntities(w => roldID.Contains(w.RoleId)).Select(s => s.AuthorityId).Distinct().ToArray();
        }

        public string GetAuthIdListByRoleID(string roleIdList)
        {
            var roleIdArray = roleIdList.Contains(",")? roleIdList.Split(',') : new string[] { roleIdList};
            List<int> roleIdListInt = new List<int>();
            foreach (var item in roleIdArray)
            {
                roleIdListInt.Add(Convert.ToInt32(item));
            }
            var roleIdArrayInt = roleIdListInt.ToArray();
            var authIdList= _repo.GetEntities(w => roleIdArrayInt.Contains(w.RoleId)).Select(s => s.AuthorityId).Distinct().ToArray();
            var info = "";
            foreach (var item in authIdList)
            {
                info += item.ToString()+",";
            }
            return info.Remove(info.Length - 1, 1);
        }
    }
}

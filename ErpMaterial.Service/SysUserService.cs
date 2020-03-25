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
    public class SysUserService : Interface.ISysUserService
    {
        private IGenericRepository<SysUserInfo> _repoUser;
        private IGenericRepository<SysDeptInfo> _repoDept;
        public SysUserService(IGenericRepository<SysUserInfo> repoUser
            ,IGenericRepository<SysDeptInfo> repoDept)
        {
            this._repoUser = repoUser;
            this._repoDept = repoDept;
        }

        public bool Del(int id)
        {
            var info = _repoUser.GetEntity(w => w.UserId == id);
            return _repoUser.Delete(info).Result;
        }

        public UserInfo GetOne(int id)
        {
            var user = _repoUser.GetList(w => w.UserId == id);
            var dept = _repoDept.GetList(w => w.DeptId > 0);
            var userInfo = from u in user
                           join d in dept on u.UserDeptId equals d.DeptId
                           select new UserInfo
                           {
                               UserDeptName=d.DeptName,
                               UserAuthorityList=u.UserAuthorityList,
                               UserDeptCtrlList=u.UserDeptCtrlList,
                               UserDeptCtrlChildList=u.UserDeptCtrlChildList,
                               UserRoleList=u.UserRoleList,
                               UserDeptId=u.UserDeptId,
                               UserDuty=u.UserDuty,
                               UserEmail=u.UserEmail,
                               UserId=u.UserId,
                               UserMobile=u.UserMobile,
                               UserPhone=u.UserPhone,
                               UserName=u.UserName,
                               UserNum=u.UserNum,
                               UserPwd=u.UserPwd,
                               UserRemark=u.UserRemark,
                               UserState=u.UserState
                           };
            return userInfo.FirstOrDefault();
        }

        public SysUserInfo GetUserInfoByNum(string userNum)
        {
            return _repoUser.GetEntity(w => w.UserNum == userNum);
        }

        public PageLayUI<UserInfo> listPage(int page, int limit, Dictionary<string, object> conditions)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            Expression<Func<SysUserInfo, bool>> exp = w => 1 == 1;
            if (!string.IsNullOrEmpty(conditions["searchUserName"].ToString()))
            {
                exp = exp.And(w => w.UserName.Contains(conditions["searchUserName"].ToString()));
            }
            //var deptList = conditions["searchUserName"].ToString().Split(',');
            //exp = exp.And(w => deptList.Contains(w.UserDeptId.ToString()));

            Expression<Func<SysDeptInfo, bool>> expDept = w => 1 == 1;
            if (!string.IsNullOrEmpty(conditions["selectDeptID"].ToString()))
            {
                expDept = expDept.And(w =>w.DeptId==Convert.ToInt32(conditions["selectDeptID"].ToString()));
            }
            var user = _repoUser.GetList(exp);
            var dept = _repoDept.GetList(expDept);
            var userInfo = from u in user
                           join d in dept on u.UserDeptId equals d.DeptId
                           select new UserInfo
                           {
                               UserDeptName = d.DeptName,
                               UserAuthorityList = u.UserAuthorityList,
                               UserDeptCtrlList = u.UserDeptCtrlList,
                               UserDeptId = u.UserDeptId,
                               UserDuty = u.UserDuty,
                               UserEmail = u.UserEmail,
                               UserId = u.UserId,
                               UserMobile = u.UserMobile,
                               UserPhone = u.UserPhone,
                               UserName = u.UserName,
                               UserNum = u.UserNum,
                               UserPwd = u.UserPwd,
                               UserRemark = u.UserRemark,
                               UserState = u.UserState
                           };

            PageLayUI<UserInfo> pageLayUI = new PageLayUI<UserInfo>();
            pageLayUI.count = userInfo.Count();
            pageLayUI.data = userInfo.OrderBy(o => o.UserId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }

        public bool Update(SysUserInfo info)
        {
            if (info.UserId != 0)
            {
                return _repoUser.Update(info).Result;
            }
            else
            {
                return _repoUser.Add(info).Result;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErpMaterial.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace ErpMaterial.Web.Controllers
{
    //[Authorize]
    public class SysUserController : Controller
    {
        private ISysUserService _serviceSysUser;
        private ISysRoleAuthService _serviceSysRoleAuth;
        private ISysRoleService _serviceSysRole;
        public SysUserController(ISysUserService serviceSysUser
            ,ISysRoleAuthService serviceSysRoleAuth
            , ISysRoleService serviceSysRole
            )
        {
            _serviceSysUser = serviceSysUser;
            _serviceSysRoleAuth = serviceSysRoleAuth;
            _serviceSysRole = serviceSysRole;
        }
        public IActionResult Index()
        {

            return View();
        }

        public string Update()
        {
            try
            {
                int.TryParse(Request.Form["formInfoID"], out int id);
                int.TryParse(Request.Form["userDeptID"], out int idDept);

                var info = new ErpMaterial.Models.SysUserInfo();
                info.UserId = id;
                info.UserDeptId = idDept;
                info.UserName = Request.Form["tbxUserName"];
                info.UserNum= Request.Form["tbxUserNum"];
                info.UserDuty= Request.Form["tbxUserDuty"];
                info.UserMobile= Request.Form["tbxUserMobile"];
                info.UserPhone= Request.Form["tbxUserPhone"];
                info.UserEmail= Request.Form["tbxUserEmail"];
                info.UserRemark= Request.Form["tbxUserRemark"];
                info.UserState = "正常";
                info.UserDeptCtrlList= Request.Form["userDeptList"];
                info.UserDeptCtrlChildList = Request.Form["userDeptListChild"];
                info.UserRoleList = Request.Form["roleList"].ToString();
                info.UserAuthorityList = _serviceSysRoleAuth.GetAuthIdListByRoleID(Request.Form["roleList"].ToString());
                return _serviceSysUser.Update(info) ?"ok":"error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public JsonResult ListPage()
        {
            var page = 0;
            int.TryParse(Request.Query["page"], out page);
            var limit = 0;
            int.TryParse(Request.Query["limit"], out limit);

            var searchUserName = Request.Query["searchUserName"].ToString();
            var searchUserNum = Request.Query["searchUserNum"].ToString();
            var selectDeptID = Request.Query["selectDeptID"].ToString();

            Dictionary<string, object> conditions = new Dictionary<string, object>();
            conditions.Add("searchUserName", searchUserName);
            conditions.Add("searchUserNum", searchUserNum);
            conditions.Add("selectDeptID", selectDeptID);

            return Json(_serviceSysUser.listPage(page, limit, conditions));
        }

        public JsonResult GetOne()
        {
            try
            {
                int.TryParse(Request.Form["id"], out int id);
                
                var userInfo = _serviceSysUser.GetOne(id);
                var userRole = _serviceSysRole.GetAllList(userInfo.UserRoleList);

                return Json(new {userInfo=userInfo,userRole=userRole });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
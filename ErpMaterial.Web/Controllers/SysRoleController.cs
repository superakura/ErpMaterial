using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErpMaterial.Service.Interface;

namespace ErpMaterial.Web.Controllers
{
    public class SysRoleController : Controller
    {
        private ISysRoleService _serviceSysRole;
        private ISysRoleAuthService _serviceSysRoleAuth;
        public SysRoleController(ISysRoleService serviceSysRole, ISysRoleAuthService serviceSysRoleAuth)
        {
            _serviceSysRole = serviceSysRole;
            _serviceSysRoleAuth = serviceSysRoleAuth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public string Update()
        {
            try
            {
                int.TryParse(Request.Form["formInfoID"], out int id);

                var roleName = Request.Form["tbxRoleName"];
                var roleDesc = Request.Form["tbxRoleDescribe"];

                var info = new ErpMaterial.Models.SysRoleInfo();
                info.RoleId = id;
                info.RoleName = roleName;
                info.RoleDescribe = roleDesc;

                return _serviceSysRole.Update(info) ? "ok" : "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string Del()
        {
            try
            {

                int.TryParse(Request.Form["id"], out int id);

                return _serviceSysRole.Del(id) ? "ok" : "error";
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

            var searchRoleName = Request.Query["searchRoleName"].ToString();

            Dictionary<string, object> conditions = new Dictionary<string, object>();
            conditions.Add("searchRoleName", searchRoleName);

            return Json(_serviceSysRole.listPage(page, limit, conditions));
        }

        public JsonResult GetOne()
        {
            try
            {
                int.TryParse(Request.Form["id"], out int id);

                return Json(_serviceSysRole.GetOne(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public string AddAuth()
        {
            try
            {
                int.TryParse(Request.Form["AuthID"], out int authID);//权限ID
                int.TryParse(Request.Form["RoleID"], out int roleID);//角色ID
                var info = new ErpMaterial.Models.SysRoleAuthority();
                info.RoleId = roleID;
                info.AuthorityId = authID;

                if (_serviceSysRoleAuth.CheckAuth(authID, roleID))
                {
                    return _serviceSysRoleAuth.Update(info) == true ? "ok" : "error";
                }
                else
                {
                    return "该权限已经存在，不能重复添加！";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public JsonResult ListPageRole()
        {
            var page = 0;
            int.TryParse(Request.Query["page"], out page);
            var limit = 0;
            int.TryParse(Request.Query["limit"], out limit);

            var roleID = Request.Query["roleID"].ToString();

            Dictionary<string, object> conditions = new Dictionary<string, object>();
            conditions.Add("roleID", roleID);

            return Json(_serviceSysRoleAuth.listPage(page, limit, conditions));
        }

        public string DelRoleAuth()
        {
            try
            {
                int.TryParse(Request.Form["roleAuthID"], out int roleAuthID);

                return _serviceSysRoleAuth.Del(roleAuthID) == true ? "ok" : "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpMaterial.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ErpMaterial.Web.Controllers
{
    //SysAuthority
    public class SysAuthorityController : Controller
    {
        private ISysAuthorityService _serviceSysAuthority;
        public SysAuthorityController(ISysAuthorityService serviceSysAuthority)
        {
            _serviceSysAuthority = serviceSysAuthority;
        }

        public IActionResult IndexAuth()
        {
            return View();
        }

        [HttpPost]
        public string Update()
        {
            try
            {
                int.TryParse(Request.Form["formInfoID"], out int id);

                var authName = Request.Form["tbxAuthorityName"];
                var authDesc = Request.Form["tbxAuthorityDescribe"];
                var authType = Request.Form["ddlAuthorityType"];
                int.TryParse(Request.Form["tbxConflictCode"],out int conflictCode);

                var menuUrl = Request.Form["tbxMenuUrl"];
                var menuIcon = Request.Form["tbxMenuIcon"];
                var menuName = Request.Form["tbxMenuName"];
                int.TryParse(Request.Form["tbxMenuFatherID"],out int menuFatherId);
                int.TryParse(Request.Form["tbxMenuOrder"],out int menuOrder);

                var info = new ErpMaterial.Models.SysAuthorityInfo();
                info.AuthorityId = id;
                info.AuthorityName = authName;
                info.AuthorityDescribe = authDesc;
                info.AuthorityType = authType;
                info.ConflictCode = conflictCode;

                info.MenuName = menuName;
                info.MenuOrder = menuOrder;
                info.MenuIcon = menuIcon;
                info.MenuUrl = menuUrl;
                info.MenuFatherId = menuFatherId;

                return _serviceSysAuthority.Update(info) ? "ok" : "error";
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

                return _serviceSysAuthority.Del(id) ? "ok" : "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public JsonResult ListPageAuth()
        {
            var page = 0;
            int.TryParse(Request.Query["page"], out page);
            var limit = 0;
            int.TryParse(Request.Query["limit"], out limit);

            var searchAuthorityName = Request.Query["searchAuthorityName"].ToString();
            var searchAuthorityType = Request.Query["searchAuthorityType"].ToString();

            Dictionary<string, object> whereList = new Dictionary<string, object>();
            whereList.Add("searchAuthorityName", searchAuthorityName);
            whereList.Add("searchAuthorityType", searchAuthorityType);

            return Json(_serviceSysAuthority.listPage(page, limit, whereList));
        }

        public JsonResult MenuList()
        {
            try
            {
                var list = _serviceSysAuthority.memuList();
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
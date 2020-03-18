using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErpMaterial.Service.Interface;

namespace ErpMaterial.Web.Controllers
{
    public class SysNoticeController : Controller
    {
        private ISysNoticeService _serviceSysNotice;
        public SysNoticeController(ISysNoticeService serviceSysNotice)
        {
            _serviceSysNotice = serviceSysNotice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Update()
        {
            try
            {
                int.TryParse(Request.Form["formInfoID"], out int id);

                var title = Request.Form["tbxNoticeTitle"];
                var content = Request.Form["tbxNoticeContent"];
                var type = Request.Form["ddlNoticeType"];

                var info = new ErpMaterial.Models.SysNoticeInfo();
                info.NoticeId = id;
                info.NoticeTitle = title;
                info.ContentInfo = content;
                info.ContentType = type;
                info.ContentCount = content.Count();
                info.InsertDate = DateTime.Now;
                info.InsertPersonNum = "admin";

                return _serviceSysNotice.Update(info) ? "ok" : "error";
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

                return _serviceSysNotice.Del(id) ? "ok" : "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public JsonResult ListPage()
        {
            int.TryParse(Request.Query["page"], out int page);
            int.TryParse(Request.Query["limit"], out int limit);

            Dictionary<string, object> conditions = new Dictionary<string, object>();
            conditions.Add("searchNoticeTitle", Request.Query["searchNoticeTitle"].ToString());
            conditions.Add("searchNoticeType", Request.Query["searchNoticeType"].ToString());

            return Json(_serviceSysNotice.listPage(page, limit, conditions));
        }
    }
}
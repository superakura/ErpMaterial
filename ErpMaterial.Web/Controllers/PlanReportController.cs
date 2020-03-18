using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErpMaterial.Service;
using ErpMaterial.Service.Interface;
using ErpMaterial.Service.ViewModel;
using ErpMaterial.Models;

namespace ErpMaterial.Web.Controllers
{
    public class PlanReportController : Controller
    {
        //PlanReport

        private IPlanReportService _servicePlanReport;
        public PlanReportController(IPlanReportService servicePlanReport)
        {
            _servicePlanReport = servicePlanReport;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 向数据库中插入100条测试数据
        /// </summary>
        /// <returns></returns>
        public JsonResult List()
        {
            var skip = Request.Query["page"] == "1" ? 0 : (Convert.ToInt32(Request.Query["page"]) - 1) * Convert.ToInt32(Request.Query["limit"]);
            var take = Convert.ToInt32(Request.Query["limit"]);

            List<PlanReport> planReport = new List<PlanReport>();
            for (int i = 1; i <= 100; i++)
            {
                planReport.Add(new PlanReport
                {
                    PlanReportId = i
                    ,
                    MaterialCode = ("编码" + i)
                    ,
                    MaterialDesc = "描述" + i
                    ,
                    MaterialCount = i
                    ,
                    PlanReportDept = "部门 " + i
                    ,
                    PlanReportPerson = "人员 " + i
                    ,
                    MaterialAge = "账龄" + i
                });
            }
            PageLayUI<PlanReport> pageLayUI = new PageLayUI<PlanReport>();
            pageLayUI.count = planReport.Count;
            pageLayUI.data = planReport.Skip(skip).Take(take).ToList();

            return Json(pageLayUI);
        }

        public JsonResult ListPage()
        {
            var page = 0;
            int.TryParse(Request.Query["page"], out page);
            var limit = 0;
            int.TryParse(Request.Query["limit"], out limit);

            var tbxMaterialName = Request.Query["tbxMaterialName"].ToString();
            var tbxMaterialNum = Request.Query["tbxMaterialNum"].ToString();
            
            Dictionary<string, object> whereList = new Dictionary<string, object>();
            whereList.Add("tbxMaterialName", tbxMaterialName);
            whereList.Add("tbxMaterialNum", tbxMaterialNum);

            return Json(_servicePlanReport.listPage(page, limit,whereList));
        }

        [HttpPost]
        public string Update()
        {
            try
            {
                int.TryParse(Request.Form["formInfoID"], out int id);

                var userName = Request.Form["userName"];
                var sex = Request.Form["sex"];
                var desc = Request.Form["desc"];

                var info = new ErpMaterial.Models.PlanReport();
                info.MaterialAge = sex;
                info.MaterialDesc = desc;
                info.MaterialCode = userName;
                info.PlanReportId = id;
                
                return _servicePlanReport.Update(info)?"ok":"error";
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

                return _servicePlanReport.Del(id) ? "ok" : "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
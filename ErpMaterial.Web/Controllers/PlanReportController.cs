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

        public JsonResult List()
        {
            var skip = Request.Query["page"]=="1"?0: (Convert.ToInt32(Request.Query["page"])-1)* Convert.ToInt32(Request.Query["limit"]);
            var take = Convert.ToInt32(Request.Query["limit"]);

            List<PlanReport> planReport = new List<PlanReport>();
            for (int i = 1; i <= 100; i++)
            {
                planReport.Add(new PlanReport { 
                    PlanReportId = i
                    ,MaterialCode = ("编码" + i)
                    , MaterialDesc = "描述" + i 
                    , MaterialCount = i 
                    , PlanReportDept = "部门 "+i 
                    , PlanReportPerson = "人员 "+i 
                    , MaterialAge = "账龄"+i 
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

            return Json(_servicePlanReport.listPage(page, limit));
        }
    }
}
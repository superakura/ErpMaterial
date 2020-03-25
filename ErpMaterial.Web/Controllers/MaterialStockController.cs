using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErpMaterial.Service.Interface;

namespace ErpMaterial.Web.Controllers
{
    public class MaterialStockController : Controller
    {
        private IMaterialStockService _serviceMaterialStock;
        public MaterialStockController(IMaterialStockService serviceMaterialStock)
        {
            _serviceMaterialStock = serviceMaterialStock;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListPage()
        {
            var page = 0;
            int.TryParse(Request.Query["page"], out page);
            var limit = 0;
            int.TryParse(Request.Query["limit"], out limit);

            //var searchLogType = Request.Query["searchLogType"].ToString();
            //var searchLogMessage = Request.Query["searchLogMessage"].ToString();
            //var searchLogDateTime = Request.Query["searchLogDateTime"].ToString();

            Dictionary<string, object> conditions = new Dictionary<string, object>();
            //conditions.Add("searchLogType", searchLogType);
            //conditions.Add("searchLogMessage", searchLogMessage);
            //conditions.Add("searchLogDateTime", searchLogDateTime);

            return Json(_serviceMaterialStock.listPage(page, limit, conditions));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErpMaterial.Service.Interface;

namespace ErpMaterial.Web.Controllers
{
    public class SysDeptController : Controller
    {
        private ISysDeptService _serviceSysDept;
        public SysDeptController(ISysDeptService serviceSysDept)
        {
            _serviceSysDept = serviceSysDept;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListAll()
        {
            try
            {
                var selectDeptList = Request.Form["selectDeptList"].ToString();
                return Json(_serviceSysDept.ListAll(selectDeptList));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public string Update()
        {
            try
            {
                int.TryParse(Request.Form["formInfoID"], out int id);
                int.TryParse(Request.Form["tbxDeptOrder"], out int deptOrder);
                int.TryParse(Request.Form["tbxDeptFatherID"], out int deptFatherID);
                int.TryParse(Request.Form["tbxIsOpen"], out int isOpen);

                var deptName = Request.Form["tbxDeptName"];
                var deptRemark = Request.Form["tbxDeptRemark"];
                var deptState = Request.Form["ddlDeptState"];

                var info = new ErpMaterial.Models.SysDeptInfo();
                info.DeptId = id;
                info.DeptOrder = deptOrder;
                info.DeptFatherId = deptFatherID;
                info.DeptRemark = deptRemark;
                info.DeptName = deptName;
                info.DeptState = deptState;
                info.IsOpen = (byte)isOpen;
                info.DeptCreateDate = DateTime.Now;

                return _serviceSysDept.Update(info) ? "ok" : "error";
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

                return _serviceSysDept.Del(id) ? "ok" : "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public JsonResult GetOne()
        {
            try
            {
                int.TryParse(Request.Form["id"], out int id);
                return Json(_serviceSysDept.GetOne(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
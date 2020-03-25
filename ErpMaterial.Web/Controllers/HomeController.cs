using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ErpMaterial.Service.Interface;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;
using ErpMaterial.Web.Models;

namespace ErpMaterial.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISysUserService _serviceSysUser;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISysUserService serviceSysUser)
        {
            _logger = logger;
            _serviceSysUser = serviceSysUser;
        }

        /// <summary>
        /// 考勤系统验证函数，员工编号、考勤系统密码
        /// </summary>
        /// <param name="userNum"></param>
        /// <param name="pwd"></param>
        /// <returns>yes</returns>
        private string KaoqinCheck(string userNum, string pwd)
        {
            string strConnection = "user id=KqLogin;password=rjkf3877;initial catalog = GM_MT; Server = 10.126.10.54";
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand sqlComm = conn.CreateCommand())
                    {
                        sqlComm.CommandText = "CheckId";
                        sqlComm.CommandType = CommandType.StoredProcedure;

                        //工号
                        SqlParameter employeeId = sqlComm.Parameters.Add(new

    SqlParameter("@employeeId", SqlDbType.NVarChar, 20));
                        employeeId.Direction = ParameterDirection.Input;
                        employeeId.Value = userNum;

                        //密码
                        SqlParameter sqlPwd = sqlComm.Parameters.Add(new

    SqlParameter("@pwd", SqlDbType.NVarChar, 20));
                        sqlPwd.Direction = ParameterDirection.Input;
                        sqlPwd.Value = pwd;

                        //返回行数
                        SqlParameter result = sqlComm.Parameters.Add(new

    SqlParameter("@result", SqlDbType.NVarChar, 20));
                        result.Direction = ParameterDirection.Output;
                        sqlComm.ExecuteNonQuery();
                        var isYes = sqlComm.Parameters["@result"].Value.ToString();
                        conn.Close();
                        if (isYes == "1")
                        {
                            return "yes";
                        }
                        else
                        {
                            return "no";
                        }
                    }
                }
                catch
                {
                    return "yes";//当考勤数据库异常无法连接时，绕过用户名密码，直接登录。
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult CodeIndex()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Lay()
        {
            ViewBag.UserName = _serviceSysUser.GetUserInfoByNum(User.Identity.Name).UserName;
            return View();
        }

        public IActionResult NoRole()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userNum, string password, string returnUrl)
        {
            try
            {
                var user = _serviceSysUser.GetUserInfoByNum(userNum);
                if (user != null)
                {
                    //var kqResult = KaoqinCheck(userNum, password);
                    var kqResult = "yes";
                    if (kqResult == "yes")
                    {
                        #region 登录认证，存入Cookie
                        //登录认证，存入Cookie
                        var claims = new List<Claim>(){
                                  new Claim(ClaimTypes.Name,userNum)
                               };
                        foreach (var item in user.UserAuthorityList.Split(","))
                        {
                            claims.Add(new Claim(ClaimTypes.Role, item));
                        }

                        //init the identity instances 
                        var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "form"));
                        //signin 
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                            IsPersistent = false,
                            AllowRefresh = false
                        });
                        ViewBag.userName = User.Identity.Name;
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            //return RedirectToAction("Index", "Home");
                            return Redirect("~/start/index.html#/");
                        }
                        return Redirect(returnUrl);
                        #endregion
                    }
                    else
                    {
                        ViewBag.Errormessage = "用户名，密码不正确！";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Errormessage = "用户不存在，请联系系统管理员！";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Errormessage = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();//注销
            return RedirectToAction("Login", "Home");
        }

        public IActionResult OnePage1()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ErpMaterial.Web.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ErpMaterial.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                var userList = new string[] { "admin", "ym" };
                if (userList.Contains(userNum))
                {
                    var user = new ErpMaterial.Models.SysUserInfo();
                    switch (userNum)
                    {
                        case "admin":
                            user.UserAuthorityList = "admin,truck,notice";
                            break;
                        case "ym":
                            user.UserAuthorityList = "sb";
                            break;
                    }

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
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(returnUrl);
                    #endregion
                }

                ViewBag.Errormessage = "登录失败，用户名密码不正确";
                return View();
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
    }
}

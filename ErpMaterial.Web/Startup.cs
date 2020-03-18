using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ErpMaterial.Repository;
using ErpMaterial.Models;
using ErpMaterial.Service;
using ErpMaterial.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace ErpMaterial.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ErpMaterialContext>(options => { options.UseSqlServer("Data Source=.;Initial Catalog=ErpMaterial;Integrated Security=True", b => b.UseRowNumberForPaging()); });

            #region 依赖注入
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPlanReportService, PlanReportService>();
            services.AddTransient<ISysAuthorityService, SysAuthService>();
            services.AddTransient<ISysRoleService, SysRoleService>();
            services.AddTransient<ISysLogService, SysLogService>();
            services.AddTransient<ISysDeptService,SysDeptService>();
            services.AddTransient<ISysNoticeService,SysNoticeService>();
            services.AddTransient<ISysUserService,SysUserService>();
            services.AddTransient<ISysRoleAuthService,SysRoleAuthService>();
            #endregion

            #region 添加cookie认证服务

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Home/Login/";
                options.LogoutPath = new PathString("/login");
                options.AccessDeniedPath = new PathString("/home/NoRole");
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #endregion 

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud
{
    public class Startup
    {
        private IWebHostEnvironment _hostEnvironment;
        private string cnStr;
        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            cnStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={_hostEnvironment.ContentRootPath}\\App_Data\\dbEmp.mdf; Integrated Security=True;Trusted_Connection=True;";
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 注入MVC服務、DbContext
            services.AddMvc();
            services.AddDbContext<EmpDbContext>(options => options.UseSqlServer(cnStr));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 加入Middleware
            app.UseRouting();
            app.UseStaticFiles();

            // 建立預設路由
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}");
            });
        }
    }
}

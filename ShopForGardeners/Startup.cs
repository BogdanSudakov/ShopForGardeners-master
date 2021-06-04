using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopForGardeners.Data;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Mocks;
using Microsoft.EntityFrameworkCore;
using ShopForGardeners.Data.Repository;
using ShopForGardeners.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ShopForGardeners
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        public Startup(IHostEnvironment hostenv)
        {
            //get string of file.json
            _confstring = new ConfigurationBuilder().SetBasePath(hostenv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //nuget sqlserver
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddDbContext<AppDBContent>(op => op.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));          
            services.AddTransient<IItems, ItemRepository>();
            services.AddTransient<IOrders, OrdersRepository>();
            services.AddTransient<IItemsCategory, CategoryRepository>();
            services.AddTransient<IAccount,AccountRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //������ ����������
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();    // ��������������
            app.UseAuthorization();     // �����������
            //��������� ���� ��� �� ���������� ���
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "{controller}/{action}/{category?}", defaults: new { Controller = "Items", action = "List" });
            });





            /* using (var scope = app.ApplicationServices.CreateScope())
             {
                 AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();

                 DBobjects.Initial(content);
             }//*/


        }
    }
}

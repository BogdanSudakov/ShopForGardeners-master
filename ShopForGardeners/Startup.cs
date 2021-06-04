using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopForGardeners.Data;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using ShopForGardeners.Data.Repository;

namespace ShopForGardeners
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        public Startup(IHostEnvironment hostenv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostenv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //nuget sqlserver
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddDbContext<AppDBContent>(op => op.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IItems, ItemRepository>();
            services.AddTransient<IOrders, OrdersRepository>();
            services.AddTransient<IItemsCategory, CategoryRepository>();
            services.AddTransient<IAccount, AccountRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
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

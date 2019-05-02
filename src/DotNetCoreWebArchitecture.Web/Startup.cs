using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreWebArchitecture.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<Data.DatabaseContext>(opt => opt.UseInMemoryDatabase("Store"));
            services.AddTransient<Core.Contracts.IOrderService, Service.OrderService>();
            services.AddTransient<Core.Contracts.IWidgetService, Service.WidgetService>();
            services.AddTransient<Core.Contracts.ILogService, Service.LogService>();
            services.AddTransient<Core.Contracts.IOrderRepository, Data.OrderRepository>();
            services.AddTransient<Core.Contracts.IWidgetRepository, Data.WidgetRepository>();
            services.AddTransient<Core.Contracts.ILogRepository, Data.LogRepository>();
            services.AddMvc(opt => opt.Filters.Add(typeof(Filters.AuditAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var db = app.ApplicationServices.GetService<Data.DatabaseContext>();
            TestDataSeeder.Seed(db, 20);
        }
    }
}
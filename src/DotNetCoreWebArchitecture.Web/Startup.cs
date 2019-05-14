using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

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

            //Database
            services.AddDbContext<Data.DatabaseContext>(opt => opt.UseInMemoryDatabase("StoreDatabase"));

            //Business services & data repositories
            services.AddTransient<Core.Contracts.IOrderService, Service.OrderService>();
            services.AddTransient<Core.Contracts.IWidgetService, Service.WidgetService>();
            services.AddTransient<Core.Contracts.ILogService, Service.LogService>();
            services.AddTransient<Core.Contracts.IOrderRepository, Data.OrderRepository>();
            services.AddTransient<Core.Contracts.IWidgetRepository, Data.WidgetRepository>();
            services.AddTransient<Core.Contracts.ILogRepository, Data.LogRepository>();

            //MVC & Auditing
            services.AddMvc(opt => opt.Filters.Add(typeof(Filters.AuditAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Automapper
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            ////Authentication
            //services.AddIdentity<Data.ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<Data.DatabaseContext>()
            //    .AddDefaultTokenProviders();

            ////Google Authentication
            //services.AddAuthentication().AddGoogle(o =>
            //{
            //    // Configure your auth keys, usually stored in Config or User Secrets
            //    o.ClientId = "<yourid>";
            //    o.ClientSecret = "<yoursecret>";
            //    o.Scope.Add("https://www.googleapis.com/auth/plus.me");
            //    o.ClaimActions.MapJsonKey(ClaimTypes.Gender, "gender");
            //    o.SaveTokens = true;
            //    o.Events.OnCreatingTicket = ctx =>
            //    {
            //        var tokens = ctx.Properties.GetTokens() as List<AuthenticationToken>;
            //        tokens.Add(new AuthenticationToken() { Name = "TicketCreated", Value = DateTime.UtcNow.ToString() });
            //        ctx.Properties.StoreTokens(tokens);
            //        return Task.CompletedTask;
            //    };
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var logService = app.ApplicationServices.GetService<Core.Contracts.ILogService>();
                logService.LogException(exception);

                //var result = JsonConvert.SerializeObject(new { error = exception });
                //context.Response.ContentType = "application/json";
                //await context.Response.WriteAsync(result);
            }));

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseAuthentication();
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
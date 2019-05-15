using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Web
{
    public static class StartupExtensions
    {
        public static void SetupDatabase(this IServiceCollection services)
        {
            services.AddDbContext<Data.DatabaseContext>
                (opt => opt.UseInMemoryDatabase("StoreDatabase"));
        }

        public static void SetupMVC(this IServiceCollection services)
        {
            services.AddMvc(opt => opt.Filters.Add(typeof(Filters.AuditAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public static void SetupBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<Core.Contracts.IOrderService, Service.OrderService>();
            services.AddTransient<Core.Contracts.IWidgetService, Service.WidgetService>();
            services.AddTransient<Core.Contracts.ILogService, Service.LogService>();
        }

        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddTransient<Core.Contracts.IOrderRepository, Data.OrderRepository>();
            services.AddTransient<Core.Contracts.IWidgetRepository, Data.WidgetRepository>();
            services.AddTransient<Core.Contracts.ILogRepository, Data.LogRepository>();
        }

        public static void SetupAutomapper(this IServiceCollection services)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void SetupGoogleAuthentication(this IServiceCollection services)
        {
            //Authentication
            services.AddIdentity<Data.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Data.DatabaseContext>()
                .AddDefaultTokenProviders();

            //Google Authentication
            services.AddAuthentication().AddGoogle(o =>
            {
                // Configure your auth keys, usually stored in Config or User Secrets
                o.ClientId = "<yourid>";
                o.ClientSecret = "<yoursecret>";
                o.Scope.Add("https://www.googleapis.com/auth/plus.me");
                o.ClaimActions.MapJsonKey(ClaimTypes.Gender, "gender");
                o.SaveTokens = true;
                o.Events.OnCreatingTicket = ctx =>
                {
                    var tokens = ctx.Properties.GetTokens() as List<AuthenticationToken>;
                    tokens.Add(new AuthenticationToken() { Name = "TicketCreated", Value = DateTime.UtcNow.ToString() });
                    ctx.Properties.StoreTokens(tokens);
                    return Task.CompletedTask;
                };
            });
        }

        public static void SetupExceptionHandling(this IApplicationBuilder app, IHostingEnvironment env)
        {
            //TODO, while this works the redirect seems messy.
            app.UseExceptionHandler(a => a.Run(async context =>
             {
                 var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                 var exception = exceptionHandlerPathFeature.Error;

                 var logService = app.ApplicationServices.GetService<Core.Contracts.ILogService>();
                 logService.LogError(exception);
                 //var result = JsonConvert.SerializeObject(new { error = exception });
                 //context.Response.ContentType = "application/json";
                 //await context.Response.WriteAsync(result);
                 context.Response.Redirect("/Home/Error");
             }));

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}
        }
    }
}
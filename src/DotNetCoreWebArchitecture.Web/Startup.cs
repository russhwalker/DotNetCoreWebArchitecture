using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.Configure<CookiePolicyOptions>(options => options.MinimumSameSitePolicy = SameSiteMode.None);
            services.SetupDatabase();
            services.SetupBusinessServices();
            services.SetupRepositories();
            services.SetupMVC();
            services.SetupAutomapper();
            services.SetupAuthentication();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.SetupExceptionHandling(env);
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

            TestDataSeeder.Seed(app.ApplicationServices.GetService<Data.DatabaseContext>());
        }
    }
}
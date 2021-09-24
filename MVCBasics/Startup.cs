using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCBasics.Models;
using MVCBasics.Repository;
using MVCBasics.Services;
using Newtonsoft.Json.Serialization;

namespace MVCBasics
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
            //Dependency Injections or Singleton Objects
            services.AddSingleton<PeopleContext>();
            services.AddSingleton<IPeopleService, PeopleService>();
            services.AddSingleton<IPeopleRepo, DatabasePeopleRepo>();
            services.AddSingleton<ICityService, CityService>();
            services.AddSingleton<ICityRepo, DatabaseCityRepo>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<ICountryRepo, DatabaseCountryRepo>();
            services.AddSingleton<ILanguageService, LanguageService>();
            services.AddSingleton<ILanguageRepo, DatabaseLanguageRepo>();

            services.AddIdentity<User,IdentityRole>(options=> { })
                .AddEntityFrameworkStores<PeopleContext>();

            services.ConfigureApplicationCookie(options => options.LoginPath = new PathString("/User/Login"));
            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

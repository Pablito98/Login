using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models.Services.Application;
using Login.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Login
{
    public class Startup
    {
      

        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
   
            });

                services.AddTransient<ILoginService, AdoNetLoginService>();

                services.AddTransient<IDatabaseAccessor, SqliteDatabaseAccessor>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                 
            }
          

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

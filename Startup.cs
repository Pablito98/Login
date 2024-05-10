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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
    services.Configure<MvcOptions>(options =>
    {
        options.EnableEndpointRouting = false;
    });
           

                services.AddTransient<ILoginService, AdoNetLoginService>();

                services.AddTransient<IDatabaseAccessor, SqliteDatabaseAccessor>();

            
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
            
           app.UseRouting();
            app.UseEndpoints(routeBuilder => {
                routeBuilder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

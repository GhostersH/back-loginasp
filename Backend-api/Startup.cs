
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Web.Http;

namespace TuNombreDeProyecto
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin(); // Permitir solicitudes desde cualquier origen  
                });
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
        builder.WithOrigins("https://login-proyecto-angular-master-2.vercel.app/")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("Access-Control-Allow-Origin")
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.Use(async (context, next) =>  
{  
    context.Response.Headers.Add("Access-Control-Allow-Origin", "https://login-proyecto-angular-master-2.vercel.app");  
    await next();  
});  


        }
    }
}


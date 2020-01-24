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
using WebAPICoreSampleDemonstration2002.API.HttpClientFactory;
using WebAPICoreSampleDemonstration2002.BusinessService;
using WebAPICoreSampleDemonstration2002.BusinessService.Extensions;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Data;

namespace WebAPICoreSampleDemonstration2002.API
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
            services.AddControllers();
            services.AddSingleton<IAsyncService<User>, ClientService>();
            services.AddTransient<IAsyncService<CommentData>, ClientFactoryService>();
            /* services.AddScoped<IAsyncService<User>, ClientService>();*/

            services.AddHttpClient(); /* Add IHTTPClientFactory and related services*/
            services.AddInternalServices();/* Add services from WebAPICoreSampleDemonstration2002.BusinessService.Extensions*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
                                                    , IWebHostEnvironment env
                                                    , ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/WEBAPI-{Date}.txt"); /* Log file created with Date.txt in Logs folder*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

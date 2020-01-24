using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace WebAPICoreSampleDemonstration2002.BusinessService.Extensions
{
    public static class IServiceCollectionExtension
    {
       
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {           
            /* services.AddTransient<IWriteSimpleDataService, WriteSimpleDataService>();*/
            //  services.AddHttpClient(); /* Add IHTTPClientFactory and related services*/
          
            return services;
        }
    }
}

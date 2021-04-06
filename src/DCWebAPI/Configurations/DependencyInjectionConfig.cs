using System;
using DCData.Data;
using DCDomain.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DCWebAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICustomerData, CustomerData>();
            services.AddScoped<Data>();
        }
    }
}
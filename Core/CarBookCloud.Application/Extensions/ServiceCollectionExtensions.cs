using CarBookCloud.Persistence.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarBookCloud.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            // Infrastructure persistence katmanındaki AddPersistence’i çağrıldı.
            services.AddPersistence(connectionString);

            // Application servislerini buraya ekleyebilir.


            return services;
        }
    }
}

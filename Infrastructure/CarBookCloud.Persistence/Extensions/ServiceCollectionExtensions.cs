using CarBookCloud.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            // DbContext ekle
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repository implementasyonlarını ekle
            // Örnek:
            // services.AddScoped<ICarRepository, CarRepository>();

            return services;
        }
    }
}

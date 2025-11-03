using CarBookCloud.Contracts.Events;
using CarBookCloud.Contracts.Repositories;
using CarBookCloud.Contracts.UnitOfWork;
using CarBookCloud.Persistence.Contexts;
using CarBookCloud.Persistence.Extensions;
using CarBookCloud.Persistence.Repositories;
using CarBookCloud.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CarBookCloud.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // MediatR handler’ları
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CarBookCloud.Application.Handlers.Commands.CreateAboutCommandHandler).Assembly)
            );

            return services;
        }
    }
}

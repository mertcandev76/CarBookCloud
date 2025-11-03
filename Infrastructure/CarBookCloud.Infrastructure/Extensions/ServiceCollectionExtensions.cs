using CarBookCloud.Contracts.Events;
using CarBookCloud.Contracts.Repositories;
using CarBookCloud.Contracts.UnitOfWork;
using CarBookCloud.Infrastructure.EventDispatching;
using CarBookCloud.Persistence.Contexts;
using CarBookCloud.Persistence.Repositories;
using CarBookCloud.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarBookCloud.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositories
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();
            services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            services.AddScoped<ICarPricingRepository, CarPricingRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IFooterAddressRepository, FooterAddressRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPricingRepository, PricingRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();

            // DomainEventPublisher
            services.AddScoped<IDomainEventPublisher, MediatRDomainEventPublisher>();

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

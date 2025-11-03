using CarBookCloud.Contracts.Events;
using CarBookCloud.Contracts.Repositories;
using CarBookCloud.Contracts.UnitOfWork;
using CarBookCloud.Domain.Events;
using CarBookCloud.Persistence.Contexts;
using CarBookCloud.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IDomainEventPublisher _publisher;

        public UnitOfWork(AppDbContext context, IDomainEventPublisher publisher, IAboutRepository abouts, IBannerRepository banners, IBrandRepository brands, ICarDescriptionRepository carDescriptions, ICarFeatureRepository carFeatures, ICarPricingRepository carPricings, ICarRepository cars, ICategoryRepository categorys, IContactRepository contacts, IFeatureRepository features, IFooterAddressRepository footerAddresses, ILocationRepository locations, IPricingRepository pricings, IServiceRepository services, ISocialMediaRepository socialMedias, ITestimonialRepository testimonials)
        {
            _context = context;
            _publisher = publisher;
            Abouts = abouts;
            Banners = banners;
            Brands = brands;
            CarDescriptions = carDescriptions;
            CarFeatures = carFeatures;
            CarPricings = carPricings;
            Cars = cars;
            Categories = categorys;
            Contacts = contacts;
            Features = features;
            FooterAddresses = footerAddresses;
            Locations = locations;
            Pricings = pricings;
            Services = services;
            SocialMedias = socialMedias;
            Testimonials = testimonials;
        }

        public IAboutRepository Abouts { get; }
        public IBannerRepository Banners { get; }
        public IBrandRepository Brands { get; }
        public ICarDescriptionRepository CarDescriptions { get; }
        public ICarFeatureRepository CarFeatures { get; }
        public ICarPricingRepository CarPricings { get; }
        public ICarRepository Cars { get; }
        public ICategoryRepository Categories { get; }
        public IContactRepository Contacts { get; }
        public IFeatureRepository Features { get; }
        public IFooterAddressRepository FooterAddresses { get; }
        public ILocationRepository Locations { get; }
        public IPricingRepository Pricings { get; }
        public IServiceRepository Services { get; }
        public ISocialMediaRepository SocialMedias { get; }
        public ITestimonialRepository Testimonials { get; }

        public Task<int> SaveChangesAsync()
            => _context.SaveChangesAsync();

        public async Task SaveEntitiesAsync()
        {
            // EF ChangeTracker’daki entity'lerden domain eventleri topluyoruz
            var entitiesWithEvents = _context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IHasDomainEvents)
                .Select(e => (IHasDomainEvents)e.Entity)
                .ToList();

            var domainEvents = entitiesWithEvents
                .SelectMany(e => e.DomainEvents)
                .ToList();

            // önce DB save
            await SaveChangesAsync();

            // sonra publish
            foreach (var domainEvent in domainEvents)
                await _publisher.PublishAsync(domainEvent);

            // domain eventleri temizle
            entitiesWithEvents.ForEach(e => e.ClearDomainEvents());
        }
    }
}
